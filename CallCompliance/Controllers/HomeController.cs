using System;
using System.Web.Mvc;
using CallCompliance.Models;

namespace CallCompliance.Controllers {
	public class HomeController : Controller {
		public ActionResult Index () {
			
			LoginViewModel model = new LoginViewModel();
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