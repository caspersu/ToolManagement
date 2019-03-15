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
    public class TM_CNCMonitorService : ITM_CNCMonitor
    {
        private ToolManagementEntities _db = new ToolManagementEntities();



        public DataSourceResult GridSearch(DataSourceRequest request)
        {

            var result = (from c in _db.vCNC_Monitor
                        select new vCNC_MonitorViewModel
                        {

                            CNC_ID = c.CNC_ID,
                            CNC_IP = c.CNC_IP,
                            CNC_Name = c.CNC_Name,
                            CNC_Model = c.CNC_Model,
                            CNC_Ver  = c.CNC_Ver,
                            CNC_Brand = c.CNC_Brand,
                            CNC_Current_ProductionAmount = c.CNC_Current_ProductionAmount.ToString(),
                            CNC_Current_Status = c.CNC_Current_Status,
                            CNC_Current_StatusDT = c.CNC_Current_StatusDT,
                            Create_DT = c.Create_DT

                        }).ToDataSourceResult(request);;

     
            return result;
        }

    }
}
