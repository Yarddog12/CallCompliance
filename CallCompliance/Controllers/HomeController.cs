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
			var factory = new MiscFactory();
			var repo = new MiscRepository();

			// Map the Exception Reason names from the cplx EF class to the ExceptionReasonNamesModel
			var data = repo
				.GetTableName (phoneNumber)
				.ToList ()
				.Select (x => factory.Create (x));

			var model = new MiscViewModel();

			// Put the list of Exception Reasons in the List for the drop down.
			model.TableNameList.AddRange (data);
			return Json(model.TableNameList);
		}
	}
}