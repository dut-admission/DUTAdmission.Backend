using DUTAdmissionSystem.Areas.Admin_v2.Services.Components;
using DUTAdmissionSystem.Areas.Authentication.Services.Components;
using DUTAdmissionSystem.Areas.StudentArea.Services.Components;
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

            container.RegisterType<IUniversityInfoService, UniversityInfoService>();
            container.RegisterType<IStudentInforService, StudentInforService>();
            container.RegisterType<IHighSchoolResultService, HighSchoolResultService>();
            container.RegisterType<IFamilyMemberService, FamilyMemberService>();
            container.RegisterType<ITuitionInformationService, TuitionInformationService>();
            container.RegisterType<IAchievementService, AchievementService>();

            //admin

            container.RegisterType<IAccountGroupManagementService, AccountGroupManagementService>();
            container.RegisterType<IStudentManagementService, StudentManagementService>();
            container.RegisterType<IDocumentManagement, DocumentManagement>();



            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}