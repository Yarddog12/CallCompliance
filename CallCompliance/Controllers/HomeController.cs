using System;
using System.Linq;
using System.Web.Mvc;
using CallCompliance.DAL.Repository.Misc;
using CallCompliance.FactoryMapping;
using CallCompliance.Models;

namespace CallCompliance.Controllers {
	public class HomeController : CallComplianceController {
		public ActionResult Index () {
			return View ();
		}

		[HttpPost]
		public ActionResult GetTableName (string phoneNumber) {
			var factory = new SearchPhoneFactory();
			var repo = new SearchPhoneRepository();

			// Map the Table names from the cplx EF class to the SearchPhoneViewModel
			var data = repo
				.GetTableName (phoneNumber)
				.ToList ()
				.Select (x => factory.Create (x));

			var model = new SearchPhoneViewModel();

			// Put the list of Tables that the phone number was found in.
			model.TableNameList.AddRange (data);
			return Json(model.TableNameList);
		}
	}
}