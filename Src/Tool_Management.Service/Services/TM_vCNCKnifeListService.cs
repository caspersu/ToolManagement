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
    public class TM_vCNCKnifeListService : ITM_CNCKnifeList
    {
        private ToolManagementEntities _db = new ToolManagementEntities();

        void ITM_CNCKnifeList.Create(vCNCKnifeListViewModel viewModel)
        {
            DateTime CreateTime = DateTime.Now;

            //insert CNCKnifeList
                var k = new CNCKnifeList
                {
                     CNC_ID = viewModel.CNC_ID,
                     KnifeList_ID = viewModel.ModelGoodWk,
                      Car_No = viewModel.Car_No,
                      Line_No = viewModel.Line_No,
                       WorkStation_No = viewModel.WorkStation_No,
                        CNCList_Create_DT = CreateTime,
                        CNCList_Modify_DT = CreateTime,
                        CNCList_Create_ID = viewModel.CNCList_Create_ID,
                        CNCList_Modify_ID = viewModel.CNCList_Create_ID
                };
                _db.CNCKnifeLists.Add(k);
                _db.SaveChanges();
            }
    
        public DataSourceResult GridSearch(DataSourceRequest request)
        {

            var result = (from c in _db.vCNCKnifeLists
                          join e1 in _db.Employes on c.CNCList_Create_ID equals e1.Emp_ID
                          join e2 in _db.Employes on c.CNCList_Modify_ID equals e2.Emp_ID
                          select new vCNCKnifeListViewModel
                        {
                            CNCKnifeList_ID = c.CNCKnifeList_ID,
                            Car_No = c.Car_No,
                            //CNC_Brand = c.CNC_Brand,
                            Model_ID = c.Model_ID,
                            Model_Name = c.Model_Name,
                            Good_ID = c.Good_ID,
                            Good_Name = c.Good_Name,
                            WorkStation_No = c.WorkStation_No,
                            CNC_ID = c.CNC_ID,
                            Line_No = c.Line_No,
                            KnifeList_ID = c.KnifeList_ID,
                            ModelGoodWk = c.Model_ID+"-"+c.Good_Name+"-"+c.WorkStation_No,
                             CNCList_Create_ID = c.CNCList_Create_ID,
                             CNCList_Create_DT = c.CNCList_Create_DT,
                             CNCList_Modify_ID = c.CNCList_Modify_ID,
                             CNCList_Modify_DT = c.CNCList_Modify_DT,
                             CNCList_Create_Name = e1.Emp_Name,
                             CNCList_Modify_Name = e2.Emp_Name
                        }).ToDataSourceResult(request);


            return result;
        }

        public void Update(vCNCKnifeListViewModel viewModel)
        {
            var q = from p in _db.CNCKnifeLists
                    where p.CNCKnifeList_ID == viewModel.CNCKnifeList_ID
                    select p;
            if (q.FirstOrDefault() != null)
            {
                foreach (var p in q)
                {
                    p.CNC_ID = viewModel.CNC_ID;
                    p.Line_No = viewModel.Line_No;
                    p.WorkStation_No = viewModel.WorkStation_No;
                    p.KnifeList_ID = viewModel.KnifeList_ID;
                    p.CNCList_Modify_DT = System.DateTime.Now;
                    p.CNCList_Modify_ID = viewModel.CNCList_Modify_ID;
                   
                }
                _db.SaveChanges();
            }

        }

        vCNCKnifeListViewModel ITM_CNCKnifeList.Get(string id)
        {
            var result = (from c in _db.vCNCKnifeLists
                          join e1 in _db.Employes on c.CNCList_Create_ID equals e1.Emp_ID
                          join e2 in _db.Employes on c.CNCList_Modify_ID equals e2.Emp_ID
                          where c.CNCKnifeList_ID.ToString() == id
                          select new vCNCKnifeListViewModel
                          {
                                KnifeList_ID = c.KnifeList_ID,
                                Model_ID = c.Model_ID,
                                Model_Name = c.Model_Name,
                                Good_ID = c.Good_ID,
                                Good_Name = c.Good_Name,
                                WorkStation_No = c.WorkStation_No,
                                ModelGoodWk = c.Model_ID+"-"+c.Good_ID+"-"+c.WorkStation_No,
                                CNCList_Create_DT = c.CNCList_Create_DT,
                                CNCList_Create_ID = c.CNCList_Create_ID,
                                CNCList_Create_Name = e1.Emp_Name,
                                CNCList_Modify_DT = c.CNCList_Modify_DT,
                                CNCList_Modify_ID = c.CNCList_Modify_ID,
                                CNCList_Modify_Name = e2.Emp_Name

                          }).FirstOrDefault();

            return result;
        }

        public  IList<vCNCKnifeListViewModel> GetCNCByKnifeListID(string id)
        {
            var result = (from c in _db.vCNCKnifeLists
                          where c.KnifeList_ID == id
                          select new vCNCKnifeListViewModel
                          {
                              CNC_ID = c.CNC_ID,
                              Model_ID = c.Model_ID,
                              Good_ID = c.Good_ID,
                              WorkStation_No = c.WorkStation_No,
                              KnifeList_ID = c.KnifeList_ID,
                              Good_Name = c.Good_Name,
                              Model_Name = c.Model_Name
                          }).ToList();
            return result;
        }

    }


}
