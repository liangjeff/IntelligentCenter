using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntelliTransCentre.Business.Interface;

namespace IntelliTransCentre.Areas.Management.Controllers
{
    public class FacilityController : ManagementBaseController
    {
        private readonly IAllCarparkBusiness _allCarparkBusiness;
        // GET: Management/Facility

        public FacilityController(IAllCarparkBusiness carparkBusiness)
        {
            _allCarparkBusiness = carparkBusiness;
        }
        public ActionResult Facility()
        {
            ViewBag.Title = "Facility";
            return View();
        }
        public ActionResult GetCarparkList()
        {
            var userList = _allCarparkBusiness.GetCarparkList();
            return Json(userList, JsonRequestBehavior.AllowGet);
        }
    }
}