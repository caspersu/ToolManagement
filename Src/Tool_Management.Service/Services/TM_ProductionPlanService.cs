using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Tool_Management.Service.Interfaces;
using Tool_Management.Service.Utils;
using Tool_Management.Service.ViewModels;
using Tool_Management.DataAccess;
using System.Web.Util;

namespace Tool_Management.Service.Services
{
    public class TM_ProductionPlanService : ITM_ProductionPlan
    {
        private ToolManagementEntities _db = new ToolManagementEntities();

        void ITM_ProductionPlan.Create(ProductionPlanViewModel viewModel)
        {
            DateTime CreateTime = DateTime.Now;

            //insert CNCKnifeList
                var k = new ProductionPlan
                {
                     Class_EmpID = viewModel.Class_EmpID,
                     Class_Type = viewModel.Class_Type,
                     Class_StandardPerson = viewModel.Class_StandardPerson,
                     Class_RealPerson = viewModel.Class_RealPerson,
                     KnifeList_ID =  viewModel.KnifeList_ID,                    
                     Planning_Create_ID = viewModel.Planning_Create_ID,
                     Planning_Modify_ID = viewModel.Planning_Modify_ID,
                     Planning_Create_DT = viewModel.Planning_Create_DT,
                     Planning_Modify_DT = viewModel.Planning_Modify_DT
                };
            if (string.IsNullOrEmpty(viewModel.CNCKnifeList_ID.ToString()) == false)
                k.CNCKnifeList_ID = viewModel.CNCKnifeList_ID;
                _db.ProductionPlans.Add(k);
                _db.SaveChanges();
            }
    
        public DataSourceResult GridSearch(DataSourceRequest request)
        {

            var result = (from c in _db.vProductionPlans 
                          join e1 in _db.Employes on c.Planning_Create_ID equals e1.Emp_ID
                          join e2 in _db.Employes on c.Planning_Modify_ID equals e2.Emp_ID
                          where c.CNCKnifeList_ID == null 
                          select new ProductionPlanViewModel
                          {
                              //CNCKnifeList_ID = c.CNCKnifeList_ID,
                              Class_EmpID = c.Class_EmpID,
                              Class_Type = c.Class_Type,
                              Class_StandardPerson = c.Class_StandardPerson,
                              Class_RealPerson = c.Class_RealPerson,
                              KnifeList_ID = c.KnifeList_ID,
                              Planning_ID  = c.Planning_ID,
                            ModelGoodWk = c.Model_ID+"-"+c.Good_Name+"-"+c.WorkStation_No,
                            Planning_Create_ID = c.Planning_Create_ID,
                            Planning_Create_DT = c.Planning_Create_DT,
                            Planning_Create_Name = e1.Emp_Name,
                            Planning_Modify_ID = c.Planning_Modify_ID,
                            Planning_Modify_DT = c.Planning_Modify_DT,
                            Planning_Modify_Name = e2.Emp_Name
                     
                        }).ToDataSourceResult(request);


            return result;
        }

        public void Update(ProductionPlanViewModel viewModel)
        {
            var q = (from p in _db.ProductionPlans
                    where p.Planning_ID == viewModel.Planning_ID
                    select p).First();

            var w = from x in _db.ProductionPlans where x.KnifeList_ID == q.KnifeList_ID && x.Class_EmpID == q.Class_EmpID select x;

            if (w.FirstOrDefault() != null)
            {
                foreach (var p in w)
                {
                    p.Class_EmpID = viewModel.Class_EmpID;
                    p.Class_RealPerson = viewModel.Class_RealPerson;
                    p.Class_StandardPerson = viewModel.Class_StandardPerson;
                    p.KnifeList_ID = viewModel.KnifeList_ID;
                    p.Class_Type = viewModel.Class_Type;
                
                    p.Planning_Modify_DT = System.DateTime.Now;
                    p.Planning_Modify_ID = viewModel.Planning_Modify_ID;
                }
                _db.SaveChanges();
            }

        }
        
