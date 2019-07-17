using DUTAdmissionSystem.Areas.Authentication.Models.Services.Abstractions;
using DUTAdmissionSystem.Areas.Authentication.Models.Services.Implementations;
using DUTAdmissionSystem.Areas.StudentArea.Models.Services.Abstractions;
using DUTAdmissionSystem.Areas.StudentArea.Models.Services.Implementations;
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
            
            container.RegisterType<IAuthenticationService, AuthenticationService>();
           

            // version 2 ( An - Hằng -Hoàng)

            container.RegisterType<IUniversityInfo_2Service, UniversityInfo_2Service>();
            container.RegisterType<IStudentTuitionService, StudentTuitionService>();




            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}