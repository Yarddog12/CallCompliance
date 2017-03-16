using System.Web;
using System.Web.Optimization;

namespace CallCompliance {
	public class BundleConfig {
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles (BundleCollection bundles) {
			bundles.Add (new ScriptBundle ("~/bundles/jquery").Include (
						"~/Scripts/jquery-{version}.js",
						"~/Scripts/jquery.modal.js",
						"~/Scripts/tether.js",
						"~/Scripts/Uma.Core.js"));

			bundles.Add (new ScriptBundle ("~/bundles/jqueryval").Include (
						"~/Scripts/jquery.validate*",
						"~/Scripts/underscore.js"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
			bundles.Add (new ScriptBundle ("~/bundles/modernizr").Include (
						"~/Scripts/modernizr-*"));

			bundles.Add (new ScriptBundle ("~/bundles/bootstrap").Include (
					  "~/Scripts/bootstrap.js",
					  "~/Scripts/respond.js",
					  "~/Scripts/knockout-{version}.js",
                      "~/Scripts/knockout.mapping-latest.js",
					  "~/Scripts/KnockOutExtensions.js",
					  "~/Scripts/Uma.validation.js"));

			bundles.Add (new StyleBundle ("~/Content/css").Include (
					  "~/Content/tether.css",
					  "~/Content/Bootstrap/bootstrap.css",
					  "~/Content/font-awesome.css",
                      "~/Content/site.css",
					  "~/Content/jquery.modal.css"));
			
			// C3's charting (wraps D3)
			bundles.Add (new StyleBundle ("~/Content/charts").Include (
					  "~/Content/c3.min.css"));
		}
	}
}
