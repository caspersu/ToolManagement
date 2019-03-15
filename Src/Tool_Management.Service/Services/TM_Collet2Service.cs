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
    public class TM_Collet2MasterService : ITM_Collet2Master
    {
        private ToolManagementEntities _db = new ToolManagementEntities();

        void ITM_Collet2Master.Create(Collet2MasterViewModel viewModel)
        {
            DateTime CreateTime = DateTime.Now;

            var entry = new Collet2Master
            {
                Collet2Master_ID = viewModel.Collet2Master_ID,
                Collet2_Brand = viewModel.Collet2_Brand,
                Collet2_Name = viewModel.Collet2_Name,
                Collet2_CabinID = viewModel.Collet2_CabinID,
                Collet2_Spec = viewModel.Collet2_Spec,
                Collet2_Quality = viewModel.Collet2_Quality,
                Collet2Master_Create_DT = CreateTime,
                Collet2Master_Modify_DT = CreateTime,
                Collet2Master_Create_ID = viewModel.Collet2Master_Create_ID,
                Collet2Master_Modify_ID = viewModel.Collet2Master_Modify_ID

            };
            _db.Collet2Master.Add(entry);
            _db.SaveChanges();

            //insert HiltDetail
            int no;
            var result = _db.Collet2Detail.OrderByDescending(x => x.Collet2Detail_ID.Contains(viewModel.Collet2Master_ID)).First();
            if (result == null)
                no = 1;
            else
                no = int.Parse(result.Collet2Detail_ID.Split('-')[1]) + 1;

            for (int i = 0; i < viewModel.Collet2_Quality; i++)
            {
                string sn = "000000" + (no + i).ToString();
                sn = sn.Substring(sn.Length - 6);
                var k = new Collet2Detail
                {
                    Collet2Detail_ID = viewModel.Collet2Master_ID + "-" + sn,
                    Collet2Detail_Status = ((int)SysCode.Status.正常入庫).ToString(),
                    //IsNewHilt = "Y",
                    //NewEnter_DT = CreateTime,
                    Collet2Master_ID = viewModel.Collet2Master_ID,
                    Collet2Detail_Create_DT = CreateTime,
                    Collet2Detail_Modify_DT = CreateTime,
                    Collet2Detail_Create_ID = viewModel.Collet2Master_Create_ID,
                    Collet2Detail_Modify_ID = viewModel.Collet2Master_Modify_ID
                };
                _db.Collet2Detail.Add(k);
                _db.SaveChanges();
            }
        }

        void ITM_Collet2Master.Update(Collet2MasterViewModel viewModel)
        {
            
            var q = from p in _db.Collet2Master
                    where p.Collet2Master_ID == viewModel.Collet2Master_ID
                    select p;
            if (q.FirstOrDefault() != null)
            {
                foreach (var p in q)
                {
                    p.Collet2_Name = viewModel.Collet2_Name;
                    p.Collet2_CabinID = viewModel.Collet2_CabinID;
                    p.Collet2_Spec = viewModel.Collet2_Spec;
                    p.Collet2_Brand = viewModel.Collet2_Brand;                    
                    p.Collet2Master_Modify_DT = System.DateTime.Now;
                    p.Collet2Master_Modify_ID = viewModel.Collet2Master_Modify_ID;
                }
                _db.SaveChanges();
            }
        }

        public DataSourceResult GridSearch(DataSourceRequest request)
        {

            var result = (from c in _db.Collet2Master
                          join e1 in _db.Employes on c.Collet2Master_Create_ID equals e1.Emp_ID
                        join e2 in _db.Employes on c.Collet2Master_Modify_ID equals e2.Emp_ID
                        select new Collet2MasterViewModel
                        {

                            Collet2Master_ID = c.Collet2Master_ID,
                            Collet2_Brand = c.Collet2_Brand,
                            Collet2_Name = c.Collet2_Name,
                            Collet2_Spec = c.Collet2_Spec,
                            Collet2_CabinID = c.Collet2_CabinID,

                            Collet2Master_Create_DT = c.Collet2Master_Create_DT,
                            Collet2Master_Modify_DT = c.Collet2Master_Modify_DT,
                            Collet2Master_Create_Name = e1.Emp_Name,
                            Collet2Master_Create_ID = c.Collet2Master_Create_ID,
                            Collet2Master_Modify_Name = e2.Emp_Name,
                            Collet2Master_Modify_ID = c.Collet2Master_Modify_ID
                        }).ToDataSourceResult(request);


            return result;
        }

    }

    public class TM_Collet2DetailService : ITM_Collet2Detail
    {
        private ToolManagementEntities _db = new ToolManagementEntities();

        void ITM_Collet2Detail.Create(Collet2MasterViewModel viewModel)
        {
            DateTime CreateTime = DateTime.Now;

            //insert Collet2Detail
            int no;
            var result = _db.Collet2Detail.OrderByDescending(x => x.Collet2Detail_ID.Contains(viewModel.Collet2Master_ID)).First();
            if (result == null)
                no = 1;
            else
                no = int.Parse(result.Collet2Detail_ID.Split('-')[1]) + 1;

            for (int i = 0; i < viewModel.Collet2_Quality; i++)
            {
                string sn = "000000" + (no + i).ToString();
                sn = sn.Substring(sn.Length - 6);
                var k = new Collet2Detail
                {
                    Collet2Detail_ID = viewModel.Collet2Master_ID + "-" + sn,
                    Collet2Detail_Status = ((int)SysCode.Status.正常入庫).ToString(),
                    //IsNewHilt = "Y",
                    //NewEnter_DT =CreateTime,
                    Collet2Master_ID = viewModel.Collet2Master_ID,
                    Collet2Detail_Create_DT = CreateTime,
                    Collet2Detail_Modify_DT = CreateTime,
                    Collet2Detail_Create_ID = viewModel.Collet2Master_Create_ID,
                    Collet2Detail_Modify_ID = viewModel.Collet2Master_Modify_ID
                };
                _db.Collet2Detail.Add(k);
                _db.SaveChanges();
            }
        }

        void ITM_Collet2Detail.Update(Collet2DetailViewModel viewModel)
        {

            var q = from p in _db.Collet2Detail
                    where p.Collet2Detail_ID == viewModel.Collet2Detail_ID
                    select p;
            if (q.FirstOrDefault() != null)
            {
                foreach (var p in q)
                {
                    //p.IsNewHilt = viewModel.IsNewHilt;                    
                    p.Collet2Detail_Status = viewModel.Collet2Detail_Status;
                    p.Collet2Detail_Modify_ID = viewModel.Collet2Detail_Modify_ID;
                    p.Collet2Detail_Modify_DT = viewModel.Collet2Detail_Modify_DT;

                }
                _db.SaveChanges();
            }
        }

        public DataSourceResult GridSearch(DataSourceRequest request)
        {

            var result = (from c in _db.Collet2Detail
                          join e1 in _db.Employes on c.Collet2Detail_Create_ID equals e1.Emp_ID
                        join e2 in _db.Employes on c.Collet2Detail_Modify_ID equals e2.Emp_ID
                        select new Collet2DetailViewModel
                        {

                            Collet2Detail_ID = c.Collet2Detail_ID,
                            Collet2Detail_Status = c.Collet2Detail_Status,
                            //IsNewHilt = c.IsNewHilt,
                            //NewEnter_DT = c.NewEnter_DT,                             
                            Collet2Detail_Create_DT = c.Collet2Detail_Create_DT,
                            Collet2Detail_Modify_DT = c.Collet2Detail_Modify_DT,
                            Collet2Detail_Create_Name = e1.Emp_Name,
                            Collet2Detail_Create_ID = c.Collet2Detail_Create_ID,
                            Collet2Detail_Modify_Name = e2.Emp_Name,
                            Collet2Detail_Modify_ID = c.Collet2Detail_Modify_ID
                        }).ToDataSourceResult(request);

            return result;
        }

    }


}
