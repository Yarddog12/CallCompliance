using System;
using System.Web.Mvc;

namespace CallCompliance.Controllers {
	public class HomeController : CallComplianceController {
		public ActionResult Index () {
			ViewBag.Name = FullName;
			return View ();
		}

		public ActionResult FindPhoneNumber() {

			return View();
		}
	}
}