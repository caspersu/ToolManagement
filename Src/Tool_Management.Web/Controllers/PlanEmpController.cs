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
    public class PlanEmpController : Controller
    {

        ITM_ProductionPlan svc = new TM_ProductionPlanService();

        // GET: PlanEmp
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CNCSetup(string Class_EmpID, string KnifeList_ID)
        {
            ViewData["KnifeList_ID"] = KnifeList_ID;
            ViewData["Class_EmpID"] = Class_EmpID;
            return View();
        }

        public ActionResult GridSearch([DataSourceRequest] DataSourceRequest request)
        {
            return Json(svc.GridSearch(request));
        }

        public ActionResult EditingPopup_Create([DataSourceRequest] DataSourceRequest request, ProductionPlanViewModel data)
        {

            if (data != null)
            {
                data.Planning_Create_ID = System.Web.HttpContext.Current.Session["UserAcc"].ToString();
                data.Planning_Modify_ID = System.Web.HttpContext.Current.Session["UserAcc"].ToString();
                data.KnifeList_ID = data.ModelGoodWk;
                svc.Create(data);
            }

            return Json(new[] { data }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult EditingPopup_Update([DataSourceRequest] DataSourceRequest request, ProductionPlanViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                model.Planning_Modify_ID = System.Web.HttpContext.Current.Session["UserAcc"].ToString();
                svc.Update(model);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult GetClassTypeItems()
        {
            List<SelectListItem> mySelectItemList = new List<SelectListItem>();

            mySelectItemList.Add(new SelectListItem()
            {
                Text = "白班",
                Value = "白班",
                Selected = false
            });

            mySelectItemList.Add(new SelectListItem()
            {
                Text = "晚班",
                Value = "晚班",
                Selected = false
            });


            return Json(mySelectItemList, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GridCNCSearchUnSelect([DataSourceRequest] DataSourceRequest request,string Class_EmpID, string KnifeList_ID)       {
            return Json(svc.GridCNCSearchUnSelect(request, Class_EmpID, KnifeList_ID));
        }

        public ActionResult GridCNCSearchSelect([DataSourceRequest] DataSourceRequest request, string Class_EmpID, string KnifeList_ID)
        {
            return Json(svc.GridCNCSearchSelect(request, Class_EmpID, KnifeList_ID));
        }

        public ActionResult Save(string Class_EmpID, string KnifeList_ID, string CNCKnifeList_IDs)
        {
            try
            {
                if (string.IsNullOrEmpty(CNCKnifeList_IDs))
                {
                    return Json(new
                    {
                        Result = false,
                        ErrMsg = "無勾選!"
                    });
                }
                var view = svc.Get(Class_EmpID, KnifeList_ID);
                for (var i = 0; i < CNCKnifeList_IDs.Split(',').Length; i++)
                {
                    string CNCKnifeList_ID = CNCKnifeList_IDs.Split(',')[i];
                    var p = new ProductionPlanViewModel()
                    {
                        Class_EmpID = Class_EmpID,
                        KnifeList_ID = KnifeList_ID,
                        Class_Type = view.Class_Type,
                        Class_RealPerson = view.Class_RealPerson,
                        Class_StandardPerson = view.Class_StandardPerson,
                        CNCKnifeList_ID = decimal.Parse(CNCKnifeList_ID),
                        Planning_Create_ID = view.Planning_Create_ID,
                        Planning_Create_DT = view.Planning_Create_DT,
                        Planning_Modify_ID = System.Web.HttpContext.Current.Session["UserAcc"].ToString(),
                        Planning_Modify_DT = DateTime.Now
                    };
                    svc.Create(p);                   
                }
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

        public ActionResult CNCDelete([DataSourceRequest] DataSourceRequest request, vEmpCNCKnifeListViewModel viewmodel)
        {
            var data = svc.Get(viewmodel.Planning_ID.ToString());

            if (data != null && ModelState.IsValid)
            {
                svc.Delete(viewmodel.Planning_ID.ToString());               
                ModelState.AddModelError("Name", "刪除成功!");
            }

            return Json(new[] { data }.ToDataSourceResult(request, ModelState));
        }

    }
}