        ProductionPlanViewModel ITM_ProductionPlan.Get(string Planning_ID)
        {
            var result = (from c in _db.ProductionPlans
                          join e1 in _db.Employes on c.Planning_Create_ID equals e1.Emp_ID
                          join e2 in _db.Employes on c.Planning_Modify_ID equals e2.Emp_ID
                          where c.Planning_ID.ToString() == Planning_ID
                          select new ProductionPlanViewModel
                          {
                                Planning_ID = c.Planning_ID,
                                Class_EmpID = c.Class_EmpID,
                                Class_Type = c.Class_Type,
                                Class_RealPerson = c.Class_RealPerson,
                                Class_StandardPerson = c.Class_StandardPerson,                                 
                                KnifeList_ID = c.KnifeList_ID,
                                CNCKnifeList_ID = c.CNCKnifeList_ID,
                                Planning_Create_DT = c.Planning_Create_DT,                                        
                                Planning_Create_ID = c.Planning_Create_ID,
                                Planning_Create_Name = e1.Emp_Name,
                                Planning_Modify_DT = c.Planning_Modify_DT,
                                Planning_Modify_ID = c.Planning_Modify_ID,
                                Planning_Modify_Name = e2.Emp_Name

                          }).FirstOrDefault();

            return result;
        }

        ProductionPlanViewModel ITM_ProductionPlan.Get(string Class_EmpID,string KnifeList_ID)
        {
            var result = (from c in _db.ProductionPlans
                          join e1 in _db.Employes on c.Planning_Create_ID equals e1.Emp_ID
                          join e2 in _db.Employes on c.Planning_Modify_ID equals e2.Emp_ID
                          where c.Class_EmpID == Class_EmpID && c.KnifeList_ID == KnifeList_ID
                          select new ProductionPlanViewModel
                          {
                              Planning_ID = c.Planning_ID,
                              Class_EmpID = c.Class_EmpID,
                              Class_Type = c.Class_Type,
                              Class_RealPerson = c.Class_RealPerson,
                              Class_StandardPerson = c.Class_StandardPerson,
                              KnifeList_ID = c.KnifeList_ID,

                              Planning_Create_DT = c.Planning_Create_DT,
                              Planning_Create_ID = c.Planning_Create_ID,
                              Planning_Create_Name = e1.Emp_Name,
                              Planning_Modify_DT = c.Planning_Modify_DT,
                              Planning_Modify_ID = c.Planning_Modify_ID,
                              Planning_Modify_Name = e2.Emp_Name

                          }).FirstOrDefault();

            return result;
        }

        public DataSourceResult GridCNCSearchUnSelect(DataSourceRequest request,string Class_EmpID,string KnifeList_ID)
        {

            var result = (from c in _db.vCNCKnifeLists 
                          where !(from d in _db.vEmpCNCKnifeLists where d.KnifeList_ID == KnifeList_ID && d.Class_EmpID==Class_EmpID  select d.CNCKnifeList_ID) .Contains(c.CNCKnifeList_ID)                              
                          select new vCNCKnifeListViewModel
                          {
                              CNCKnifeList_ID = c.CNCKnifeList_ID,
                              CNC_ID = c.CNC_ID,
                              CNC_IP = c.CNC_IP,
 

                          }).ToDataSourceResult(request);


            return result;
        }

        public DataSourceResult GridCNCSearchSelect(DataSourceRequest request, string Class_EmpID, string KnifeList_ID)
        {

            var result = (from c in _db.vEmpCNCKnifeLists
                           where c.KnifeList_ID == KnifeList_ID && c.Class_EmpID == Class_EmpID 
                          select new vEmpCNCKnifeListViewModel
                          {
                             CNCKnifeList_ID = c.CNCKnifeList_ID,
                              CNC_ID = c.CNC_ID,
                              CNC_IP = c.CNC_IP,
                              Planning_ID = c.Planning_ID

                          }).ToDataSourceResult(request);


            return result;
        }

        void ITM_ProductionPlan.Delete(string id)
        {
            var entry = new ProductionPlan { Planning_ID = decimal.Parse(id) };
            _db.ProductionPlans.Attach(entry);
            _db.ProductionPlans.Remove(entry);
            _db.SaveChanges();

        }


    }


}
