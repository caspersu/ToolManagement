using Kendo.Mvc.UI;
using Tool_Management.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.Interfaces
{
    public interface ITM_MeasureMaster
    {
        DataSourceResult GridSearch(DataSourceRequest request);

        void Update(MeasureMasterViewModel viewModel);

        void Create(MeasureMasterViewModel viewModel);
    }

    public interface ITM_MeasureDetail
    {
        DataSourceResult GridSearch(DataSourceRequest request);

        void Update(MeasureDetailViewModel viewModel);

        void Create(MeasureMasterViewModel viewModel);
    }


}
