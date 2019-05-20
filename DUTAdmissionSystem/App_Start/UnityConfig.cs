using DUTAdmissionSystem.Areas.Admin.Models.Services.Abstractions;
using DUTAdmissionSystem.Areas.Admin.Models.Services.Implementations;
using DUTAdmissionSystem.Areas.Authentication.Models.Services.Abstractions;
using DUTAdmissionSystem.Areas.Authentication.Models.Services.Implementations;
using DUTAdmissionSystem.Areas.Public.Models.Services.Abstractions;
using DUTAdmissionSystem.Areas.Public.Models.Services.Implementations;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace DUTAdmissionSystem
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IAdmissionNewsService, AdmissionNewsService>();
            container.RegisterType<ISlideService, SlideService>();
            container.RegisterType<IUniversityInfoService, UniversityInfoService>();
            container.RegisterType<IAuthenticationService, AuthenticationService>();
            container.RegisterType<IStudentProfileService, StudentProfileService>();
            container.RegisterType<IContactMessageService, ContactMessageService>();
            container.RegisterType<IDocumentService, DocumentService>();
            container.RegisterType<IEmployeeProfileService, EmployeeProfileService>();
            container.RegisterType<IAdmissionNewsManagerService, AdmissionNewsManagerService>();
            container.RegisterType<IContactMessageManagerServiece, ContactMessageManagerServiece>();
            container.RegisterType<ITuitionManagerService, TuitionManagerService>();
           


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}