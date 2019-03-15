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
    public class TM_EmployeService : ITM_Employe
    {
        private ToolManagementEntities _db = new ToolManagementEntities();

        void ITM_Employe.Create(EmployeViewModel viewModel)
        {
            DateTime CreateTime = DateTime.Now;

            var entry = new Employe
            {
                Emp_ID = viewModel.Emp_ID,
                Emp_Name = viewModel.Emp_Name,
                Emp_Status = viewModel.Emp_Status,
                 
                Emp_Create_DT = CreateTime,
                Emp_Modify_DT = CreateTime,
                Emp_Create_ID = viewModel.Emp_Create_ID,
                Emp_Modify_ID = viewModel.Emp_Modify_ID

            };
            _db.Employes.Add(entry);
            _db.SaveChanges();
        }

        void ITM_Employe.Update(EmployeViewModel viewModel)
        {
            var q = from p in _db.Employes
                    where p.Emp_ID == viewModel.Emp_ID
                    select p;
            if (q.FirstOrDefault() != null)
            {
                foreach (var p in q)
                {
                    p.Emp_Name = viewModel.Emp_Name;
                    p.Emp_Status = viewModel.Emp_Status;
                    p.Emp_Modify_DT = System.DateTime.Now;
                    p.Emp_Modify_ID = viewModel.Emp_Modify_ID;
                }
                _db.SaveChanges();
            }
        }

        public DataSourceResult GridSearch(DataSourceRequest request)
        {

            var result = (from c in _db.Employes
                        join e1 in _db.Employes on c.Emp_Create_ID equals e1.Emp_ID
                        join e2 in _db.Employes on c.Emp_Modify_ID equals e2.Emp_ID
                        select new EmployeViewModel
                        {

                            Emp_ID = c.Emp_ID,
                            Emp_Name = c.Emp_Name,
                            Emp_Status =( c.Emp_Status == "Y") ? "啟用" : "未啟用",
                            Emp_Create_DT = c.Emp_Create_DT,
                            Emp_Modify_DT = c.Emp_Modify_DT,
                            Emp_Create_Name = e1.Emp_Name,
                            Emp_Create_ID = c.Emp_Create_ID,
                            Emp_Modify_Name = e2.Emp_Name,
                            Emp_Modify_ID = c.Emp_Modify_ID
                        }).ToDataSourceResult(request);;

     
            return result;
        }

    }
}
