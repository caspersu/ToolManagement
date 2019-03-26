using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tool_Management.Controllers
{
    public class HomeController : Controller
    {

        
        
        // GET: Default
        public ActionResult Index()
        {           
            Session["UserAcc"] = "B00005150";
            return View();
        }

        public ActionResult QrcodeExport(string id)
        {
            if (id == "caspersu")
                return Redirect("www.google.com.tw");
            else
                return RedirectToAction("Index");               
        }
    }
}