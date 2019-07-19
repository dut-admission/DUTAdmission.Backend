using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Mvc;

namespace DUTAdmissionSystem.Areas.Authentication
{
    public class AuthenticationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Authentication";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.Routes.MapHttpRoute(
                name: "LoginToSystem",
                routeTemplate: "api/login",
                defaults: new { controller = "Authentication", action = "Login", id = RouteParameter.Optional }
            );

            context.Routes.MapHttpRoute(
               name: "ForgetPassword",
               routeTemplate: "api/forget-password",
               defaults: new { controller = "Authentication", action = "ForgetPassword", id = RouteParameter.Optional }
           );

            context.Routes.MapHttpRoute(
               name: "ChangePassword",
               routeTemplate: "api/change-password",
               defaults: new { controller = "Authentication", action = "ChangePassword", id = RouteParameter.Optional }
           );

            context.MapRoute(
                "Authentication_default",
                "Authentication/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}