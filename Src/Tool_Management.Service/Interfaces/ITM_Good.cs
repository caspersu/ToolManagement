using Kendo.Mvc.UI;
using Tool_Management.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tool_Management.Service.Interfaces
{
    public interface ITM_Good
    {
        DataSourceResult GridSearch(DataSourceRequest request);

        void Update(GoodViewModel viewModel);

        void Create(GoodViewModel viewModel);
    }

}
