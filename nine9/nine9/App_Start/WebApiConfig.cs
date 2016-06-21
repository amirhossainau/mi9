using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace nine9
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { controller="Ni9", id = RouteParameter.Optional }
            );
        }
    }
}
