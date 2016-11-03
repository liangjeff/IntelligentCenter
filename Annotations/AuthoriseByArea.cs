using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using IntelliTransCentre.Common;

namespace IntelliTransCentre.Annotations
{
    public class AuthorizeByArea : AuthorizeAttribute
    {
        private readonly string _area;

        public AuthorizeByArea(string area)
        {
            _area = area;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity != null && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var identity = HttpContext.Current.User.Identity as ClaimsIdentity;

                if (identity == null)
                    return false;

                switch (_area)
                {
                    case Resource.UserTypeCustomer:
                        return identity.HasClaim("userType", Resource.UserTypeCustomer);
                    case Resource.UserTypeFacility:
                        return identity.HasClaim("userType", Resource.UserTypeFacility);
                    case Resource.UserTypeManagement:
                        return identity.HasClaim("userType", Resource.UserTypeManagement);
                }
            }
            return false;
        }
    }
}