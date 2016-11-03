using System.Web.Mvc;

namespace IntelliTransCentre.Areas.Customer
{
    public class CustomerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Customer";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Customer_default",
                "Customer/{controller}/{action}/{id}",
                new { controller="Welcome", action = "CustomerHomePage", id = UrlParameter.Optional },
                new[] { "IntelliTransCentre.Areas.Customer.Controllers" }
            );
        }
    }
}