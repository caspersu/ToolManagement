using Kendo.Mvc.UI;
using Tool_Management.Service.ViewModels;


namespace Tool_Management.Service.Interfaces
{
    public interface ITM_vKind
    {
        //vKindViewModel Get(string id);

        DataSourceResult GridSearch(DataSourceRequest request);
    }

}
