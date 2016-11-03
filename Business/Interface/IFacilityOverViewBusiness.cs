using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IntelliTransCentre.Models.ViewModels;

namespace IntelliTransCentre.Business.Interface
{
    public interface IFacilityOverViewBusiness
    {
        IList<FacilityoverviewViewModels> Getcarparkinfo(Guid userId);
        IList<CarparkRateViewModels> GetCarparkRate(Guid userId);
    }
}