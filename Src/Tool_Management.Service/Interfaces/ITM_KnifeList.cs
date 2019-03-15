using Kendo.Mvc.UI;
using Tool_Management.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.Interfaces
{
    public interface ITM_KnifeList
    {
        vKnifeListViewModel Get(string id);

        void Create(vKnifeListViewModel viewModel);

        void CreateATC(KnifeListViewModel viewModel);

        void DeleteKnifeList(string id);

        void DeleteATC(string id, string atc_id);

        void UpdateKnifeList(vKnifeListViewModel viewModel);

        void UpdateATC(KnifeListViewModel viewModel);

        DataSourceResult GridSearch(DataSourceRequest request);

        DataSourceResult GridATC(DataSourceRequest request,string id);

        KnifeListViewModel GetATC(string id, string atc_id);
    }

}
