using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace NameCost.WebAPI
{
	/// <summary>
	/// 
	/// </summary>
	public static class WebApiConfig
	{
		/// <summary>
		/// Registers the specified configuration.
		/// </summary>
		/// <param name="config">The configuration.</param>
		public static void Register(HttpConfiguration config)
		{
			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				 name: "swagger_root",
				 routeTemplate: "",
				 defaults: null,
				 constraints: null,
				 handler: new RedirectHandler((message => message.RequestUri.ToString()), "swagger"));
		}
	}
}
