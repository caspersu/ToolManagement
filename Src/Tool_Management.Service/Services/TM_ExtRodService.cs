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
    public class TM_ExtRodMasterService : ITM_ExtRodMaster
    {
        private ToolManagementEntities _db = new ToolManagementEntities();

        void ITM_ExtRodMaster.Create(ExtRodMasterViewModel viewModel)
        {
            DateTime CreateTime = DateTime.Now;

            var entry = new ExtRodMaster
            {
                ExtRodMaster_ID = viewModel.ExtRodMaster_ID,
                ExtRod_Brand = viewModel.ExtRod_Brand,
                ExtRod_Name = viewModel.ExtRod_Name,
                ExtRod_CabinID = viewModel.ExtRod_CabinID,
                ExtRod_Spec = viewModel.ExtRod_Spec,
                ExtRod_Quality = viewModel.ExtRod_Quality,
                ExtRodMaster_Create_DT = CreateTime,
                ExtRodMaster_Modify_DT = CreateTime,
                ExtRodMaster_Create_ID = viewModel.ExtRodMaster_Create_ID,
                ExtRodMaster_Modify_ID = viewModel.ExtRodMaster_Modify_ID

            };
            _db.ExtRodMasters.Add(entry);
            _db.SaveChanges();

            //insert HiltDetail
            int no;
            var result = _db.ExtRodDetails.OrderByDescending(x => x.ExtRodDetail_ID.Contains(viewModel.ExtRodMaster_ID)).First();
            if (result == null)
                no = 1;
            else
                no = int.Parse(result.ExtRodDetail_ID.Split('-')[1]) + 1;

            for (int i = 0; i < viewModel.ExtRod_Quality; i++)
            {
                string sn = "000000" + (no + i).ToString();
                sn = sn.Substring(sn.Length - 6);
                var k = new ExtRodDetail
                {
                    ExtRodDetail_ID = viewModel.ExtRodMaster_ID + "-" + sn,
                    ExtRodDetail_Status = ((int)SysCode.Status.正常入庫).ToString(),
                    //IsNewHilt = "Y",
                    //NewEnter_DT = CreateTime,
                    ExtRodMaster_ID = viewModel.ExtRodMaster_ID,
                    ExtRodDetail_Create_DT = CreateTime,
                    ExtRodDetail_Modify_DT = CreateTime,
                    ExtRodDetail_Create_ID = viewModel.ExtRodMaster_Create_ID,
                    ExtRodDetail_Modify_ID = viewModel.ExtRodMaster_Modify_ID
                };
                _db.ExtRodDetails.Add(k);
                _db.SaveChanges();
            }
        }

        void ITM_ExtRodMaster.Update(ExtRodMasterViewModel viewModel)
        {
            
            var q = from p in _db.ExtRodMasters
                    where p.ExtRodMaster_ID == viewModel.ExtRodMaster_ID
                    select p;
            if (q.FirstOrDefault() != null)
            {
                foreach (var p in q)
                {
                    p.ExtRod_Name = viewModel.ExtRod_Name;
                    p.ExtRod_CabinID = viewModel.ExtRod_CabinID;
                    p.ExtRod_Spec = viewModel.ExtRod_Spec;
                    p.ExtRod_Brand = viewModel.ExtRod_Brand;                    
                    p.ExtRodMaster_Modify_DT = System.DateTime.Now;
                    p.ExtRodMaster_Modify_ID = viewModel.ExtRodMaster_Modify_ID;
                }
                _db.SaveChanges();
            }
        }

        public DataSourceResult GridSearch(DataSourceRequest request)
        {

            var result = (from c in _db.ExtRodMasters
                          join e1 in _db.Employes on c.ExtRodMaster_Create_ID equals e1.Emp_ID
                        join e2 in _db.Employes on c.ExtRodMaster_Modify_ID equals e2.Emp_ID
                        select new ExtRodMasterViewModel
                        {

                            ExtRodMaster_ID = c.ExtRodMaster_ID,
                            ExtRod_Brand = c.ExtRod_Brand,
                            ExtRod_Name = c.ExtRod_Name,
                            ExtRod_Spec = c.ExtRod_Spec,
                            ExtRod_CabinID = c.ExtRod_CabinID,

                            ExtRodMaster_Create_DT = c.ExtRodMaster_Create_DT,
                            ExtRodMaster_Modify_DT = c.ExtRodMaster_Modify_DT,
                            ExtRodMaster_Create_Name = e1.Emp_Name,
                            ExtRodMaster_Create_ID = c.ExtRodMaster_Create_ID,
                            ExtRodMaster_Modify_Name = e2.Emp_Name,
                            ExtRodMaster_Modify_ID = c.ExtRodMaster_Modify_ID
                        }).ToDataSourceResult(request);


            return result;
        }

        ExtRodMasterViewModel ITM_ExtRodMaster.Get(string id)
        {
            var result = (from c in _db.ExtRodMasters
                          where c.ExtRodMaster_ID == id
                          select new ExtRodMasterViewModel
                          {
                              ExtRodMaster_ID = c.ExtRodMaster_ID,
                              ExtRod_Brand = c.ExtRod_Brand,
                              ExtRod_CabinID = c.ExtRod_CabinID,
                              ExtRod_Name = c.ExtRod_Name,
                              ExtRod_Quality = c.ExtRod_Quality,
                              ExtRod_Spec = c.ExtRod_Spec,
                              ExtRodMaster_Create_DT = c.ExtRodMaster_Create_DT,
                              ExtRodMaster_Create_ID = c.ExtRodMaster_Create_ID,
                              ExtRodMaster_Modify_DT = c.ExtRodMaster_Modify_DT,
                              ExtRodMaster_Modify_ID = c.ExtRodMaster_Modify_ID,

                          }).FirstOrDefault();

            return result;
        }

    }

    public class TM_ExtRodDetailService : ITM_ExtRodDetail
    {
        private ToolManagementEntities _db = new ToolManagementEntities();

        void ITM_ExtRodDetail.Create(ExtRodMasterViewModel viewModel)
        {
            DateTime CreateTime = DateTime.Now;

            //insert ExtRodDetail
            int no;
            var result = _db.ExtRodDetails.OrderByDescending(x => x.ExtRodDetail_ID.Contains(viewModel.ExtRodMaster_ID)).First();
            if (result == null)
                no = 1;
            else
                no = int.Parse(result.ExtRodDetail_ID.Split('-')[1]) + 1;

            for (int i = 0; i < viewModel.ExtRod_Quality; i++)
            {
                string sn = "000000" + (no + i).ToString();
                sn = sn.Substring(sn.Length - 6);
                var k = new ExtRodDetail
                {
                    ExtRodDetail_ID = viewModel.ExtRodMaster_ID + "-" + sn,
                    ExtRodDetail_Status = ((int)SysCode.Status.正常入庫).ToString(),
                    //IsNewHilt = "Y",
                    //NewEnter_DT =CreateTime,
                    ExtRodMaster_ID = viewModel.ExtRodMaster_ID,
                    ExtRodDetail_Create_DT = CreateTime,
                    ExtRodDetail_Modify_DT = CreateTime,
                    ExtRodDetail_Create_ID = viewModel.ExtRodMaster_Create_ID,
                    ExtRodDetail_Modify_ID = viewModel.ExtRodMaster_Modify_ID
                };
                _db.ExtRodDetails.Add(k);
                _db.SaveChanges();
            }
        }

        void ITM_ExtRodDetail.Update(ExtRodDetailViewModel viewModel)
        {

            var q = from p in _db.ExtRodDetails
                    where p.ExtRodDetail_ID == viewModel.ExtRodDetail_ID
                    select p;
            if (q.FirstOrDefault() != null)
            {
                foreach (var p in q)
                {
                    //p.IsNewHilt = viewModel.IsNewHilt;                    
                    p.ExtRodDetail_Status = viewModel.ExtRodDetail_Status;
                    p.ExtRodDetail_Modify_ID = viewModel.ExtRodDetail_Modify_ID;
                    p.ExtRodDetail_Modify_DT = viewModel.ExtRodDetail_Modify_DT;

                }
                _db.SaveChanges();
            }
        }

        public DataSourceResult GridSearch(DataSourceRequest request)
        {

            var result = (from c in _db.ExtRodDetails
                          join e1 in _db.Employes on c.ExtRodDetail_Create_ID equals e1.Emp_ID
                        join e2 in _db.Employes on c.ExtRodDetail_Modify_ID equals e2.Emp_ID
                        select new ExtRodDetailViewModel
                        {

                            ExtRodDetail_ID = c.ExtRodDetail_ID,
                            ExtRodDetail_Status = c.ExtRodDetail_Status,
                            //IsNewHilt = c.IsNewHilt,
                            //NewEnter_DT = c.NewEnter_DT,                             
                            ExtRodDetail_Create_DT = c.ExtRodDetail_Create_DT,
                            ExtRodDetail_Modify_DT = c.ExtRodDetail_Modify_DT,
                            ExtRodDetail_Create_Name = e1.Emp_Name,
                            ExtRodDetail_Create_ID = c.ExtRodDetail_Create_ID,
                            ExtRodDetail_Modify_Name = e2.Emp_Name,
                            ExtRodDetail_Modify_ID = c.ExtRodDetail_Modify_ID
                        }).ToDataSourceResult(request);

            return result;
        }

    }


}
