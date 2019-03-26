using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kendo.Mvc.UI;
using Tool_Management.DataAccess;
using Tool_Management.Service.Interfaces;
using Tool_Management.Service.ViewModels;
using Tool_Management.Service.Utils;
using Kendo.Mvc.Extensions;

namespace Tool_Management.Service.Services
{
    public class TM_NailMasterService : ITM_NailMaster
    {
        private ToolManagementEntities _db = new ToolManagementEntities();

        void ITM_NailMaster.Create(NailMasterViewModel viewModel)
        {
            DateTime CreateTime = DateTime.Now;

            var entry = new NailMaster
            {
                NailMaster_ID = viewModel.NailMaster_ID,
                Nail_Brand = viewModel.Nail_Brand,
                Nail_Name = viewModel.Nail_Name,
                Nail_CabinID = viewModel.Nail_CabinID,
                Nail_Spec = viewModel.Nail_Spec,
                Nail_Quality = viewModel.Nail_Quality,
                NailMaster_Create_DT = CreateTime,
                NailMaster_Modify_DT = CreateTime,
                NailMaster_Create_ID = viewModel.NailMaster_Create_ID,
                NailMaster_Modify_ID = viewModel.NailMaster_Modify_ID

            };
            _db.NailMasters.Add(entry);
            _db.SaveChanges();

            //insert NailDetail
            int no;
            var result = _db.NailDetails.OrderByDescending(x => x.NailDetail_ID.Contains(viewModel.NailMaster_ID)).First();
            if (result == null)
                no = 1;
            else
                no = int.Parse(result.NailDetail_ID.Split('-')[1]) + 1;

            for (int i = 0; i < viewModel.Nail_Quality; i++)
            {
                string sn = "000000" + (no + i).ToString();
                sn = sn.Substring(sn.Length - 6);
                var k = new NailDetail
                {
                    NailDetail_ID = viewModel.NailMaster_ID + "-" + sn,
                    NailDetail_Status = ((int)SysCode.Status.正常入庫).ToString(),
                    //IsNewNail = "Y",
                    //NewEnter_DT = CreateTime,
                    NailMaster_ID = viewModel.NailMaster_ID,
                    NailDetail_Create_DT = CreateTime,
                    NailDetail_Modify_DT = CreateTime,
                    NailDetail_Create_ID = viewModel.NailMaster_Create_ID,
                    NailDetail_Modify_ID = viewModel.NailMaster_Modify_ID
                };
                _db.NailDetails.Add(k);
                _db.SaveChanges();
            }
        }

        void ITM_NailMaster.Update(NailMasterViewModel viewModel)
        {
            
            var q = from p in _db.NailMasters
                    where p.NailMaster_ID == viewModel.NailMaster_ID
                    select p;
            if (q.FirstOrDefault() != null)
            {
                foreach (var p in q)
                {
                    p.Nail_Name = viewModel.Nail_Name;
                    p.Nail_CabinID = viewModel.Nail_CabinID;
                    p.Nail_Spec = viewModel.Nail_Spec;
                    p.Nail_Brand = viewModel.Nail_Brand;                    
                    p.NailMaster_Modify_DT = System.DateTime.Now;
                    p.NailMaster_Modify_ID = viewModel.NailMaster_Modify_ID;
                }
                _db.SaveChanges();
            }
        }

        public DataSourceResult GridSearch(DataSourceRequest request)
        {

            var result = (from c in _db.NailMasters
                        join e1 in _db.Employes on c.NailMaster_Create_ID equals e1.Emp_ID
                        join e2 in _db.Employes on c.NailMaster_Modify_ID equals e2.Emp_ID
                        select new NailMasterViewModel
                        {

                            NailMaster_ID = c.NailMaster_ID,
                            Nail_Brand = c.Nail_Brand,
                            Nail_Name = c.Nail_Name,
                            Nail_Spec = c.Nail_Spec,
                            Nail_CabinID = c.Nail_CabinID,
                            
                            NailMaster_Create_DT = c.NailMaster_Create_DT,
                            NailMaster_Modify_DT = c.NailMaster_Modify_DT,
                            NailMaster_Create_Name =e1.Emp_Name,
                            NailMaster_Create_ID = c.NailMaster_Create_ID,
                            NailMaster_Modify_Name = e2.Emp_Name,
                            NailMaster_Modify_ID = c.NailMaster_Modify_ID
                        }).ToDataSourceResult(request);


            return result;
        }

