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
    public class CNCStartStopController : Controller
    {

        ITM_vEmpCNCKnifeList svc = new TM_vEmpCNCKnifeListService();
        ITM_KnifeList KnifeListsvc = new TM_KnifeListService();

        // GET: CNCStartStop
        public ActionResult Index()
        {
            Session["KnifeList_ID"] = "";
            return View();
        }

        public ActionResult Query(string CNC_ID,string Class_EmpID)
        {
            if(string.IsNullOrEmpty(CNC_ID) || string.IsNullOrEmpty(Class_EmpID)) 
            return Json(new
            {
                Result = false,
                ErrMsg = "機台編號與生產技術人員為必填!"
            });
            var result = svc.Get(CNC_ID, Class_EmpID);
            if (result == null)
                return Json(new
                {
                    Result = false,
                    ErrMsg = "查無資料!"
                });
            else
            {
                Session["KnifeList_ID"] = result.KnifeList_ID;
                return Json(new
                {
                    Result = true,
                    CNC_ID = result.CNC_ID,
                    CNC_IP = result.CNC_IP,
                    CNC_Brand = result.CNC_Brand,
                    CNC_Model = result.CNC_Model,
                    KnifeList_ID = result.KnifeList_ID,
                    Line_No = result.Line_No,
                    Car_No = result.Car_No,
                    WorkStation_No = result.WorkStation_No,
                    Model_Name = result.Model_Name,
                    Good_Name = result.Good_Name,
                    Emp_Name = result.Emp_Name,
                    ErrMsg = ""
                });
            }
        }

        public ActionResult GridATCSearch([DataSourceRequest] DataSourceRequest request)
        {
            string KnifeList_ID = string.IsNullOrEmpty(Session["KnifeList_ID"].ToString()) ?"": Session["KnifeList_ID"].ToString();
            return Json(KnifeListsvc.GridATC(request, KnifeList_ID), JsonRequestBehavior.AllowGet);
        }
    }
}