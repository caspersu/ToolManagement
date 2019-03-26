using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tool_Management.Service.Interfaces;
using Tool_Management.Service.Services;
using Tool_Management.Service.ViewModels;
using Tool_Management.Service.Utils;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.Ajax.Utilities;
using Mvc.Jsonp;

namespace Tool_Management.Controllers
{
    public class CNCKnifeListController : Controller
    {
        ITM_CNCKnifeList svc = new TM_vCNCKnifeListService();

        // GET: CNCKnifeList
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GridSearch([DataSourceRequest] DataSourceRequest request)
        {
            return Json(svc.GridSearch(request));
        }

        public ActionResult EditingPopup_Create([DataSourceRequest] DataSourceRequest request, vCNCKnifeListViewModel data)
        {

            if (data != null)
            {
                data.CNCList_Create_ID = System.Web.HttpContext.Current.Session["UserAcc"].ToString();
                data.CNCList_Modify_ID = System.Web.HttpContext.Current.Session["UserAcc"].ToString();
                svc.Create(data);
            }

            return Json(new[] { data }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult EditingPopup_Update([DataSourceRequest] DataSourceRequest request, vCNCKnifeListViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                model.CNCList_Modify_ID = System.Web.HttpContext.Current.Session["UserAcc"].ToString();
                svc.Update(model);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult GetCNC(string id)
        {
            var list = svc.GetCNCByKnifeListID(id);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}