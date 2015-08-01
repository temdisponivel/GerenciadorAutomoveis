using Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "Padrao",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { controller = "Automovel", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Pesquisa",
                routeTemplate: "{controller}/{action}/{tipo}/{termo}",
                defaults: new { controller = "Automovel", action = "pesquisa", }
            );
        }
    }
}
