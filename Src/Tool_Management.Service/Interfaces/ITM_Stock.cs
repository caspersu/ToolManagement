using Kendo.Mvc.UI;
using Tool_Management.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.Interfaces
{
    public interface ITM_Stock
    {

       void Create(StockDetailViewModel viewModel);
        List<KnifeDetailViewModel> KnifeOutQuantity(string KnifeMasterID);       
    }




}
