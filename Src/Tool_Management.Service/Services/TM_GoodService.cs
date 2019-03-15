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
    public class TM_GoodService : ITM_Good
    {
        private ToolManagementEntities _db = new ToolManagementEntities();

        void ITM_Good.Create(GoodViewModel viewModel)
        {
            DateTime CreateTime = DateTime.Now;

            var entry = new Good
            {
                Good_ID = viewModel.Good_ID,
                Good_Name = viewModel.Good_Name,
                Good_Create_DT = CreateTime,
                Good_Modify_DT =CreateTime,
                Good_Create_ID = viewModel.Good_Create_ID,
                Good_Modify_ID  = viewModel.Good_Modify_ID
           
            };
            _db.Goods.Add(entry);
            _db.SaveChanges();
        }

        public DataSourceResult GridSearch(DataSourceRequest request)
        {

            var query = from c in _db.Goods
                        select new GoodViewModel
                        {

                            Good_ID = c.Good_ID,
                            Good_Name = c.Good_Name,
                            Good_Create_DT = c.Good_Create_DT,
                            Good_Modify_DT = c.Good_Modify_DT,
                            Good_Create_Name = new Common().GetEmployName(c.Good_Create_ID),
                            Good_Create_ID = c.Good_Create_ID,
                            Good_Modify_Name = new Common().GetEmployName(c.Good_Modify_ID),
                            Good_Modify_ID = c.Good_Modify_ID
                        };

            var result = query.ToDataSourceResult(request);
            return result;
        }

        void ITM_Good.Update(GoodViewModel viewModel)
        {
            var q = from p in _db.Goods
                    where p.Good_ID == viewModel.Good_ID
                    select p;
            if (q.FirstOrDefault() != null)
            {
                foreach (var p in q)
                {
                    p.Good_Name = viewModel.Good_Name;
                    p.Good_Modify_DT = System.DateTime.Now;
                    p.Good_Modify_ID = viewModel.Good_Modify_ID;
                }
                _db.SaveChanges();               
            }
        }


    }
}
