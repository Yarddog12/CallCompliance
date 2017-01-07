using System;
using System.Web.Mvc;

namespace CallCompliance.Controllers {
	public class HomeController : Controller {
		public ActionResult Index () {
		// Load a model from a repository and send it over to the view.	
		return View ();
		}

		public ActionResult About () {
			ViewBag.Message = "Your application description page.";

			return View ();
		}

		public ActionResult Contact () {
			ViewBag.Message = "Your contact page.";

			return View ();
		}
	}
}