using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntelliTransCentre.Business.Interface;

namespace IntelliTransCentre.Areas.Management.Controllers
{
    public class IoTController : ManagementBaseController
    {
        // GET: Management/IoT
        private readonly IAllCarBusiness _allCarBusiness;
        // GET: Management/Facility

        public IoTController(IAllCarBusiness carBusiness)
        {
            _allCarBusiness = carBusiness;
        }
        public ActionResult IoT()
        {
            ViewBag.Title = "IoT";
            return View();
        }
        public ActionResult GetCarList()
        {
            var userList = _allCarBusiness.GetCarList();
            return Json(userList, JsonRequestBehavior.AllowGet);
        }
    }
}