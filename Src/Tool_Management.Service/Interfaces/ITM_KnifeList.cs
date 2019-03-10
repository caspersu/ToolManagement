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
        KnifeListViewModel Get(string id);

        void Create(KnifeListViewModel viewModel);

        void Delete(string id);

        void Update(KnifeListViewModel viewModel);

        DataSourceResult GridSearch(DataSourceRequest request);
    }

}
