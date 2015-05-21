using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebAPI2Sandbox
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// attribute routes (currently not using attribute routing)
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "ProductsApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional },
				constraints: new { controller = "products" }
			);

			config.Routes.MapHttpRoute(
				name: "PersonsApi",
				routeTemplate: "api/{controller}/{action}/{id}",
				defaults: new { id = RouteParameter.Optional },
				constraints: new { controller = "persons" }
			);

			// place non controller constrained routes here
		}
	}
}
