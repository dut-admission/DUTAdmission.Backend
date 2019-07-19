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
                name         : "GetUniversityInfo_2",
                routeTemplate: "api/public/university-info",
                defaults     : new { controller = "UniversityInfo_2", action = "GetUniversityInfo_2", id = RouteParameter.Optional }
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

            context.Routes.MapHttpRoute(
                name: "UpdateAvatar",
                routeTemplate: "api/public/update-avatar",
                defaults: new { controller = "StudentInformation", action = "UpdateAvatar", id = RouteParameter.Optional }
            );

            context.Routes.MapHttpRoute(
              name: "UpdateProfile",
              routeTemplate: "api/public/update-profile",
              defaults: new { controller = "StudentInformation", action = "UpdateProfile", id = UrlParameter.Optional }
           );

            context.MapRoute(
                "StudentArea_default",
                "StudentArea/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
            context.Routes.MapHttpRoute(
                name: "GetHighSchoolResultApi",
                routeTemplate: "api/public/get-high-school-result",
                defaults: new { controller = "HighSchoolResult", action = "GetHighSchoolResult", id = UrlParameter.Optional }
            );
            context.Routes.MapHttpRoute(
               name         :"AddHighSchoolResultApi",
               routeTemplate:"api/public/add-high-school-result",
               defaults: new { controller = "HighSchoolResult", action = "AddHighSchoolResult", id = UrlParameter.Optional }
           );
            context.Routes.MapHttpRoute(
               name         :"UpdateHighSchoolResultApi",
               routeTemplate:"api/public/update-high-school-result",
               defaults: new { controller = "HighSchoolResult", action = "UpdateHighSchoolResult", id = UrlParameter.Optional }
           );
            context.Routes.MapHttpRoute(
              name         : "DeleteHighSchoolResultApi",
              routeTemplate: "api/public/delete-high-school-result/{id}",
              defaults: new { controller = "HighSchoolResult", action = "DeleteHighSchoolResult", id = UrlParameter.Optional }
           );

            

            //context.Routes.MapHttpRoute(
            //    name         :"StudentArea_default",
            //    routeTemplate:"StudentArea/{controller}/{action}/{id}",
            //    defaults: new { action = "Index", id = UrlParameter.Optional }
            //);


        }
    }
}