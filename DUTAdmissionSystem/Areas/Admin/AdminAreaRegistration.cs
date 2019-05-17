using System.Web.Http;
using System.Web.Mvc;

namespace DUTAdmissionSystem.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            //<<--AdmissionNewsManager controller-->>
            context.Routes.MapHttpRoute(
                name: "GetAdmissionNewsList",
                routeTemplate: "api/admin/admission-news",
                defaults: new { controller = "AdmissionNewsManager", action = "GetAdmissionNewsList", id = RouteParameter.Optional }
            );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}