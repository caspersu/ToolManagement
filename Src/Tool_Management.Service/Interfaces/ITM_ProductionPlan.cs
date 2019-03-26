using Kendo.Mvc.UI;
using Tool_Management.Service.ViewModels;


namespace Tool_Management.Service.Interfaces
{
    public interface ITM_ProductionPlan
    {
        ProductionPlanViewModel Get(string Planning_ID);

        DataSourceResult GridSearch(DataSourceRequest request);
        void Create(ProductionPlanViewModel viewModel);

        void Update(ProductionPlanViewModel viewModel);

        DataSourceResult GridCNCSearchUnSelect(DataSourceRequest request, string Class_EmpID,string KnifeList_ID);

        DataSourceResult GridCNCSearchSelect(DataSourceRequest request, string Class_EmpID, string KnifeList_ID);

        ProductionPlanViewModel Get(string Class_EmpID, string KnifeList_ID);
        void Delete(string v);
    }

}
