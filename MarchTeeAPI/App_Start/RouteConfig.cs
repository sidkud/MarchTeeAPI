using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MarchTeeAPI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Grey",
                url: "grey",
                defaults: new { controller = "Home", action = "Grey" }//,
                //constraints: new { id = @"\d+" }
            );

            routes.MapRoute(
                  name: "Blue",
                  url: "blue",
                  defaults: new { controller = "Home", action = "Blue" }//,
                //constraints: new { id = @"\d+" }
              );

            routes.MapRoute(
               name: "Black",
               url: "black",
               defaults: new { controller = "Home", action = "Black" }//,
                //constraints: new { id = @"\d+" }
           );

            routes.MapRoute(
              name: "Checkout",
              url: "checkout",
              defaults: new { controller = "Home", action = "CheckOut" }//,
                //constraints: new { id = @"\d+" }
          );

            routes.MapRoute(
              name: "Order",
              url: "order",
              defaults: new { controller = "Home", action = "Order" }//,
                //constraints: new { id = @"\d+" }
          );

            routes.MapRoute(
              name: "OrderCancel",
              url: "ordercancel",
              defaults: new { controller = "Home", action = "OrderCancel" }//,
                //constraints: new { id = @"\d+" }
          );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}