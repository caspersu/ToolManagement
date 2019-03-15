using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tool_Management.Service.Interfaces;
using Tool_Management.Service.Services;
using Tool_Management.Service.ViewModels;
using Tool_Management.Service.Utils;

namespace Tool_Management.Controllers
{
    public class KnifeListController : Controller
    {
         ITM_KnifeList svc = new TM_KnifeListService();
        
        // GET: KnifeList
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GridSearch([DataSourceRequest] DataSourceRequest request)
        {
            return Json(svc.GridSearch(request));
        }

        public ActionResult EditingPopup_Create([DataSourceRequest] DataSourceRequest request, vKnifeListViewModel data)
        {
          
            if (data != null )
            {
                data.KnifeList_Create_ID = System.Web.HttpContext.Current.Session["UserAcc"].ToString();
                data.KnifeList_Modify_ID = System.Web.HttpContext.Current.Session["UserAcc"].ToString();
                svc.Create(data);
            }

            return Json(new[] { data }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult ATCSetup(string KnifeList_ID)
        {
            var viewModel = svc.Get(KnifeList_ID);
            return View(viewModel);
        }

        public ActionResult GridATCSearch([DataSourceRequest] DataSourceRequest request,string KnifeList_ID)
        {
            return Json(svc.GridATC(request, KnifeList_ID), JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditingPopup_CreateATC([DataSourceRequest] DataSourceRequest request,KnifeListViewModel viewModel)
        {
           
            var result = svc.Get(viewModel.KnifeList_Create_ID);
            viewModel.KnifeList_ID = result.KnifeList_ID;
            viewModel.Model_ID = result.Model_ID;
            viewModel.Good_ID = result.Good_ID;
            viewModel.WorkStation_No = result.WorkStation_No;
                svc.CreateATC(viewModel);

            return Json(new[] { viewModel }.ToDataSourceResult(request, ModelState));
        }


        public ActionResult EditingPopup_Update([DataSourceRequest] DataSourceRequest request, vKnifeListViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                model.KnifeList_Modify_ID = System.Web.HttpContext.Current.Session["UserAcc"].ToString();             
                svc.UpdateKnifeList(model);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult EditingPopup_UpdateATC([DataSourceRequest] DataSourceRequest request, KnifeListViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                model.KnifeList_Modify_ID = System.Web.HttpContext.Current.Session["UserAcc"].ToString();
                svc.UpdateATC(model);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult EditingPopup_Delete([DataSourceRequest] DataSourceRequest request, vKnifeListViewModel model)
        {
            
            if (model != null && ModelState.IsValid)
            {
                svc.DeleteKnifeList(model.KnifeList_ID); 
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult EditingPopup_DeleteATC([DataSourceRequest] DataSourceRequest request, KnifeListViewModel model)
        {

            if (model != null && ModelState.IsValid)
            {
                svc.DeleteATC(model.KnifeList_ID,model.ATC_ID);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}