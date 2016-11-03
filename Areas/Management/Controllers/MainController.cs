using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntelliTransCentre.Areas.Management.Controllers
{
    public class MainController : ManagementBaseController
    {
        public ActionResult HomePage()
        {
            ViewBag.Title = "Home";
            return View("MainPage");
        }
        public ActionResult MainPage()
        {
            ViewBag.Title = "Home";
            return View();
        }
    }
}