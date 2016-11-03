using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntelliTransCentre.Business.Interface;
using IntelliTransCentre.Common;

namespace IntelliTransCentre.Areas.Customer.Controllers
{
    public class ParkingController : CustomerBaseController
    {
        private readonly IUserParkingBusiness _userParkingBusiness;

        public ParkingController(IUserParkingBusiness userParkingBusiness)
        {
            _userParkingBusiness = userParkingBusiness;
        }

        public ActionResult Parking()
        {
            return View();
        }
        public ActionResult GetCarDropDownList(Guid userId)
        {
            var result = _userParkingBusiness.GetUserCarsDownList(userId);
            result.Insert(0, new DropDownList()
            {
                Text = "Select",
                Value = "0"
            });
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetParkingInfo(Guid carId)
        {
            return Json(_userParkingBusiness.GetParkingInfo(carId)[0], JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetMyParkingCars(Guid userId)
        {
            var parkinglist = _userParkingBusiness.GetUserParking(userId);
            return Json(parkinglist, JsonRequestBehavior.AllowGet);
        }

    }
}