using Kendo.Mvc.UI;
using Tool_Management.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.Interfaces
{
    public interface ITM_Model
    {
        DataSourceResult GridSearch(DataSourceRequest request);

        void Update(ModelViewModel viewModel);

        void Create(ModelViewModel viewModel);
    }

}
