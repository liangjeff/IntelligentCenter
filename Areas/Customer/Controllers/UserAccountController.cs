using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntelliTransCentre.Business;
using IntelliTransCentre.Business.Interface;

namespace IntelliTransCentre.Areas.Customer.Controllers
{
    public class UserAccountController : CustomerBaseController
    {
        private readonly IUserAccountBusiness _userAccountBusiness;
        


        public UserAccountController(IUserAccountBusiness useraccountbusiness )
        {
            _userAccountBusiness = useraccountbusiness;
         
        }


 
        public ActionResult UserAccount()
        {
            return View();
        }

        [HttpGet]

        public ActionResult GetMyAccount(Guid userId)
        {
            var accountlist = _userAccountBusiness.GetUserAccount(userId);
            return Json(accountlist, JsonRequestBehavior.AllowGet);
        }
    }
}