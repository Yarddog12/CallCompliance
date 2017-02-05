using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NLog;

namespace CallCompliance {
	public class MvcApplication : System.Web.HttpApplication {

		private static Logger _logger = LogManager.GetCurrentClassLogger();
		protected void Application_Start () {
			AreaRegistration.RegisterAllAreas ();
			FilterConfig.RegisterGlobalFilters (GlobalFilters.Filters);
			RouteConfig.RegisterRoutes (RouteTable.Routes);
			BundleConfig.RegisterBundles (BundleTable.Bundles);
		}
	}
}
