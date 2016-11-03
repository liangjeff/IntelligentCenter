using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntelliTransCentre.Business.Interface;

namespace IntelliTransCentre.Areas.Facility.Controllers
{
    public class EntryRecordController : FacilityBaseController
    {
        private readonly IFacilityEntryBusiness _facilityEntryBusiness;
        //private readonly IUserParkingBusiness _userParkingBusiness;
        //private readonly IUserAccountBusiness _userAccountBusiness;


        public EntryRecordController(IFacilityEntryBusiness facilityEntryBusiness)
        {
            _facilityEntryBusiness = facilityEntryBusiness;
        }
        public ActionResult EntryRecord()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetEntryRecord()
        {
            var recordlist = _facilityEntryBusiness.GetEntryRecord();
            return Json(recordlist, JsonRequestBehavior.AllowGet);
        }

    }
}