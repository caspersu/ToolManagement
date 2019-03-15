using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tool_Management.Service.Interfaces;
using Tool_Management.Service.Services;
using Tool_Management.Service.ViewModels;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace Tool_Management.Controllers
{
    public class NailController : Controller
    {
        ITM_NailMaster svc = new TM_NailMasterService();

        // GET: Nail
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GridSearch([DataSourceRequest] DataSourceRequest request)
        {
            return Json(svc.GridSearch(request));
        }

        public ActionResult EditingPopup_Create([DataSourceRequest] DataSourceRequest request, NailMasterViewModel data)
        {

            if (data != null)
            {
                data.NailMaster_Create_ID = System.Web.HttpContext.Current.Session["UserAcc"].ToString();
                data.NailMaster_Modify_ID = System.Web.HttpContext.Current.Session["UserAcc"].ToString();
                svc.Create(data);
            }

            return Json(new[] { data }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult EditingPopup_Update([DataSourceRequest] DataSourceRequest request, NailMasterViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                model.NailMaster_Modify_ID = System.Web.HttpContext.Current.Session["UserAcc"].ToString();
                svc.Update(model);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}