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
using Tool_Management.Service.ViewModels;
using Tool_Management.DataAccess;

namespace Tool_Management.Service.Services
{
    public class TM_vKindService : ITM_vKind
    {
        private ToolManagementEntities _db = new ToolManagementEntities();

        public DataSourceResult GridSearch(DataSourceRequest request)
        {
            var result = (from c in _db.v_Kind
                          select new vKindViewModel
                          {
                             
                              Kind = c.Kind,
                              ID = c.ID,
                              Name = c.Name
                          }).ToDataSourceResult(request);

            return result;
        }

    }
}
