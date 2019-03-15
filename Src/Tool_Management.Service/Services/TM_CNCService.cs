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
    public class TM_CNCService : ITM_CNC
    {
        private ToolManagementEntities _db = new ToolManagementEntities();

        void ITM_CNC.Create(CNCViewModel viewModel)
        {
            DateTime CreateTime = DateTime.Now;

            var entry = new CNC
            {
                CNC_ID = viewModel.CNC_ID,
                CNC_IP = viewModel.CNC_IP,
                CNC_Name = viewModel.CNC_Name,
                CNC_Brand = viewModel.CNC_Brand,

                CNC_Create_DT = CreateTime,
                CNC_Modify_DT = CreateTime,
                CNC_Create_ID = viewModel.CNC_Create_ID,
                CNC_Modify_ID = viewModel.CNC_Modify_ID

            };
            _db.CNCs.Add(entry);
            _db.SaveChanges();
        }

        void ITM_CNC.Update(CNCViewModel viewModel)
        {
            var q = from p in _db.CNCs
                    where p.CNC_IP == viewModel.CNC_IP
                    select p;
            if (q.FirstOrDefault() != null)
            {
                foreach (var p in q)
                {
                    p.CNC_Name = viewModel.CNC_Name;
                    p.CNC_Modify_DT = System.DateTime.Now;
                    p.CNC_Modify_ID = viewModel.CNC_Modify_ID;
                }
                _db.SaveChanges();
            }
        }

        public DataSourceResult GridSearch(DataSourceRequest request)
        {

            var result = (from c in _db.CNCs
                        join e1 in _db.Employes on c.CNC_Create_ID equals e1.Emp_ID
                        join e2 in _db.Employes on c.CNC_Modify_ID equals e2.Emp_ID
                        select new CNCViewModel
                        {

                            CNC_ID = c.CNC_ID,
                            CNC_IP = c.CNC_IP,
                            CNC_Name = c.CNC_Name,
                            CNC_Brand = c.CNC_Brand,
                            CNC_Create_DT = c.CNC_Create_DT,
                            CNC_Modify_DT = c.CNC_Modify_DT,
                            CNC_Create_Name = e1.Emp_Name,
                           CNC_Create_ID = c.CNC_Create_ID,
                            CNC_Modify_Name = e2.Emp_Name,
                            CNC_Modify_ID = c.CNC_Modify_ID
                        }).ToDataSourceResult(request);;

     
            return result;
        }

    }
}
