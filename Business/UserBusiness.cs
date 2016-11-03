using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using IntelliTransCentre.Business.Interface;
using IntelliTransCentre.Common;
using IntelliTransCentre.Models;
using IntelliTransCentre.Models.BusinessObjects;
using IntelliTransCentre.Models.DBObjects;
using Microsoft.Ajax.Utilities;

namespace IntelliTransCentre.Business
{
    public class UserBusiness : IUserBusiness
    {
        public ResultModel VerifyUser(string userId, string password)
        {
            var result = new ResultModel();

            using (var context = new SpartanEntities())
            {
                var user = context.Users.SingleOrDefault(rec => rec.UserId == userId);
                if (user != null)
                {
                    var userSalt = user.Salt;
                    var formPassword = password + userSalt;
                    if (user.Status != UserStatus.Active.ToString())
                    {
                        result.Result = Resource.UserHasInactive;
                        result.ResultCode = Resource.Error;
                    }
                    else if (Crypto.VerifyHashedPassword(user.PasswordHash, formPassword))
                    {
                        result.Result = Resource.Success;
                        result.ResultCode = Resource.Ok;

                        var userRole = context.UserRoles.FirstOrDefault(rec => rec.Id == user.Role);

                        var userRoleBo = new UserRolesBo()
                        {
                            Id = userRole.Id,
                            Description = userRole.Description,
                            Role = userRole.Role,
                            TypeId = userRole.UserTypeId.Value
                        };

                        var userType = context.UserTypes.FirstOrDefault(rec => rec.Id == userRole.UserTypeId);

                        var userInfo = new UserBo()
                        {
                            Id = user.Id,
                            UserId = user.UserId,
                            Role = userRoleBo,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            TypeName = userType.Type
                        };

                        result.ResultObj = userInfo;
                        user.LoginFailedCount = 0;
                        user.LastLogin = DateTime.Now;
                    }
                    context.Users.Attach(user);
                    context.Entry(user).State = EntityState.Modified;
                    context.SaveChanges();
                }
                else
                {
                    result.Result = "Failed";
                    result.ResultCode = "Error";
                }
            }

            return result;
        }

        public bool AddUser(RegisterViewModel model)
        {
            using (var context = new SpartanEntities())
            {
                var salt = Crypto.GenerateSalt(4);

                var cAdminId = context.UserRoles.FirstOrDefault(x => x.Role == "C-Admin").Id;

                var user = new User
                {
                    Id = Guid.NewGuid(),
                    UserId = model.UserName,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Salt = salt,
                    PasswordHash = Crypto.HashPassword(model.Password + salt),
                    CreatedDate = DateTime.UtcNow,
                    Status = UserStatus.Active.ToString(),
                    Role = cAdminId
                };

                try
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public UserProfileViewModel GetUserProfileViewModel(Guid id)
        {
            using (var context = new SpartanEntities())
            {
                var user = context.Users.FirstOrDefault(rec => rec.Id == id);

                var result = new UserProfileViewModel
                {
                    Id = id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    ContactNumber = user.ContactNumber,
                    JobTitle = user.JobTitle,
                    Salutation = user.Salutation,
                    UserId = user.UserId
                };

                return result;
            }
        }

        public bool UpdateUserProfile(UserProfileViewModel profile)
        {
            using (var context = new SpartanEntities())
            {
                try
                {
                    var user = context.Users.SingleOrDefault(rec => rec.Id == profile.Id);

                    user.ContactNumber = profile.ContactNumber;
                    user.FirstName = profile.FirstName;
                    user.LastName = profile.LastName;
                    user.Email = profile.Email;
                    user.JobTitle = profile.JobTitle;
                    user.Salutation = profile.Salutation;

                    context.SaveChanges();

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public List<UserProfileViewModel> GetUserList()
        {
            var list = new List<UserProfileViewModel>();
            using (var context = new SpartanEntities())
            {
                try
                {
                    foreach (var user in context.Users)
                    {
                        var userVM = new UserProfileViewModel
                        {
                            Id = user.Id,
                            UserId = user.UserId,
                            ContactNumber = user.ContactNumber,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Email = user.Email,
                            JobTitle = user.JobTitle,
                            Salutation = user.Salutation
                        };
                        list.Add(userVM);
                    }
                }
                catch
                {

                }
                return list;
            }
        }
    }
}