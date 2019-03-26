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
    public class TM_Collet1MasterService : ITM_Collet1Master
    {
        private ToolManagementEntities _db = new ToolManagementEntities();

        void ITM_Collet1Master.Create(Collet1MasterViewModel viewModel)
        {
            DateTime CreateTime = DateTime.Now;

            var entry = new Collet1Master
            {
                Collet1Master_ID = viewModel.Collet1Master_ID,
                Collet1_Brand = viewModel.Collet1_Brand,
                Collet1_Name = viewModel.Collet1_Name,
                Collet1_CabinID = viewModel.Collet1_CabinID,
                Collet1_Spec = viewModel.Collet1_Spec,
                Collet1_Quality = viewModel.Collet1_Quality,
                Collet1Master_Create_DT = CreateTime,
                Collet1Master_Modify_DT = CreateTime,
                Collet1Master_Create_ID = viewModel.Collet1Master_Create_ID,
                Collet1Master_Modify_ID = viewModel.Collet1Master_Modify_ID

            };
            _db.Collet1Master.Add(entry);
            _db.SaveChanges();

            //insert Collet1Detail
            int no;
            var result = _db.Collet1Detail.OrderByDescending(x => x.Collet1Detail_ID.Contains(viewModel.Collet1Master_ID)).First();
            if (result == null)
                no = 1;
            else
                no = int.Parse(result.Collet1Detail_ID.Split('-')[1]) + 1;

            for (int i = 0; i < viewModel.Collet1_Quality; i++)
            {
                string sn = "000000" + (no + i).ToString();
                sn = sn.Substring(sn.Length - 6);
                var k = new Collet1Detail
                {
                    Collet1Detail_ID = viewModel.Collet1Master_ID + "-" + sn,
                    Collet1Detail_Status = ((int)SysCode.Status.正常入庫).ToString(),
                    //IsNewCollet1 = "Y",
                    //NewEnter_DT = CreateTime,
                    Collet1Master_ID = viewModel.Collet1Master_ID,
                    Collet1Detail_Create_DT = CreateTime,
                    Collet1Detail_Modify_DT = CreateTime,
                    Collet1Detail_Create_ID = viewModel.Collet1Master_Create_ID,
                    Collet1Detail_Modify_ID = viewModel.Collet1Master_Modify_ID
                };
                _db.Collet1Detail.Add(k);
                _db.SaveChanges();
            }
        }

        void ITM_Collet1Master.Update(Collet1MasterViewModel viewModel)
        {
            
            var q = from p in _db.Collet1Master
                    where p.Collet1Master_ID == viewModel.Collet1Master_ID
                    select p;
            if (q.FirstOrDefault() != null)
            {
                foreach (var p in q)
                {
                    p.Collet1_Name = viewModel.Collet1_Name;
                    p.Collet1_CabinID = viewModel.Collet1_CabinID;
                    p.Collet1_Spec = viewModel.Collet1_Spec;
                    p.Collet1_Brand = viewModel.Collet1_Brand;                    
                    p.Collet1Master_Modify_DT = System.DateTime.Now;
                    p.Collet1Master_Modify_ID = viewModel.Collet1Master_Modify_ID;
                }
                _db.SaveChanges();
            }
        }

        public DataSourceResult GridSearch(DataSourceRequest request)
        {

            var result = (from c in _db.Collet1Master
                          join e1 in _db.Employes on c.Collet1Master_Create_ID equals e1.Emp_ID
                        join e2 in _db.Employes on c.Collet1Master_Modify_ID equals e2.Emp_ID
                        select new Collet1MasterViewModel
                        {

                            Collet1Master_ID = c.Collet1Master_ID,
                            Collet1_Brand = c.Collet1_Brand,
                            Collet1_Name = c.Collet1_Name,
                            Collet1_Spec = c.Collet1_Spec,
                            Collet1_CabinID = c.Collet1_CabinID,

                            Collet1Master_Create_DT = c.Collet1Master_Create_DT,
                            Collet1Master_Modify_DT = c.Collet1Master_Modify_DT,
                            Collet1Master_Create_Name = e1.Emp_Name,
                            Collet1Master_Create_ID = c.Collet1Master_Create_ID,
                            Collet1Master_Modify_Name = e2.Emp_Name,
                            Collet1Master_Modify_ID = c.Collet1Master_Modify_ID
                        }).ToDataSourceResult(request);


            return result;
        }

        Collet1MasterViewModel ITM_Collet1Master.Get(string id)
        {
            var result = (from c in _db.Collet1Master
                          where c.Collet1Master_ID == id
                          select new Collet1MasterViewModel
                          {
                              Collet1Master_ID = c.Collet1Master_ID,
                              Collet1_Brand = c.Collet1_Brand,
                              Collet1_CabinID = c.Collet1_CabinID,
                              Collet1_Name = c.Collet1_Name,
                              Collet1_Quality = c.Collet1_Quality,
                              Collet1_Spec = c.Collet1_Spec,
                              Collet1Master_Create_DT = c.Collet1Master_Create_DT,
                              Collet1Master_Create_ID = c.Collet1Master_Create_ID,

                              Collet1Master_Modify_DT = c.Collet1Master_Modify_DT,
                              Collet1Master_Modify_ID = c.Collet1Master_Modify_ID,


                          }).FirstOrDefault();

            return result;
        }

    }

    public class TM_Collet1DetailService : ITM_Collet1Detail
    {
        private ToolManagementEntities _db = new ToolManagementEntities();

        void ITM_Collet1Detail.Create(Collet1MasterViewModel viewModel)
        {
            DateTime CreateTime = DateTime.Now;

            //insert Collet1Detail
            int no;
            var result = _db.Collet1Detail.OrderByDescending(x => x.Collet1Detail_ID.Contains(viewModel.Collet1Master_ID)).First();
            if (result == null)
                no = 1;
            else
                no = int.Parse(result.Collet1Detail_ID.Split('-')[1]) + 1;

            for (int i = 0; i < viewModel.Collet1_Quality; i++)
            {
                string sn = "000000" + (no + i).ToString();
                sn = sn.Substring(sn.Length - 6);
                var k = new Collet1Detail
                {
                    Collet1Detail_ID = viewModel.Collet1Master_ID + "-" + sn,
                    Collet1Detail_Status = ((int)SysCode.Status.正常入庫).ToString(),
                    //IsNewCollet1 = "Y",
                    //NewEnter_DT =CreateTime,
                    Collet1Master_ID = viewModel.Collet1Master_ID,
                    Collet1Detail_Create_DT = CreateTime,
                    Collet1Detail_Modify_DT = CreateTime,
                    Collet1Detail_Create_ID = viewModel.Collet1Master_Create_ID,
                    Collet1Detail_Modify_ID = viewModel.Collet1Master_Modify_ID
                };
                _db.Collet1Detail.Add(k);
                _db.SaveChanges();
            }
        }

        void ITM_Collet1Detail.Update(Collet1DetailViewModel viewModel)
        {

            var q = from p in _db.Collet1Detail
                    where p.Collet1Detail_ID == viewModel.Collet1Detail_ID
                    select p;
            if (q.FirstOrDefault() != null)
            {
                foreach (var p in q)
                {
                    //p.IsNewCollet1 = viewModel.IsNewCollet1;                    
                    p.Collet1Detail_Status = viewModel.Collet1Detail_Status;
                    p.Collet1Detail_Modify_ID = viewModel.Collet1Detail_Modify_ID;
                    p.Collet1Detail_Modify_DT = viewModel.Collet1Detail_Modify_DT;

                }
                _db.SaveChanges();
            }
        }

        public DataSourceResult GridSearch(DataSourceRequest request)
        {

            var result = (from c in _db.Collet1Detail
                          join e1 in _db.Employes on c.Collet1Detail_Create_ID equals e1.Emp_ID
                        join e2 in _db.Employes on c.Collet1Detail_Modify_ID equals e2.Emp_ID
                        select new Collet1DetailViewModel
                        {

                            Collet1Detail_ID = c.Collet1Detail_ID,
                            Collet1Detail_Status = c.Collet1Detail_Status,
                            //IsNewCollet1 = c.IsNewCollet1,
                            //NewEnter_DT = c.NewEnter_DT,                             
                            Collet1Detail_Create_DT = c.Collet1Detail_Create_DT,
                            Collet1Detail_Modify_DT = c.Collet1Detail_Modify_DT,
                            Collet1Detail_Create_Name = e1.Emp_Name,
                            Collet1Detail_Create_ID = c.Collet1Detail_Create_ID,
                            Collet1Detail_Modify_Name = e2.Emp_Name,
                            Collet1Detail_Modify_ID = c.Collet1Detail_Modify_ID
                        }).ToDataSourceResult(request);

            return result;
        }

    }


}
