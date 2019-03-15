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
    public class TM_ModelService : ITM_Model
    {
        private ToolManagementEntities _db = new ToolManagementEntities();

        void ITM_Model.Create(ModelViewModel viewModel)
        {
            DateTime CreateTime = DateTime.Now;

            var entry = new Model
            {
                Model_ID = viewModel.Model_ID,
                Model_Name = viewModel.Model_Name,
                Model_Create_DT = CreateTime,
                Model_Modify_DT =CreateTime,
                Model_Create_ID = viewModel.Model_Create_ID,
                Model_Modify_ID  = viewModel.Model_Modify_ID
           
            };
            _db.Models.Add(entry);
            _db.SaveChanges();
        }

        public DataSourceResult GridSearch(DataSourceRequest request)
        {

            var result = (from c in _db.Models 
                          join e1 in _db.Employes on c.Model_Create_ID equals e1.Emp_ID
                          join e2 in _db.Employes on c.Model_Modify_ID equals e2.Emp_ID
                        select new ModelViewModel
                        {

                            Model_ID = c.Model_ID,
                            Model_Name = c.Model_Name,
                            Model_Create_DT = c.Model_Create_DT,
                            Model_Modify_DT = c.Model_Modify_DT,
                            Model_Create_Name = e1.Emp_Name,
                            Model_Create_ID = c.Model_Create_ID,
                            Model_Modify_Name = e2.Emp_Name,
                            Model_Modify_ID = c.Model_Modify_ID
                        }).ToDataSourceResult(request);

            return result;
        }




        void ITM_Model.Update(ModelViewModel viewModel)
        {
            var q = from p in _db.Models
                    where p.Model_ID == viewModel.Model_ID
                    select p;
            if (q.FirstOrDefault() != null)
            {
                foreach (var p in q)
                {
                    p.Model_Name = viewModel.Model_Name;
                    p.Model_Modify_DT = System.DateTime.Now;
                    p.Model_Modify_ID = viewModel.Model_Modify_ID;
                }
                _db.SaveChanges();               
            }
        }




    }
}
