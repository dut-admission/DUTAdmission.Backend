using System.Web.Http;
using System.Web.Mvc;

namespace DUTAdmissionSystem.Areas.StudentArea
{
    public class StudentAreaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "StudentArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.Routes.MapHttpRoute(
                name: "GetUniversityInfo_2",
                routeTemplate: "api/public/university-info",
                defaults: new { controller = "UniversityInfo_2", action = "GetUniversityInfo_2", id = RouteParameter.Optional }
            );

            context.MapRoute(
                "StudentArea_default",
                "StudentArea/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}