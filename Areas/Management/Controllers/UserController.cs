using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntelliTransCentre.Business.Interface;

namespace IntelliTransCentre.Areas.Management.Controllers
{
    public class UserController : ManagementBaseController
    {
        private readonly IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        public ActionResult Users()
        {
            ViewBag.Title = "Users";
            return View();
        }

        [HttpGet]
        public ActionResult GetUserList()
        {
            var userList = _userBusiness.GetUserList();
            return Json(userList, JsonRequestBehavior.AllowGet);
        }
    }
}