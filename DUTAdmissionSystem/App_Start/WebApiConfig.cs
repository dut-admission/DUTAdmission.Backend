using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace DUTAdmissionSystem
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            //<--  AdmissionNews controller -->
            config.Routes.MapHttpRoute(
                "GetAdmissionNewsApi",
                "api/addmissionnews",
                new { controller = "AdmissionNews", action = "GetAdmissionNews" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            
        }
    }
}
