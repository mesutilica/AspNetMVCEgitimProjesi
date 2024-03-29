﻿using System.Web.Mvc;
using System.Web.Routing;

namespace AspNetMVCEgitimProjesi.NetFramework
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes(); // özel route tanımlamak için
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "AspNetMVCEgitimProjesi.NetFramework.Controllers" }
            );
        }
    }
}
