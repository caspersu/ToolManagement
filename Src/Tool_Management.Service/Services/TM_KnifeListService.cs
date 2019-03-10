using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Tool_Management.Service.Interfaces;
using Tool_Management.Service.ViewModels;
using Tool_Management.DataAccess;

namespace Tool_Management.Service.Services
{
    public class TM_KnifeListService : ITM_KnifeList
    {
        private ToolManagementEntities _db = new ToolManagementEntities();

        public void Create(KnifeListViewModel viewModel)
        {
            DateTime CreateTime = System.DateTime.Now;
            var entry = new KnifeList
            {
                KnifeList_ID = ""
            };
            _db.KnifeLists.Add(entry);
            _db.SaveChanges();
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public KnifeListViewModel Get(string id)
        {
            throw new NotImplementedException();
        }

        public DataSourceResult GridSearch(DataSourceRequest request)
        {
            throw new NotImplementedException();
        }

        public void Update(KnifeListViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public string GetKnifeListID()
        {
            string yyyyMMdd = DateTime.Now.ToString("yyyyMMdd");
            string sn="";
            var result = _db.KnifeLists.OrderByDescending(x => x.KnifeList_ID.Contains(yyyyMMdd)).First();
            if (result == null)
                sn = yyyyMMdd + "000001";
            else
                sn = (int.Parse(result.KnifeList_ID) + 1).ToString();
            return sn ;
        }
    }
}
