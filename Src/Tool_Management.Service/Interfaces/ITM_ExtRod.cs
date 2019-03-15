using Kendo.Mvc.UI;
using Tool_Management.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.Interfaces
{
    public interface ITM_ExtRodMaster
    {
        DataSourceResult GridSearch(DataSourceRequest request);

        void Update(ExtRodMasterViewModel viewModel);

        void Create(ExtRodMasterViewModel viewModel);
    }

    public interface ITM_ExtRodDetail
    {
        DataSourceResult GridSearch(DataSourceRequest request);

        void Update(ExtRodDetailViewModel viewModel);

        void Create(ExtRodMasterViewModel viewModel);
    }


}
