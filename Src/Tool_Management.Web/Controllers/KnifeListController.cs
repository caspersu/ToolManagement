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
        ITM_KnifeMaster knifeSvc = new TM_KnifeMasterService();
        ITM_HiltMaster hiltSvc = new TM_HiltMasterService();
        ITM_NailMaster nailSvc = new TM_NailMasterService();
        ITM_ExtRodMaster extrodSvc = new TM_ExtRodMasterService();
        ITM_NutMaster nutSvc = new TM_NutMasterService();
        ITM_Collet1Master collet1Svc = new TM_Collet1MasterService();
        ITM_Collet2Master collet2Svc = new TM_Collet2MasterService();

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

            if (data != null)
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
            ViewData["KnifeList_ID"] = KnifeList_ID;
            return View(viewModel);
        }

        public ActionResult GridATCSearch([DataSourceRequest] DataSourceRequest request, string KnifeList_ID)
        {
            return Json(svc.GridATC(request, KnifeList_ID), JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditingPopup_CreateATC([DataSourceRequest] DataSourceRequest request, KnifeListViewModel viewModel)
        {

            var result = svc.Get(viewModel.KnifeList_Create_ID);

            viewModel.KnifeList_ID = result.KnifeList_ID;
            viewModel.Model_ID = result.Model_ID;
            viewModel.Good_ID = result.Good_ID;
            viewModel.WorkStation_No = result.WorkStation_No;
            viewModel.KnifeList_Create_ID = Session["UserAcc"] == null ? "" : Session["UserAcc"].ToString();
            viewModel.KnifeList_Modify_ID = Session["UserAcc"] == null ? "" : Session["UserAcc"].ToString();
            //檢查料號
            if (knifeSvc.Get(viewModel.KnifeMaster_ID) == null)
            {
                //ModelState.AddModelError("Name", "刀具無此料號:"+viewModel.KnifeMaster_ID);
                TempData["actionMsg"] = "刀具無此料號:" + viewModel.KnifeMaster_ID;
                return Json(ModelState.ToDataSourceResult());
            }
            if (hiltSvc.Get(viewModel.HiltMaster_ID) == null)
            {
                //ModelState.AddModelError("Name", "刀把無此料號:" + viewModel.HiltMaster_ID);
                TempData["actionMsg"] = "刀把無此料號:" + viewModel.HiltMaster_ID;
                return Json(ModelState.ToDataSourceResult());            
            }
            if( nailSvc.Get(viewModel.NailMaster_ID) == null )
            {
                //ModelState.AddModelError("Name", "拉丁無此料號:" + viewModel.NailMaster_ID);
                TempData["actionMsg"] = "拉丁無此料號:" + viewModel.NailMaster_ID;
                return Json(ModelState.ToDataSourceResult());
            }
            if( extrodSvc.Get(viewModel.ExtRodMaster_ID) == null )
            {
                //ModelState.AddModelError("Name", "延長桿無此料號:" + viewModel.ExtRodMaster_ID);
                TempData["actionMsg"] = "延長桿無此料號:" + viewModel.ExtRodMaster_ID;
                return Json(ModelState.ToDataSourceResult());
            }
             if( collet1Svc.Get(viewModel.Collet1Master_ID) == null)
            {
                //ModelState.AddModelError("Name", "筒夾1無此料號:" + viewModel.Collet1Master_ID);
                TempData["actionMsg"] = "筒夾1無此料號:" + viewModel.Collet1Master_ID;
                return Json(ModelState.ToDataSourceResult());
            }
            if( collet2Svc.Get(viewModel.Collet2Master_ID) == null)
            {
                //ModelState.AddModelError("Name", "筒夾2無此料號:" + viewModel.Collet2Master_ID);
                TempData["actionMsg"] = "筒夾2無此料號:" + viewModel.Collet2Master_ID;
                return Json(ModelState.ToDataSourceResult());
            }
            if( nutSvc.Get(viewModel.NutMaster_ID) == null )
            {
                //ModelState.AddModelError("Name", "螺帽/刀頭無此料號:" + viewModel.NutMaster_ID);
                TempData["actionMsg"] = "螺帽/刀頭無此料號:" + viewModel.NutMaster_ID;
                return Json(ModelState.ToDataSourceResult());
            }
           
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


        public ActionResult GetSelectListItems()
        {
                var list = svc.GetKnifeList()
                    .Select(s => new SelectListItem { Text = s.Model_ID+"-"+s.Good_Name+"-"+s.WorkStation_No, Value = s.KnifeList_ID })
                    .ToList();


                return Json(list, JsonRequestBehavior.AllowGet);
        
        }
    }
}