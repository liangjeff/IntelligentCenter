using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntelliTransCentre.Annotations;
using IntelliTransCentre.Controllers;
using IntelliTransCentre.Common;

namespace IntelliTransCentre.Areas.Customer.Controllers
{
    [AuthorizeByArea(Resource.UserTypeCustomer)]
    public class CustomerBaseController : BaseController
    {

    }
}