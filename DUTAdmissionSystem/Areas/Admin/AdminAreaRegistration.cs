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

            context.Routes.MapHttpRoute(
                name: "Add_EditAdmissionNews",
                routeTemplate: "api/admin/admission-news/add-edit",
                defaults: new { controller = "AdmissionNewsManager", action = "Add_EditAdmissionNews", id = RouteParameter.Optional }
            );
            context.Routes.MapHttpRoute(
                name: "DeleteAdmissionNews",
                routeTemplate: "api/admin/admission-news/{id}",
                defaults: new { controller = "AdmissionNewsManager", action = "DeleteAdmissionNews", id = RouteParameter.Optional }
            );

            context.Routes.MapHttpRoute(
              name: "GetEmployeeProfile",
              routeTemplate: "api/admin/employee-profile",
              defaults: new { controller = "EmployeeProfile", action = "GetEmployeeProfile", id = RouteParameter.Optional }
          );

            context.Routes.MapHttpRoute(
              name: "UpdateEmployeeProfile",
              routeTemplate: "api/admin/employee-profile/update",
              defaults: new { controller = "EmployeeProfile", action = "UpdateEmployeeProfile", id = RouteParameter.Optional }
          );
            //<<--ContactMassagerManager controller-->>

            context.Routes.MapHttpRoute(
              name: "GetContactMessagerList",
              routeTemplate: "api/admin/contact-messager",
              defaults: new { controller = "ContactMassagerManager", action = "GetContactMessagerList", id = RouteParameter.Optional }
          );

            context.Routes.MapHttpRoute(
              name: "UpdateContactMessager",
              routeTemplate: "api/admin/contact-messager/update",
              defaults: new { controller = "ContactMassagerManager", action = "UpdateContactMessager", id = RouteParameter.Optional }
          );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}