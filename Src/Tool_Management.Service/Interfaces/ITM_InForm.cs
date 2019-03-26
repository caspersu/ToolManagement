using Kendo.Mvc.UI;
using Tool_Management.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.Interfaces
{
    public interface ITM_InForm
    {
        void KnifeInFormCreate(KnifeInFormViewModel viewModel);
        void KnifeInFormDelete(KnifeInFormViewModel viewModel);
        void KnifeStatusSave(string InForm_ID);
        DataSourceResult KnifeInFormGridSearch(DataSourceRequest request,string InForm_ID);
        void HiltInFormCreate(HiltInFormViewModel viewModel);
        void HiltInFormDelete(HiltInFormViewModel viewModel);
        void HiltStatusSave(string InForm_ID);
    }

}
