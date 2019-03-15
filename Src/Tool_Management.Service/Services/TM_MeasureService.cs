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
    public class TM_MeasureMasterService : ITM_MeasureMaster
    {
        private ToolManagementEntities _db = new ToolManagementEntities();

        void ITM_MeasureMaster.Create(MeasureMasterViewModel viewModel)
        {
            DateTime CreateTime = DateTime.Now;

            var entry = new MeasureMaster
            {
                MeasureMaster_ID = viewModel.MeasureMaster_ID,
                Measure_Brand = viewModel.Measure_Brand,
                Measure_Name = viewModel.Measure_Name,
                Measure_CabinID = viewModel.Measure_CabinID,
                Measure_Spec = viewModel.Measure_Spec,
                Measure_Quality = viewModel.Measure_Quality,
                MeasureMaster_Create_DT = CreateTime,
                MeasureMaster_Modify_DT = CreateTime,
                MeasureMaster_Create_ID = viewModel.MeasureMaster_Create_ID,
                MeasureMaster_Modify_ID = viewModel.MeasureMaster_Modify_ID

            };
            _db.MeasureMasters.Add(entry);
            _db.SaveChanges();

            //insert HiltDetail
            int no;
            var result = _db.MeasureDetails.OrderByDescending(x => x.MeasureDetail_ID.Contains(viewModel.MeasureMaster_ID)).First();
            if (result == null)
                no = 1;
            else
                no = int.Parse(result.MeasureDetail_ID.Split('-')[1]) + 1;

            for (int i = 0; i < viewModel.Measure_Quality; i++)
            {
                string sn = "000000" + (no + i).ToString();
                sn = sn.Substring(sn.Length - 6);
                var k = new MeasureDetail
                {
                    MeasureDetail_ID = viewModel.MeasureMaster_ID + "-" + sn,
                    MeasureDetail_Status = ((int)SysCode.Status.正常入庫).ToString(),
                    //IsNewHilt = "Y",
                    //NewEnter_DT = CreateTime,
                    MeasureMaster_ID = viewModel.MeasureMaster_ID,
                    MeasureDetail_Create_DT = CreateTime,
                    MeasureDetail_Modify_DT = CreateTime,
                    MeasureDetail_Create_ID = viewModel.MeasureMaster_Create_ID,
                    MeasureDetail_Modify_ID = viewModel.MeasureMaster_Modify_ID
                };
                _db.MeasureDetails.Add(k);
                _db.SaveChanges();
            }
        }

        void ITM_MeasureMaster.Update(MeasureMasterViewModel viewModel)
        {
            
            var q = from p in _db.MeasureMasters
                    where p.MeasureMaster_ID == viewModel.MeasureMaster_ID
                    select p;
            if (q.FirstOrDefault() != null)
            {
                foreach (var p in q)
                {
                    p.Measure_Name = viewModel.Measure_Name;
                    p.Measure_CabinID = viewModel.Measure_CabinID;
                    p.Measure_Spec = viewModel.Measure_Spec;
                    p.Measure_Brand = viewModel.Measure_Brand;                    
                    p.MeasureMaster_Modify_DT = System.DateTime.Now;
                    p.MeasureMaster_Modify_ID = viewModel.MeasureMaster_Modify_ID;
                }
                _db.SaveChanges();
            }
        }

        public DataSourceResult GridSearch(DataSourceRequest request)
        {

            var result = (from c in _db.MeasureMasters
                          join e1 in _db.Employes on c.MeasureMaster_Create_ID equals e1.Emp_ID
                        join e2 in _db.Employes on c.MeasureMaster_Modify_ID equals e2.Emp_ID
                        select new MeasureMasterViewModel
                        {

                            MeasureMaster_ID = c.MeasureMaster_ID,
                            Measure_Brand = c.Measure_Brand,
                            Measure_Name = c.Measure_Name,
                            Measure_Spec = c.Measure_Spec,
                            Measure_CabinID = c.Measure_CabinID,

                            MeasureMaster_Create_DT = c.MeasureMaster_Create_DT,
                            MeasureMaster_Modify_DT = c.MeasureMaster_Modify_DT,
                            MeasureMaster_Create_Name = e1.Emp_Name,
                            MeasureMaster_Create_ID = c.MeasureMaster_Create_ID,
                            MeasureMaster_Modify_Name = e2.Emp_Name,
                            MeasureMaster_Modify_ID = c.MeasureMaster_Modify_ID
                        }).ToDataSourceResult(request);


            return result;
        }

    }

    public class TM_MeasureDetailService : ITM_MeasureDetail
    {
        private ToolManagementEntities _db = new ToolManagementEntities();

        void ITM_MeasureDetail.Create(MeasureMasterViewModel viewModel)
        {
            DateTime CreateTime = DateTime.Now;

            //insert MeasureDetail
            int no;
            var result = _db.MeasureDetails.OrderByDescending(x => x.MeasureDetail_ID.Contains(viewModel.MeasureMaster_ID)).First();
            if (result == null)
                no = 1;
            else
                no = int.Parse(result.MeasureDetail_ID.Split('-')[1]) + 1;

            for (int i = 0; i < viewModel.Measure_Quality; i++)
            {
                string sn = "000000" + (no + i).ToString();
                sn = sn.Substring(sn.Length - 6);
                var k = new MeasureDetail
                {
                    MeasureDetail_ID = viewModel.MeasureMaster_ID + "-" + sn,
                    MeasureDetail_Status = ((int)SysCode.Status.正常入庫).ToString(),
                    //IsNewHilt = "Y",
                    //NewEnter_DT =CreateTime,
                    MeasureMaster_ID = viewModel.MeasureMaster_ID,
                    MeasureDetail_Create_DT = CreateTime,
                    MeasureDetail_Modify_DT = CreateTime,
                    MeasureDetail_Create_ID = viewModel.MeasureMaster_Create_ID,
                    MeasureDetail_Modify_ID = viewModel.MeasureMaster_Modify_ID
                };
                _db.MeasureDetails.Add(k);
                _db.SaveChanges();
            }
        }

        void ITM_MeasureDetail.Update(MeasureDetailViewModel viewModel)
        {

            var q = from p in _db.MeasureDetails
                    where p.MeasureDetail_ID == viewModel.MeasureDetail_ID
                    select p;
            if (q.FirstOrDefault() != null)
            {
                foreach (var p in q)
                {
                    //p.IsNewHilt = viewModel.IsNewHilt;                    
                    p.MeasureDetail_Status = viewModel.MeasureDetail_Status;
                    p.MeasureDetail_Modify_ID = viewModel.MeasureDetail_Modify_ID;
                    p.MeasureDetail_Modify_DT = viewModel.MeasureDetail_Modify_DT;

                }
                _db.SaveChanges();
            }
        }

        public DataSourceResult GridSearch(DataSourceRequest request)
        {

            var result = (from c in _db.MeasureDetails
                          join e1 in _db.Employes on c.MeasureDetail_Create_ID equals e1.Emp_ID
                        join e2 in _db.Employes on c.MeasureDetail_Modify_ID equals e2.Emp_ID
                        select new MeasureDetailViewModel
                        {

                            MeasureDetail_ID = c.MeasureDetail_ID,
                            MeasureDetail_Status = c.MeasureDetail_Status,
                            //IsNewHilt = c.IsNewHilt,
                            //NewEnter_DT = c.NewEnter_DT,                             
                            MeasureDetail_Create_DT = c.MeasureDetail_Create_DT,
                            MeasureDetail_Modify_DT = c.MeasureDetail_Modify_DT,
                            MeasureDetail_Create_Name = e1.Emp_Name,
                            MeasureDetail_Create_ID = c.MeasureDetail_Create_ID,
                            MeasureDetail_Modify_Name = e2.Emp_Name,
                            MeasureDetail_Modify_ID = c.MeasureDetail_Modify_ID
                        }).ToDataSourceResult(request);

            return result;
        }

    }


}
