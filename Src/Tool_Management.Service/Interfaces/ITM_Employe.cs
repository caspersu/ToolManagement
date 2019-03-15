using Kendo.Mvc.UI;
using Tool_Management.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.Interfaces
{
    public interface ITM_Employe
    {
        DataSourceResult GridSearch(DataSourceRequest request);

        void Update(EmployeViewModel viewModel);

        void Create(EmployeViewModel viewModel);
    }

}
