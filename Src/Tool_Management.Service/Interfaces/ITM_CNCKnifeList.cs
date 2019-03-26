using Kendo.Mvc.UI;
using System.Collections.Generic;
using Tool_Management.Service.ViewModels;


namespace Tool_Management.Service.Interfaces
{
    public interface ITM_CNCKnifeList
    {
        vCNCKnifeListViewModel Get(string id);

        DataSourceResult GridSearch(DataSourceRequest request);
        void Create(vCNCKnifeListViewModel viewModel);
        void Update(vCNCKnifeListViewModel viewModel);
        IList<vCNCKnifeListViewModel> GetCNCByKnifeListID(string id);
    }
}
