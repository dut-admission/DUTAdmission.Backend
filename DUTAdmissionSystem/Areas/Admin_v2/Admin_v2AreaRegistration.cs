using System.Web.Http;
using System.Web.Mvc;

namespace DUTAdmissionSystem.Areas.Admin_v2
{
    public class Admin_v2AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin_v2";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {


            context.Routes.MapHttpRoute(
              name: "GetAccountGroups",
              routeTemplate: "api/admin/account-group",
              defaults: new { controller = "AccountGroupManagement", action = "GetAccountGroups", id = UrlParameter.Optional }
           );

            context.Routes.MapHttpRoute(
                 name: "GetAccountGroupById",
                 routeTemplate: "api/admin/account-group/{id}",
                 defaults: new { controller = "AccountGroupManagement", action = "GetAccountGroupById", id = RouteParameter.Optional }
             );

            context.Routes.MapHttpRoute(
              name: "AddAccountGroup",
              routeTemplate: "api/admin/group-account/add",
              defaults: new { controller = "AccountGroupManagement", action = "AddAccountGroup", id = UrlParameter.Optional }
           );

            context.Routes.MapHttpRoute(
              name: "EditAccountGroup",
              routeTemplate: "api/admin/account-group/{id}/edit",
              defaults: new { controller = "AccountGroupManagement", action = "EditAccountGroup", id = UrlParameter.Optional }
           );

            context.Routes.MapHttpRoute(
              name: "DeleteAccountGroup",
              routeTemplate: "api/admin/account-group/delete/{id}",
              defaults: new { controller = "AccountGroupManagement", action = "DeleteAccountGroup", id = UrlParameter.Optional }
           );

            //StudentManagementController
            context.Routes.MapHttpRoute(
              name: "GetStudents",
              routeTemplate: "api/admin/student",
              defaults: new { controller = "StudentManagement", action = "GetStudents", id = UrlParameter.Optional }
           );

            //DocumentManagement

            context.Routes.MapHttpRoute(
              name: "UpdateDocument",
              routeTemplate: "api/admin/document-update",
              defaults: new { controller = "DocumentManagement", action = "UpdateDocument", id = UrlParameter.Optional }
           );

            context.MapRoute(
                "Admin_v2_default",
                "Admin_v2/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}