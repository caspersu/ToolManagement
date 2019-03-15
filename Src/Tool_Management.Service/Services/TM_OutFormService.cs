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
    public class TM_OutFormService : ITM_OutForm
    {
        private ToolManagementEntities _db = new ToolManagementEntities();

        void ITM_OutForm.Create(OutFormViewModel viewModel)
        {
            DateTime CreateTime = DateTime.Now;

            var entry = new OutFrom
            {
                Detail_ID = viewModel.Detail_ID,
                OutForm_ID = viewModel.OutForm_ID,
                Out_EmpID = viewModel.Out_EmpID,
                Confirm_EmpID = viewModel.Confirm_EmpID,
                DetailID_Type = viewModel.DetailID_Type,
                Out_DT = DateTime.Parse(viewModel.Out_DT),
                OutForm_Create_DT = CreateTime.ToString("yyyy/MM/dd HH:mm:ss"),
                OutForm_Modify_DT =CreateTime.ToString("yyyy/MM/dd HH:mm:ss"),
                OutForm_Create_ID = viewModel.OutForm_Create_ID,
                OutForm_Modify_ID = viewModel.OutForm_Modify_ID

            };
            _db.OutFroms.Add(entry);
            _db.SaveChanges();
        }




    }
}
