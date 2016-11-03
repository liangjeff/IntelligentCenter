using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntelliTransCentre.Areas.Facility.Controllers
{
    public class WelcomeController : FacilityBaseController
    {
        public ActionResult HomePage()
        {
            return View("FacilityHomePage");
        }
        public ActionResult FacilityHomePage()
        {
            return View();
        }
    }
}