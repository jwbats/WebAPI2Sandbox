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
				"ProductsControllerRoute",
				"api/products/{id}",
				new { controller = "products", id = RouteParameter.Optional }
			);

			config.Routes.MapHttpRoute(
				"PersonsControllerRoute",
				"api/persons/{action}/{id}",
				new { controller = "persons", id = RouteParameter.Optional }
			);

			// place non controller constrained routes here
		}
	}
}
