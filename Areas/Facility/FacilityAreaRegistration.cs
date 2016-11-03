using System.Web.Mvc;

namespace IntelliTransCentre.Areas.Facility
{
    public class FacilityAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Facility";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Facility_default",
                "Facility/{controller}/{action}/{id}",
                new { controller = "Welcome", action = "FacilityHomePage", id = UrlParameter.Optional },
                new[] { "IntelliTransCentre.Areas.Facility.Controllers" }
            );
        }
    }
}