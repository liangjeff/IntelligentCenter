using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntelliTransCentre.Business.Interface;
using IntelliTransCentre.Common;

namespace IntelliTransCentre.Areas.Customer.Controllers
{
    public class WelcomeController : CustomerBaseController
    {
        private readonly IUserCarBusiness _userCarBusiness;
        private readonly IUserParkingBusiness _userParkingBusiness;
       


        public WelcomeController(IUserCarBusiness userCarBusiness, IUserParkingBusiness userParkingBusiness)
        {
            _userCarBusiness = userCarBusiness;
            _userParkingBusiness = userParkingBusiness;
            
        }


        public ActionResult HomePage()
        {
            return View("CustomerHomePage");
        }
        public ActionResult CustomerHomePage()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetMyCars(Guid userId)
        {
            var carList = _userCarBusiness.GetUserCar(userId);
            return Json(carList, JsonRequestBehavior.AllowGet);
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
    }
}