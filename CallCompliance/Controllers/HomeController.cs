using System;
using System.Web.Mvc;

namespace CallCompliance.Controllers {
	public class HomeController : CallComplianceController {
		public ActionResult Index () {
			ViewBag.Name = FullName;
			return View ();
		}

		//public ActionResult Welcome() {

		//	ViewBag.Name = FullName;
		//	return View ();
		//}
	}
}