using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace retro_bank
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "clientes/id",
               url: "clientes/{id}",
               defaults: new { controller = "Home", action = "Get" }
           );

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "clientes/id/alterar",
                url: "clientes/{id}/alterar",
                defaults: new { controller = "Home", action = "Alterar" }
            );

            routes.MapRoute(
                   name: "clientes",
                   url: "clientes",
                   defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
                   
                        
           

            /*

            


            

    
    */


        }
    }
}
