using Kendo.Mvc.UI;
using Tool_Management.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.Interfaces
{
    public interface ITM_NailMaster
    {
        DataSourceResult GridSearch(DataSourceRequest request);

        void Update(NailMasterViewModel viewModel);

        void Create(NailMasterViewModel viewModel);
    }

    public interface ITM_NailDetail
    {
        DataSourceResult GridSearch(DataSourceRequest request);

        void Update(NailDetailViewModel viewModel);

        void Create(NailMasterViewModel viewModel);
    }


}
