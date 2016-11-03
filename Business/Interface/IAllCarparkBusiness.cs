using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IntelliTransCentre.Common;
using IntelliTransCentre.Models;

namespace IntelliTransCentre.Business.Interface
{
    public interface IAllCarparkBusiness
    {
 
        List<AllCarparkViewModel> GetCarparkList();
    }
}