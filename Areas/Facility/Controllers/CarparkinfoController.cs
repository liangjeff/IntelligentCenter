using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntelliTransCentre.Business;
using IntelliTransCentre.Business.Interface;


namespace IntelliTransCentre.Areas.Facility.Controllers
{
    public class CarparkinfoController : FacilityBaseController
    {
        private readonly IFacilityOverViewBusiness _FacilityOverViewBusiness;
        //private readonly IUserParkingBusiness _userParkingBusiness;
        //private readonly IUserAccountBusiness _userAccountBusiness;


        public CarparkinfoController(IFacilityOverViewBusiness facilityOverviewBusiness)
        {
            _FacilityOverViewBusiness = facilityOverviewBusiness;
        }
        public ActionResult Carparkinfo()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Getparkinginfo(Guid userId)
        {
            var parkingInfoList = _FacilityOverViewBusiness.Getcarparkinfo(userId);
            return Json(parkingInfoList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCarparkRate(Guid userId)
        {
            var parkingInfoList = _FacilityOverViewBusiness.GetCarparkRate(userId);
            return Json(parkingInfoList, JsonRequestBehavior.AllowGet);
        }
    }
}