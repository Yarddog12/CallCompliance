using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.DirectoryServices.AccountManagement;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;

namespace CallCompliance {
	public class RouteConfig {
		public static void RegisterRoutes (RouteCollection routes) {
			routes.IgnoreRoute ("{resource}.axd/{*pathInfo}");

			routes.MapRoute (
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
