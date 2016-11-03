using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntelliTransCentre.Annotations;
using IntelliTransCentre.Common;
using IntelliTransCentre.Controllers;

namespace IntelliTransCentre.Areas.Management.Controllers
{
    [AuthorizeByArea(Resource.UserTypeManagement)]
    public class ManagementBaseController : BaseController
    {

    }
}