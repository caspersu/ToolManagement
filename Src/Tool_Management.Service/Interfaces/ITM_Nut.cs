using Kendo.Mvc.UI;
using Tool_Management.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.Interfaces
{
    public interface ITM_NutMaster
    {
        DataSourceResult GridSearch(DataSourceRequest request);

        void Update(NutMasterViewModel viewModel);

        void Create(NutMasterViewModel viewModel);
    }

    public interface ITM_NutDetail
    {
        DataSourceResult GridSearch(DataSourceRequest request);

        void Update(NutDetailViewModel viewModel);

        void Create(NutMasterViewModel viewModel);
    }


}
