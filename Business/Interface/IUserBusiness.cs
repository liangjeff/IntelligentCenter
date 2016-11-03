using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IntelliTransCentre.Common;
using IntelliTransCentre.Models;

namespace IntelliTransCentre.Business.Interface
{
    public interface IUserBusiness
    {
        ResultModel VerifyUser(string userId, string password);
        bool AddUser(RegisterViewModel model);
        UserProfileViewModel GetUserProfileViewModel(Guid id);
        bool UpdateUserProfile(UserProfileViewModel profile);
        List<UserProfileViewModel> GetUserList();
    }
}