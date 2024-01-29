using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly_Video_Rental_App
{
    /// <summary>
    /// Configuration fo the routing rules in our application
    /// </summary>
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*
             * If the URL does not include any of the elements provided, it will be passed to the Home controller.
             * If the URL has the controller but not the action, it will be handle by the index action.
             * Id is set to an optional parameter.
            */
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
