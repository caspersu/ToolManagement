using Kendo.Mvc.UI;
using Tool_Management.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.Interfaces
{
    public interface ITM_Collet1Master
    {
        DataSourceResult GridSearch(DataSourceRequest request);

        void Update(Collet1MasterViewModel viewModel);

        void Create(Collet1MasterViewModel viewModel);
        Collet1MasterViewModel Get(string id);
    }

    public interface ITM_Collet1Detail
    {
        DataSourceResult GridSearch(DataSourceRequest request);

        void Update(Collet1DetailViewModel viewModel);

        void Create(Collet1MasterViewModel viewModel);
    }


}
