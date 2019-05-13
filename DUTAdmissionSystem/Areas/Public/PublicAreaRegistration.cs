﻿using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Mvc;

namespace DUTAdmissionSystem.Areas.Public
{
    public class PublicAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Public";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            //<<--AdmissionNews controller-->>
            context.Routes.MapHttpRoute(
                name: "GetAdmissionNewsApi",
                routeTemplate: "api/public/admission-news",
                defaults: new { controller = "AdmissionNews", action = "GetAdmissionNews", id = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            context.Routes.MapHttpRoute(
                name: "GetAdmissionNewsByIdApi",
                routeTemplate: "api/public/admission-news/{id}",
                defaults: new { controller = "AdmissionNews", action = "GetAdmissionNewsById", id = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            context.Routes.MapHttpRoute(
                name: "GetSlides",
                routeTemplate: "api/public/slides",
                defaults: new { controller = "Slide", action = "GetSlides", id = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            context.Routes.MapHttpRoute(
                name: "GetSlideById",
                routeTemplate: "api/public/slides/{id}",
                defaults: new { controller = "Slide", action = "GetSlideById", id = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            context.Routes.MapHttpRoute(
                name: "GetUniversityInfo",
                routeTemplate: "api/public/university-info",
                defaults: new { controller = "UniversityInfo", action = "GetUniversityInfo", id = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            context.Routes.MapHttpRoute(
                name: "GetProfileForStudent",
                routeTemplate: "api/public/student-profile",
                defaults: new { controller = "Profile", action = "GetStudentProfile", id = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            context.Routes.MapHttpRoute(
               name: "UpdatePassword",
               routeTemplate: "api/public/student-profile/password",
               defaults: new { controller = "Profile", action = "UpdatePassword", id = RouteParameter.Optional },
               constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Put) }
           );


            //<<--ContactMessage controller-->>
            context.Routes.MapHttpRoute(
               name: "SubmitContactMessageApi",
               routeTemplate: "api/public/contact-message",
               defaults: new { controller = "ContactMessage", action = "SubmitContactMessage" },
               constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) }
           );
        }
    }
}