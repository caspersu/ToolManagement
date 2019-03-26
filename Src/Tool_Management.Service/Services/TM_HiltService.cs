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
    public class TM_HiltMasterService : ITM_HiltMaster
    {
        private ToolManagementEntities _db = new ToolManagementEntities();

        void ITM_HiltMaster.Create(HiltMasterViewModel viewModel)
        {
            DateTime CreateTime = DateTime.Now;

            var entry = new HiltMaster
            {
                HiltMaster_ID = viewModel.HiltMaster_ID,
                Hilt_Brand = viewModel.Hilt_Brand,
                Hilt_Name = viewModel.Hilt_Name,
                Hilt_CabinID = viewModel.Hilt_CabinID,
                Hilt_Spec = viewModel.Hilt_Spec,
                Hilt_Quality = viewModel.Hilt_Quality,
                HiltMaster_Create_DT = CreateTime,
                HiltMaster_Modify_DT = CreateTime,
                HiltMaster_Create_ID = viewModel.HiltMaster_Create_ID,
                HiltMaster_Modify_ID = viewModel.HiltMaster_Modify_ID

            };
            _db.HiltMasters.Add(entry);
            _db.SaveChanges();

            //insert HiltDetail
            int no;
            var result = _db.HiltDetails.OrderByDescending(x => x.HiltDetail_ID.Contains(viewModel.HiltMaster_ID)).First();
            if (result == null)
                no = 1;
            else
                no = int.Parse(result.HiltDetail_ID.Split('-')[1]) + 1;

            for (int i = 0; i < viewModel.Hilt_Quality; i++)
            {
                string sn = "000000" + (no + i).ToString();
                sn = sn.Substring(sn.Length - 6);
                var k = new HiltDetail
                {
                    HiltDetail_ID = viewModel.HiltMaster_ID + "-" + sn,
                    HiltDetail_Status = ((int)SysCode.Status.正常入庫).ToString(),
                    IsNewHilt = "Y",
                    NewEnter_DT = CreateTime,
                    HiltMaster_ID = viewModel.HiltMaster_ID,
                    HiltDetail_Create_DT = CreateTime,
                    HiltDetail_Modify_DT = CreateTime,
                    HiltDetail_Create_ID = viewModel.HiltMaster_Create_ID,
                    HiltDetail_Modify_ID = viewModel.HiltMaster_Modify_ID
                };
                _db.HiltDetails.Add(k);
                _db.SaveChanges();
            }
        }

        void ITM_HiltMaster.Update(HiltMasterViewModel viewModel)
        {
            
            var q = from p in _db.HiltMasters
                    where p.HiltMaster_ID == viewModel.HiltMaster_ID
                    select p;
            if (q.FirstOrDefault() != null)
            {
                foreach (var p in q)
                {
                    p.Hilt_Name = viewModel.Hilt_Name;
                    p.Hilt_CabinID = viewModel.Hilt_CabinID;
                    p.Hilt_Spec = viewModel.Hilt_Spec;
                    p.Hilt_Brand = viewModel.Hilt_Brand;                    
                    p.HiltMaster_Modify_DT = System.DateTime.Now;
                    p.HiltMaster_Modify_ID = viewModel.HiltMaster_Modify_ID;
                }
                _db.SaveChanges();
            }
        }

        public DataSourceResult GridSearch(DataSourceRequest request)
        {

            var result = (from c in _db.HiltMasters
                        join e1 in _db.Employes on c.HiltMaster_Create_ID equals e1.Emp_ID
                        join e2 in _db.Employes on c.HiltMaster_Modify_ID equals e2.Emp_ID
                        select new HiltMasterViewModel
                        {

                            HiltMaster_ID = c.HiltMaster_ID,
                            Hilt_Brand = c.Hilt_Brand,
                            Hilt_Name = c.Hilt_Name,
                            Hilt_Spec = c.Hilt_Spec,
                            Hilt_CabinID = c.Hilt_CabinID,
                            
                            HiltMaster_Create_DT = c.HiltMaster_Create_DT,
                            HiltMaster_Modify_DT = c.HiltMaster_Modify_DT,
                            HiltMaster_Create_Name =e1.Emp_Name,
                            HiltMaster_Create_ID = c.HiltMaster_Create_ID,
                            HiltMaster_Modify_Name = e2.Emp_Name,
                            HiltMaster_Modify_ID = c.HiltMaster_Modify_ID
                        }).ToDataSourceResult(request);


            return result;
        }

        HiltMasterViewModel ITM_HiltMaster.Get(string id)
        {
            var result = (from c in _db.HiltMasters
                          where c.HiltMaster_ID == id
                          select new HiltMasterViewModel
                          {
                              HiltMaster_ID = c.HiltMaster_ID,
                              Hilt_Brand = c.Hilt_Brand,
                              Hilt_CabinID = c.Hilt_CabinID,
                              Hilt_Name = c.Hilt_Name,
                              Hilt_Quality = c.Hilt_Quality,
                              Hilt_Spec = c.Hilt_Spec,
                              HiltMaster_Create_DT = c.HiltMaster_Create_DT,
                              HiltMaster_Create_ID = c.HiltMaster_Create_ID,
                              
                              HiltMaster_Modify_DT = c.HiltMaster_Modify_DT,
                              HiltMaster_Modify_ID = c.HiltMaster_Modify_ID,
                             

                          }).FirstOrDefault();

            return result;
        }

    }

    public class TM_HiltDetailService : ITM_HiltDetail
    {
        private ToolManagementEntities _db = new ToolManagementEntities();

        void ITM_HiltDetail.Create(HiltMasterViewModel viewModel)
        {
            DateTime CreateTime = DateTime.Now;

            //insert HiltDetail
            int no;
            var result = _db.HiltDetails.OrderByDescending(x => x.HiltDetail_ID.Contains(viewModel.HiltMaster_ID)).First();
            if (result == null)
                no = 1;
            else
                no = int.Parse(result.HiltDetail_ID.Split('-')[1]) + 1;

            for (int i = 0; i < viewModel.Hilt_Quality; i++)
            {
                string sn = "000000" + (no + i).ToString();
                sn = sn.Substring(sn.Length - 6);
                var k = new HiltDetail
                {
                    HiltDetail_ID = viewModel.HiltMaster_ID + "-" + sn,
                    HiltDetail_Status = ((int)SysCode.Status.正常入庫).ToString(),
                    IsNewHilt = "Y",
                    NewEnter_DT =CreateTime,
                    HiltMaster_ID = viewModel.HiltMaster_ID,
                    HiltDetail_Create_DT = CreateTime,
                    HiltDetail_Modify_DT = CreateTime,
                    HiltDetail_Create_ID = viewModel.HiltMaster_Create_ID,
                    HiltDetail_Modify_ID = viewModel.HiltMaster_Modify_ID
                };
                _db.HiltDetails.Add(k);
                _db.SaveChanges();
            }
        }

        void ITM_HiltDetail.Update(HiltDetailViewModel viewModel)
        {

            var q = from p in _db.HiltDetails
                    where p.HiltDetail_ID == viewModel.HiltDetail_ID
                    select p;
            if (q.FirstOrDefault() != null)
            {
                foreach (var p in q)
                {
                    p.IsNewHilt = viewModel.IsNewHilt;                    
                    p.HiltDetail_Status = viewModel.HiltDetail_Status;
                    p.HiltDetail_Modify_ID = viewModel.HiltDetail_Modify_ID;
                    p.HiltDetail_Modify_DT = viewModel.HiltDetail_Modify_DT;

                }
                _db.SaveChanges();
            }
        }

        public DataSourceResult GridSearch(DataSourceRequest request)
        {

            var result = (from c in _db.HiltDetails
                        join e1 in _db.Employes on c.HiltDetail_Create_ID equals e1.Emp_ID
                        join e2 in _db.Employes on c.HiltDetail_Modify_ID equals e2.Emp_ID
                        select new HiltDetailViewModel
                        {

                            HiltDetail_ID = c.HiltDetail_ID,
                            HiltDetail_Status = c.HiltDetail_Status,
                            IsNewHilt = c.IsNewHilt,
                            NewEnter_DT = c.NewEnter_DT,                             
                            HiltDetail_Create_DT = c.HiltDetail_Create_DT,
                            HiltDetail_Modify_DT = c.HiltDetail_Modify_DT,
                            HiltDetail_Create_Name = e1.Emp_Name,
                            HiltDetail_Create_ID = c.HiltDetail_Create_ID,
                            HiltDetail_Modify_Name = e2.Emp_Name,
                            HiltDetail_Modify_ID = c.HiltDetail_Modify_ID
                        }).ToDataSourceResult(request);

            return result;
        }

    }


}
