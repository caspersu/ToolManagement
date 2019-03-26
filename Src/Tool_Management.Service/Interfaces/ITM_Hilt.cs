using Kendo.Mvc.UI;
using Tool_Management.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.Interfaces
{
    public interface ITM_HiltMaster
    {
        DataSourceResult GridSearch(DataSourceRequest request);

        void Update(HiltMasterViewModel viewModel);

        void Create(HiltMasterViewModel viewModel);
        HiltMasterViewModel Get(string id);
    }

    public interface ITM_HiltDetail
    {
        DataSourceResult GridSearch(DataSourceRequest request);

        void Update(HiltDetailViewModel viewModel);

        void Create(HiltMasterViewModel viewModel);
    }


}
