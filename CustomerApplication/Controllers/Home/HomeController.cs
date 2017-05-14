using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerApplication.Controllers.Home
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Session["StartDateTime"] = DateTime.Now.ToString();
            TempData["Name"] = "Atul Trikha";
            ViewBag.Age = 35;
            ViewData["CurrentDateTime"] = DateTime.Now.ToString();
            return RedirectToAction("GotoHome", "Home");
        }

        // GET: Home
        public ActionResult GotoHome()
        {
            return View("HomeView");
        }
    }
}