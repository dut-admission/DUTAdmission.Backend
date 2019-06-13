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
            //<<--AccountGroupManagement controller-->>

            context.Routes.MapHttpRoute(
                  name: "GetAccountGroups",
                  routeTemplate: "api/admin/account-group",
                  defaults: new { controller = "AccountGroupManagement", action = "GetAccountGroups", id = RouteParameter.Optional }
              );

            context.Routes.MapHttpRoute(
                  name: "GetAccountGroupById",
                  routeTemplate: "api/admin/account-group/{id}",
                  defaults: new { controller = "AccountGroupManagement", action = "GetAccountGroupById", id = RouteParameter.Optional }
              );

            context.Routes.MapHttpRoute(
                name: "AddAccountGroup",
                routeTemplate: "api/admin/group-account/add",
                defaults: new { controller = "AccountGroupManagement", action = "AddAccountGroup", id = RouteParameter.Optional }
            );

            context.Routes.MapHttpRoute(
           name: "EditAccountGroup",
           routeTemplate: "api/admin/account-group/{id}/edit",
           defaults: new { controller = "AccountGroupManagement", action = "EditAccountGroup", id = RouteParameter.Optional }
          );

            context.Routes.MapHttpRoute(
           name: "DeleteAccountGroup",
           routeTemplate: "api/admin/account-group/delete/{id}",
           defaults: new { controller = "AccountGroupManagement", action = "DeleteAccountGroup", id = RouteParameter.Optional }
          );

            //<<--AdmissionNewsManager controller-->>
            context.Routes.MapHttpRoute(
                name: "GetAdmissionNewsList",
                routeTemplate: "api/admin/admission-news",
                defaults: new { controller = "AdmissionNewsManagement", action = "GetAdmissionNewsList", id = RouteParameter.Optional }
            );

            context.Routes.MapHttpRoute(
                name: "Add_EditAdmissionNews",
                routeTemplate: "api/admin/admission-news/add-edit",
                defaults: new { controller = "AdmissionNewsManagement", action = "Add_EditAdmissionNews", id = RouteParameter.Optional }
            );
            context.Routes.MapHttpRoute(
                name: "DeleteAdmissionNews",
                routeTemplate: "api/admin/admission-news/{id}",
                defaults: new { controller = "AdmissionNewsManagement", action = "DeleteAdmissionNews", id = RouteParameter.Optional }
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
              defaults: new { controller = "ContactMassagerManagement", action = "GetContactMessagerList", id = RouteParameter.Optional }
          );

            context.Routes.MapHttpRoute(
              name: "UpdateContactMessager",
              routeTemplate: "api/admin/contact-messager/{id}/update",
              defaults: new { controller = "ContactMassagerManagement", action = "UpdateContactMessager", id = RouteParameter.Optional }
          );

            context.Routes.MapHttpRoute(
              name: "ReplyContactMessager",
              routeTemplate: "api/admin/contact-messager/{id}/reply",
              defaults: new { controller = "ContactMassagerManagement", action = "ReplyContactMessager", id = RouteParameter.Optional }
          );

            context.Routes.MapHttpRoute(
              name: "GetStatusList",
              routeTemplate: "api/admin/contact/status-list",
              defaults: new { controller = "ContactMassagerManagement", action = "GetStatusList", id = RouteParameter.Optional }
          );

            //<<--StudentManagement controller-->>

            context.Routes.MapHttpRoute(
              name: "GetStudents",
              routeTemplate: "api/admin/student",
              defaults: new { controller = "StudentManagement", action = "GetStudents", id = RouteParameter.Optional }
          );
            context.Routes.MapHttpRoute(
               name: "UpdateStudent",
               routeTemplate: "api/admin/update-student",
               defaults: new { controller = "StudentManagement", action = "UpdateStudent", id = RouteParameter.Optional }
           );
            context.Routes.MapHttpRoute(
               name: "DeleteStudent",
               routeTemplate: "api/admin/delete-student/{id}",
               defaults: new { controller = "StudentManagement", action = "DeleteStudent", id = RouteParameter.Optional }
           );

            //<<--DocumentManagement controller-->>

            context.Routes.MapHttpRoute(
              name: "GetDocuments",
              routeTemplate: "api/admin/document",
              defaults: new { controller = "DocumentManagement", action = "GetDocuments", id = RouteParameter.Optional }
          );

            context.Routes.MapHttpRoute(
              name: "GetDocumentTypeList",
              routeTemplate: "api/admin/document-type",
              defaults: new { controller = "DocumentManagement", action = "GetDocumentTypeList", id = RouteParameter.Optional }
          );

            context.Routes.MapHttpRoute(
             name: "AddDocumentType",
             routeTemplate: "api/admin/add-document-type",
             defaults: new { controller = "DocumentManagement", action = "AddDocumentType", id = RouteParameter.Optional }
         );

            context.Routes.MapHttpRoute(
             name: "EditDocumentType",
             routeTemplate: "api/admin/document-type/{id}",
             defaults: new { controller = "DocumentManagement", action = "EditDocumentType", id = RouteParameter.Optional }
         );

            context.Routes.MapHttpRoute(
             name: "DeleteDocumentType",
             routeTemplate: "api/admin/document-type/delete/{id}",
             defaults: new { controller = "DocumentManagement", action = "DeleteDocumentType", id = RouteParameter.Optional }
         );

            //<<--TuitionManagementController controller-->>

            context.Routes.MapHttpRoute(
             name: "GetTuitionList",
             routeTemplate: "api/admin/tuition-list",
             defaults: new { controller = "TuitionManagement", action = "GetTuitionList", id = RouteParameter.Optional }
         );

            context.Routes.MapHttpRoute(
             name: "GetTuitionLibraries",
             routeTemplate: "api/admin/tuition/libraries",
             defaults: new { controller = "TuitionManagement", action = "GetTuitionLibraries", id = RouteParameter.Optional }
         );

            context.Routes.MapHttpRoute(
             name: "GetTuitionTypeList",
             routeTemplate: "api/admin/tuition-type",
             defaults: new { controller = "TuitionManagement", action = "GetTuitionTypeList", id = RouteParameter.Optional }
         );

            context.Routes.MapHttpRoute(
             name: "AddTuitionType",
             routeTemplate: "api/admin/add-tuition-type",
             defaults: new { controller = "TuitionManagement", action = "AddTuitionType", id = RouteParameter.Optional }
         );

            context.Routes.MapHttpRoute(
             name: "EditTuitionType",
             routeTemplate: "api/admin/tuition-type/{id}",
             defaults: new { controller = "TuitionManagement", action = "EditTuitionType", id = RouteParameter.Optional }
         );

            context.Routes.MapHttpRoute(
             name: "DeleteTuitionType",
             routeTemplate: "api/admin/tuition-type/delete/{id}",
             defaults: new { controller = "TuitionManagement", action = "DeleteTuitionType", id = RouteParameter.Optional }
         );

            //<<--AccountManagementController controller-->>

            context.Routes.MapHttpRoute(
             name: "GetAccountList",
             routeTemplate: "api/admin/account-list",
             defaults: new { controller = "AccountManagement", action = "GetAccountList", id = RouteParameter.Optional }
         );

            context.Routes.MapHttpRoute(
             name: "GetAccountLibraries",
             routeTemplate: "api/admin/account-library",
             defaults: new { controller = "AccountManagement", action = "GetAccountLibraries", id = RouteParameter.Optional }
         );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}