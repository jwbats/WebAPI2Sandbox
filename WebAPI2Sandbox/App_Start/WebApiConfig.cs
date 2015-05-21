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
			// Web API configuration and services

			// Web API routes
			config.MapHttpAttributeRoutes();

			// Place route with {action} on top, so it matches first.
			config.Routes.MapHttpRoute(
				name: "PersonsApi",
				routeTemplate: "api/{controller}/{action}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
			
			// Follow up with route that does not contain {action}.
			config.Routes.MapHttpRoute(
				name: "ProductsApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			
		}
	}
}
