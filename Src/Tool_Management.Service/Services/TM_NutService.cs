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
    public class TM_NutMasterService : ITM_NutMaster
    {
        private ToolManagementEntities _db = new ToolManagementEntities();

        void ITM_NutMaster.Create(NutMasterViewModel viewModel)
        {
            DateTime CreateTime = DateTime.Now;

            var entry = new NutMaster
            {
                NutMaster_ID = viewModel.NutMaster_ID,
                Nut_Brand = viewModel.Nut_Brand,
                Nut_Name = viewModel.Nut_Name,
                Nut_CabinID = viewModel.Nut_CabinID,
                Nut_Spec = viewModel.Nut_Spec,
                Nut_Quality = viewModel.Nut_Quality,
                NutMaster_Create_DT = CreateTime,
                NutMaster_Modify_DT = CreateTime,
                NutMaster_Create_ID = viewModel.NutMaster_Create_ID,
                NutMaster_Modify_ID = viewModel.NutMaster_Modify_ID

            };
            _db.NutMasters.Add(entry);
            _db.SaveChanges();

            //insert HiltDetail
            int no;
            var result = _db.NutDetails.OrderByDescending(x => x.NutDetail_ID.Contains(viewModel.NutMaster_ID)).First();
            if (result == null)
                no = 1;
            else
                no = int.Parse(result.NutDetail_ID.Split('-')[1]) + 1;

            for (int i = 0; i < viewModel.Nut_Quality; i++)
            {
                string sn = "000000" + (no + i).ToString();
                sn = sn.Substring(sn.Length - 6);
                var k = new NutDetail
                {
                    NutDetail_ID = viewModel.NutMaster_ID + "-" + sn,
                    NutDetail_Status = ((int)SysCode.Status.正常入庫).ToString(),
                    //IsNewHilt = "Y",
                    //NewEnter_DT = CreateTime,
                    NutMaster_ID = viewModel.NutMaster_ID,
                    NutDetail_Create_DT = CreateTime,
                    NutDetail_Modify_DT = CreateTime,
                    NutDetail_Create_ID = viewModel.NutMaster_Create_ID,
                    NutDetail_Modify_ID = viewModel.NutMaster_Modify_ID
                };
                _db.NutDetails.Add(k);
                _db.SaveChanges();
            }
        }

        void ITM_NutMaster.Update(NutMasterViewModel viewModel)
        {
            
            var q = from p in _db.NutMasters
                    where p.NutMaster_ID == viewModel.NutMaster_ID
                    select p;
            if (q.FirstOrDefault() != null)
            {
                foreach (var p in q)
                {
                    p.Nut_Name = viewModel.Nut_Name;
                    p.Nut_CabinID = viewModel.Nut_CabinID;
                    p.Nut_Spec = viewModel.Nut_Spec;
                    p.Nut_Brand = viewModel.Nut_Brand;                    
                    p.NutMaster_Modify_DT = System.DateTime.Now;
                    p.NutMaster_Modify_ID = viewModel.NutMaster_Modify_ID;
                }
                _db.SaveChanges();
            }
        }

        public DataSourceResult GridSearch(DataSourceRequest request)
        {

            var result = (from c in _db.NutMasters
                          join e1 in _db.Employes on c.NutMaster_Create_ID equals e1.Emp_ID
                        join e2 in _db.Employes on c.NutMaster_Modify_ID equals e2.Emp_ID
                        select new NutMasterViewModel
                        {

                            NutMaster_ID = c.NutMaster_ID,
                            Nut_Brand = c.Nut_Brand,
                            Nut_Name = c.Nut_Name,
                            Nut_Spec = c.Nut_Spec,
                            Nut_CabinID = c.Nut_CabinID,

                            NutMaster_Create_DT = c.NutMaster_Create_DT,
                            NutMaster_Modify_DT = c.NutMaster_Modify_DT,
                            NutMaster_Create_Name = e1.Emp_Name,
                            NutMaster_Create_ID = c.NutMaster_Create_ID,
                            NutMaster_Modify_Name = e2.Emp_Name,
                            NutMaster_Modify_ID = c.NutMaster_Modify_ID
                        }).ToDataSourceResult(request);


            return result;
        }

    }

    public class TM_NutDetailService : ITM_NutDetail
    {
        private ToolManagementEntities _db = new ToolManagementEntities();

        void ITM_NutDetail.Create(NutMasterViewModel viewModel)
        {
            DateTime CreateTime = DateTime.Now;

            //insert NutDetail
            int no;
            var result = _db.NutDetails.OrderByDescending(x => x.NutDetail_ID.Contains(viewModel.NutMaster_ID)).First();
            if (result == null)
                no = 1;
            else
                no = int.Parse(result.NutDetail_ID.Split('-')[1]) + 1;

            for (int i = 0; i < viewModel.Nut_Quality; i++)
            {
                string sn = "000000" + (no + i).ToString();
                sn = sn.Substring(sn.Length - 6);
                var k = new NutDetail
                {
                    NutDetail_ID = viewModel.NutMaster_ID + "-" + sn,
                    NutDetail_Status = ((int)SysCode.Status.正常入庫).ToString(),
                    //IsNewHilt = "Y",
                    //NewEnter_DT =CreateTime,
                    NutMaster_ID = viewModel.NutMaster_ID,
                    NutDetail_Create_DT = CreateTime,
                    NutDetail_Modify_DT = CreateTime,
                    NutDetail_Create_ID = viewModel.NutMaster_Create_ID,
                    NutDetail_Modify_ID = viewModel.NutMaster_Modify_ID
                };
                _db.NutDetails.Add(k);
                _db.SaveChanges();
            }
        }

        void ITM_NutDetail.Update(NutDetailViewModel viewModel)
        {

            var q = from p in _db.NutDetails
                    where p.NutDetail_ID == viewModel.NutDetail_ID
                    select p;
            if (q.FirstOrDefault() != null)
            {
                foreach (var p in q)
                {
                    //p.IsNewHilt = viewModel.IsNewHilt;                    
                    p.NutDetail_Status = viewModel.NutDetail_Status;
                    p.NutDetail_Modify_ID = viewModel.NutDetail_Modify_ID;
                    p.NutDetail_Modify_DT = viewModel.NutDetail_Modify_DT;

                }
                _db.SaveChanges();
            }
        }

        public DataSourceResult GridSearch(DataSourceRequest request)
        {

            var result = (from c in _db.NutDetails
                          join e1 in _db.Employes on c.NutDetail_Create_ID equals e1.Emp_ID
                        join e2 in _db.Employes on c.NutDetail_Modify_ID equals e2.Emp_ID
                        select new NutDetailViewModel
                        {

                            NutDetail_ID = c.NutDetail_ID,
                            NutDetail_Status = c.NutDetail_Status,
                            //IsNewHilt = c.IsNewHilt,
                            //NewEnter_DT = c.NewEnter_DT,                             
                            NutDetail_Create_DT = c.NutDetail_Create_DT,
                            NutDetail_Modify_DT = c.NutDetail_Modify_DT,
                            NutDetail_Create_Name = e1.Emp_Name,
                            NutDetail_Create_ID = c.NutDetail_Create_ID,
                            NutDetail_Modify_Name = e2.Emp_Name,
                            NutDetail_Modify_ID = c.NutDetail_Modify_ID
                        }).ToDataSourceResult(request);

            return result;
        }

    }


}
