﻿using DUTAdmissionSystem.Areas.Authentication.Models.Services.Abstractions;
using DUTAdmissionSystem.Areas.Authentication.Models.Services.Implementations;
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
            container.RegisterType<IStudentTuitionService, StudentTuitionService>();
            container.RegisterType<IHighSchoolResultService, HighSchoolResultService>();
            container.RegisterType<IFamilyMemberService, FamilyMemberService>();



            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}