        NailMasterViewModel ITM_NailMaster.Get(string id)
        {
            var result = (from c in _db.NailMasters
                          where c.NailMaster_ID == id
                          select new NailMasterViewModel
                          {
                              NailMaster_ID = c.NailMaster_ID,
                              Nail_Brand = c.Nail_Brand,
                              Nail_CabinID = c.Nail_CabinID,
                              Nail_Name = c.Nail_Name,
                              Nail_Quality = c.Nail_Quality,
                              Nail_Spec = c.Nail_Spec,
                              NailMaster_Create_DT = c.NailMaster_Create_DT,
                              NailMaster_Create_ID = c.NailMaster_Create_ID,

                              NailMaster_Modify_DT = c.NailMaster_Modify_DT,
                              NailMaster_Modify_ID = c.NailMaster_Modify_ID,


                          }).FirstOrDefault();

            return result;
        }

    }

    public class TM_NailDetailService : ITM_NailDetail
    {
        private ToolManagementEntities _db = new ToolManagementEntities();

        void ITM_NailDetail.Create(NailMasterViewModel viewModel)
        {
            DateTime CreateTime = DateTime.Now;

            //insert    NailDetail
            int no;
            var result = _db.NailDetails.OrderByDescending(x => x.NailDetail_ID.Contains(viewModel.NailMaster_ID)).First();
            if (result == null)
                no = 1;
            else
                no = int.Parse(result.NailDetail_ID.Split('-')[1]) + 1;

            for (int i = 0; i < viewModel.Nail_Quality; i++)
            {
                string sn = "000000" + (no + i).ToString();
                sn = sn.Substring(sn.Length - 6);
                var k = new NailDetail
                {
                    NailDetail_ID = viewModel.NailMaster_ID + "-" + sn,
                    NailDetail_Status = ((int)SysCode.Status.正常入庫).ToString(),
                    //IsNewNail = "Y",
                    //NewEnter_DT =CreateTime,
                    NailMaster_ID = viewModel.NailMaster_ID,
                    NailDetail_Create_DT = CreateTime,
                    NailDetail_Modify_DT = CreateTime,
                    NailDetail_Create_ID = viewModel.NailMaster_Create_ID,
                    NailDetail_Modify_ID = viewModel.NailMaster_Modify_ID
                };
                _db.NailDetails.Add(k);
                _db.SaveChanges();
            }
        }

        void ITM_NailDetail.Update(NailDetailViewModel viewModel)
        {

            var q = from p in _db.NailDetails
                    where p.NailDetail_ID == viewModel.NailDetail_ID
                    select p;
            if (q.FirstOrDefault() != null)
            {
                foreach (var p in q)
                {
                    //p.IsNewNail = viewModel.IsNewNail;                    
                    p.NailDetail_Status = viewModel.NailDetail_Status;
                    p.NailDetail_Modify_ID = viewModel.NailDetail_Modify_ID;
                    p.NailDetail_Modify_DT = viewModel.NailDetail_Modify_DT;

                }
                _db.SaveChanges();
            }
        }

        public DataSourceResult GridSearch(DataSourceRequest request)
        {

            var result = (from c in _db.NailDetails
                        join e1 in _db.Employes on c.NailDetail_Create_ID equals e1.Emp_ID
                        join e2 in _db.Employes on c.NailDetail_Modify_ID equals e2.Emp_ID
                        select new NailDetailViewModel
                        {

                            NailDetail_ID = c.NailDetail_ID,
                            NailDetail_Status = c.NailDetail_Status,
                            //IsNewDetail = c.IsNewDetail,
                            //NewEnter_DT = c.NewEnter_DT,                             
                            NailDetail_Create_DT = c.NailDetail_Create_DT,
                            NailDetail_Modify_DT = c.NailDetail_Modify_DT,
                            NailDetail_Create_Name = e1.Emp_Name,
                            NailDetail_Create_ID = c.NailDetail_Create_ID,
                            NailDetail_Modify_Name = e2.Emp_Name,
                            NailDetail_Modify_ID = c.NailDetail_Modify_ID
                        }).ToDataSourceResult(request);

            return result;
        }

    }


}
