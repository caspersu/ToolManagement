using Kendo.Mvc.UI;
using Tool_Management.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.Interfaces
{
    public interface ITM_KnifeMaster
    {
        DataSourceResult GridSearch(DataSourceRequest request);

        void Update(KnifeMasterViewModel viewModel);

        void Create(KnifeMasterViewModel viewModel);
    }

    public interface ITM_KnifeDetail
    {
        DataSourceResult GridSearch(DataSourceRequest request);

        void Update(KnifeDetailViewModel viewModel);

        void Create(KnifeMasterViewModel viewModel);
    }


}
