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

            context.Routes.MapHttpRoute(
                name: "GetTuitionDetail",
                routeTemplate: "api/public/student-info-tuition",
                defaults: new { controller = "StudentInformation", action = "GetTuitionDetail", id = RouteParameter.Optional }
            );

            context.Routes.MapHttpRoute(
                name: "GetProfile",
                routeTemplate: "api/public/profile",
                defaults: new { controller = "StudentInformation", action = "GetProfile", id = RouteParameter.Optional }
            );

            context.MapRoute(
                "StudentArea_default",
                "StudentArea/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}