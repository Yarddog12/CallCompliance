using System;
using System.Web.Mvc;
using CallCompliance.Models;

namespace CallCompliance.Controllers {
	public class HomeController : Controller {
		public ActionResult Index () {
			
			LoginViewModel model = new LoginViewModel();
			model.UserName = "JBECKWITH";
			model.Password = "Johx203101";
			// Load a model from a repository and send it over to the view.	
			return View (model);
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