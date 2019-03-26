using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kendo.Mvc.UI;
using Tool_Management.DataAccess;
using Tool_Management.Service.Interfaces;
using Tool_Management.Service.ViewModels;
using Tool_Management.Service.Utils;
using Kendo.Mvc.Extensions;

namespace Tool_Management.Service.Services
{
    public class TM_StockService : ITM_Stock
    {
        private ToolManagementEntities _db = new ToolManagementEntities();

        //寫入庫存明細
        void ITM_Stock.Create(StockDetailViewModel viewModel)
        {
            //DateTime CreateTime = DateTime.Now;

            var entry = new StockDetail
            {
                MasterID_Type = viewModel.MasterID_Type,
                Detail_ID = viewModel.Detail_ID,
                Master_ID = viewModel.Master_ID,
                Bound_Type = viewModel.Bound_Type,
                Memo = viewModel.Memo,
                StcokDetail_Create_DT = viewModel.StockDetail_Create_DT,
                StockDetail_Create_ID = viewModel.StockDetail_Create_ID
            };
            _db.StockDetails.Add(entry);
            _db.SaveChanges();
        }

        List<KnifeDetailViewModel> ITM_Stock.KnifeOutQuantity(string KnifeMasterID)
        {
            var result = (from c in _db.KnifeDetails
                          where (c.KnifeDetail_Status == "3" || c.KnifeDetail_Status == "4")
                          select new KnifeDetailViewModel
                          {
                              KnifeMaster_ID = c.KnifeMaster_ID,
                              KnifeDetail_ID = c.KnifeDetail_ID,
                              KnifeDetail_Status = c.KnifeDetail_Status
                          }).ToList();
            return result;
        }  

    }
}
