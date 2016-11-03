using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntelliTransCentre.Models.BusinessObjects
{
    public class UserBo
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get { return string.Format("{0}, {1}", LastName.ToUpper(), FirstName); }
        }

        public string Salutation { get; set; }
        public string JobTitle { get; set; }
        public string ContactNumber { get; set; }
        public bool LockToIP { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public DateTime? LastLogin { get; set; }
        public string Status { get; set; }
        public string UserId { get; set; }
        public string Pin { get; set; }
        public bool? ResetPassword { get; set; }
        public Guid? PasswordResetCode { get; set; }
        public UserRolesBo Role { get; set; }
        public string TypeName { get; set; }
        public bool? IsTermsAndConditionsAccepted { get; set; }
        public DateTime? TermsAndConditionsAcceptedDate { get; set; }
        public string Email { get; set; }
        public int LoginFailedCount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? CreatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public DateTime? LastUpdatedBy { get; set; }
    }
}