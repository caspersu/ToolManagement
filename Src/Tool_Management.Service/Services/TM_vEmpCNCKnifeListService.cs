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
    public class TM_vEmpCNCKnifeListService : ITM_vEmpCNCKnifeList
    {
        private ToolManagementEntities _db = new ToolManagementEntities();




        vEmpCNCKnifeListViewModel ITM_vEmpCNCKnifeList.Get(string CNC_ID,string Class_EmpID)
        {
            var result = (from c in _db.vEmpCNCKnifeLists
                          where c.CNC_ID == CNC_ID && c.Class_EmpID == Class_EmpID
                          select new vEmpCNCKnifeListViewModel
                          {
                              Planning_ID = c.Planning_ID,
                              Class_EmpID = c.Class_EmpID,
                              Class_Type = c.Class_Type,
                              Car_No = c.Car_No,
                              CNC_ID = c.CNC_ID,
                              CNC_IP = c.CNC_IP,
                              CNC_Brand = c.CNC_Brand,
                              CNC_Model = c.CNC_Model,
                              Good_Name = c.Good_Name,
                              Emp_Name = c.Emp_Name,
                              Model_Name = c.Model_Name,
                              KnifeList_ID = c.KnifeList_ID,
                              WorkStation_No = c.WorkStation_No,
                              Line_No = c.Line_No

                          }).ToList();

            if (result.Count() > 0)
            {
                string EmpName = "";
                foreach (var i in result)
                {
                    EmpName = EmpName + "," + i.Emp_Name + "(" + i.Class_Type + ")";
                }
                EmpName = EmpName.Substring(1);
                result.FirstOrDefault().Emp_Name = EmpName;
                
            }
            return result.FirstOrDefault();
        }



    }


}
