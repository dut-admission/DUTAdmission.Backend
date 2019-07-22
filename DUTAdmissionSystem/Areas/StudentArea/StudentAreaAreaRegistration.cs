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
                name: "GetTuitionInfor",
                routeTemplate: "api/public/tuition-infor",
                defaults: new { controller = "TuitionInformation", action = "GetTuitionDetail", id = RouteParameter.Optional }
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

            context.Routes.MapHttpRoute(
              name: "GetLibrariesOfProFile",
              routeTemplate: "api/public/profile-library",
              defaults: new { controller = "StudentInformation", action = "GetLibrariesOfProFile", id = UrlParameter.Optional }
           );


            context.Routes.MapHttpRoute(
                name: "GetHighSchoolResultApi",
                routeTemplate: "api/public/get-high-school-result",
                defaults: new { controller = "HighSchoolResult", action = "GetHighSchoolResults", id = UrlParameter.Optional }
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
            //routing Family Member
            context.Routes.MapHttpRoute(
                name: "GetFamilyMemberResultApi",
                routeTemplate: "api/public/get-family-member",
                defaults: new { controller = "FamilyMember", action = "GetFamilyMembers", id = UrlParameter.Optional }
            );

            context.Routes.MapHttpRoute(
              name: "AddFamilyMemberApi",
              routeTemplate: "api/public/add-family-member",
              defaults: new { controller = "FamilyMember", action = "AddFamilyMember", id = UrlParameter.Optional }
          );

            context.Routes.MapHttpRoute(
               name: "UpdateFamilyMemberApi",
               routeTemplate: "api/public/update-family-member",
               defaults: new { controller = "FamilyMember", action = "UpdateFamilyMember", id = UrlParameter.Optional }
           );

            context.Routes.MapHttpRoute(
              name: "DeleteFamilyMemberApi",
              routeTemplate: "api/public/delete-family-member/{id}",
              defaults: new { controller = "FamilyMember", action = "DeleteFamilyMember", id = UrlParameter.Optional }
           );

            //Routing Achievement
            context.Routes.MapHttpRoute(
                name: "GetAchievementApi",
                routeTemplate: "api/public/get-achievement",
                defaults: new { controller = "Achievement", action = "GetAchievements", id = UrlParameter.Optional }
            );

            context.Routes.MapHttpRoute(
              name: "AddAchievementApi",
              routeTemplate: "api/public/add-achievement",
              defaults: new { controller = "Achievement", action = "AddAchievement", id = UrlParameter.Optional }
          );

            context.Routes.MapHttpRoute(
               name: "UpdateAchievementApi",
               routeTemplate: "api/public/update-achievement",
               defaults: new { controller = "Achievement", action = "UpdateAchievement", id = UrlParameter.Optional }
           );

            context.Routes.MapHttpRoute(
              name: "DeleteAchievementApi",
              routeTemplate: "api/public/delete-achievement/{id}",
              defaults: new { controller = "Achievement", action = "DeleteAchievement", id = UrlParameter.Optional }
           );
            //context.Routes.MapHttpRoute(
            //    name         :"StudentArea_default",
            //    routeTemplate:"StudentArea/{controller}/{action}/{id}",
            //    defaults: new { action = "Index", id = UrlParameter.Optional }
            //);


        }
    }
}