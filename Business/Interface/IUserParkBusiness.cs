using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IntelliTransCentre.Common;
using IntelliTransCentre.Models.ViewModels;

namespace IntelliTransCentre.Business.Interface
{
    public interface IUserParkingBusiness
    {
        IList<UserParkingViewModels> GetUserParking(Guid userId);
        IList<DropDownList> GetUserCarsDownList(Guid userId);
        IList<ParkingInfoViewModel> GetParkingInfo(Guid carId);
    }
}