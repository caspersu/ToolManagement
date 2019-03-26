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

namespace Tool_Management.Controllers
{
    public class KnifeController : Controller
    {
        ITM_KnifeMaster svc = new TM_KnifeMasterService();
        ITM_InForm informSvc = new TM_InFormService();
        ITM_Stock stockSvc = new TM_StockService();

        // GET: Knife
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GridSearch([DataSourceRequest] DataSourceRequest request)
        {
            return Json(svc.GridSearch(request));
        }

        public ActionResult EditingPopup_Create([DataSourceRequest] DataSourceRequest request, KnifeMasterViewModel data)
        {

            if (data != null)
            {
                data.KnifeMaster_Create_ID = System.Web.HttpContext.Current.Session["UserAcc"].ToString();
                data.KnifeMaster_Modify_ID = System.Web.HttpContext.Current.Session["UserAcc"].ToString();
                svc.Create(data);
            }

            return Json(new[] { data }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult EditingPopup_Update([DataSourceRequest] DataSourceRequest request, KnifeMasterViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                model.KnifeMaster_Modify_ID = System.Web.HttpContext.Current.Session["UserAcc"].ToString();
                svc.Update(model);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult KnifeInform()
        {
            InFormViewModel data = new InFormViewModel();
            //data.InForm_ID = Guid.NewGuid().ToString();   
            if (Session["InFormID"] == null)
            {
                data.InForm_ID = new Common().GetInfromID();
                Session["InFormID"] = data.InForm_ID;
            }
            else
                data.InForm_ID = Session["InFormID"].ToString();

                data.In_DT = DateTime.Now.ToString("yyyy/MM/dd");            
            return View(data);
        }

        public ActionResult KnifeInformGridSearch([DataSourceRequest] DataSourceRequest request,string InForm_ID)
        {
            return Json(informSvc.KnifeInFormGridSearch(request, InForm_ID));
        }

        public ActionResult KnifeInform_Create([DataSourceRequest] DataSourceRequest request, KnifeInFormViewModel data,string InForm_ID,string In_EmpID,string Confirm_EmpID)
        {
            data.InForm_ID = data.Knife_Name.Split(';')[0];
            data.In_DT = data.Knife_Name.Split(';')[1];
            data.In_EmpID = data.Knife_Name.Split(';')[2];
            data.Confirm_EmpID = data.Knife_Name.Split(';')[3];
            ViewData["In_EmpID"] = data.In_EmpID;
            ViewData["Confirm_EmpID"] = data.Confirm_EmpID;

            if (data != null)
                {            
                    if(stockSvc.KnifeOutQuantity(data.Master_ID).Count() < data.InForm_Quality)
                    {
                         TempData["actionMsg"] = data.Master_ID+"-此料號出庫數量少於入庫數量,請重新輸入入庫數量!";
                         return Json(ModelState.ToDataSourceResult());
                     }
                    data.InForm_Create_ID = System.Web.HttpContext.Current.Session["UserAcc"].ToString();
                    data.InForm_Modify_ID = System.Web.HttpContext.Current.Session["UserAcc"].ToString();
                    informSvc.KnifeInFormCreate(data);
                    
                }

            return Json(informSvc.KnifeInFormGridSearch(request, data.InForm_ID));
            //return Json(new[] { data }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult KnifeInform_Delete([DataSourceRequest] DataSourceRequest request, KnifeInFormViewModel data)
        {

            if (data != null )
            {
                data.InForm_Modify_ID = System.Web.HttpContext.Current.Session["UserAcc"].ToString();
                informSvc.KnifeInFormDelete(data);
            }

            return Json(informSvc.KnifeInFormGridSearch(request, data.InForm_ID));
            //return Json(new[] { data }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult GetKnifeStatusItems()
        {
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = "正常", Value = "1" });
            list.Add(new SelectListItem { Text = "報廢", Value = "9" });
            list.Add(new SelectListItem { Text = "維修入庫", Value = "2" });
            list.Add(new SelectListItem { Text = "維修出庫", Value = "4" });
            return Json(list, JsonRequestBehavior.AllowGet);        
        }

        public ActionResult KnifeInformSave(string InForm_ID)
        {
            try
            {
                informSvc.KnifeStatusSave(InForm_ID);
                Session["InFormID"] = null;
                return Json(new
                {
                    Result = true,
                    ErrMsg = ""
                });
            }
            catch (Exception e)
            {
                return Json(new
                {
                    Result = false,
                    ErrMsg = e.Message
                });
            }
        }

    }
}