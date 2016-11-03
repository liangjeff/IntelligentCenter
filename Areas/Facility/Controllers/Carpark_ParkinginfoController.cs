using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntelliTransCentre.Business.Interface;

namespace IntelliTransCentre.Areas.Facility.Controllers
{
    public class Carpark_ParkinginfoController : FacilityBaseController
    {
        private readonly IFacilityParkingBusiness _facilityParkingBusiness;
        //private readonly IUserParkingBusiness _userParkingBusiness;
        //private readonly IUserAccountBusiness _userAccountBusiness;


        public Carpark_ParkinginfoController(IFacilityParkingBusiness facilityParkingBusiness)
        {
            _facilityParkingBusiness = facilityParkingBusiness;
        }
        public ActionResult Carpark_Parkinginfo()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetCarpark_Parkinginfo()
        {
            var parkingInfoList = _facilityParkingBusiness.GetFacilityParking();
            return Json(parkingInfoList, JsonRequestBehavior.AllowGet);
        }

    }
}