using Kendo.Mvc.UI;
using Tool_Management.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.Interfaces
{
    public interface ITM_Collet2Master
    {
        DataSourceResult GridSearch(DataSourceRequest request);

        void Update(Collet2MasterViewModel viewModel);

        void Create(Collet2MasterViewModel viewModel);
    }

    public interface ITM_Collet2Detail
    {
        DataSourceResult GridSearch(DataSourceRequest request);

        void Update(Collet2DetailViewModel viewModel);

        void Create(Collet2MasterViewModel viewModel);
    }


}
