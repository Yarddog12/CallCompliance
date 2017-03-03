using System;
using System.Linq;
using System.Web.Mvc;
using CallCompliance.DAL.Repository.DNC;
using CallCompliance.FactoryMapping;
using CallCompliance.Models;

namespace CallCompliance.Controllers
{
    public class DNCController : CallComplianceController {

		// GET: Dnc
		public ActionResult Index() {


			//var factory = new DncFactory();
			//var repo = new DncRepository();

			//// Map the Exception Reason names from the cplx EF class to the ExceptionReasonNamesModel
			//var data = repo
			//	.GetDncNames()
			//	.ToList ()
			//	.Select (x => factory.Create (x));

			var model = new DncViewModel();

			// Put the list of DNC names in the List for the drop down.
			//model.DncListNames.AddRange (data);
			return View (model);
		}

		[HttpPost]
		public ActionResult SaveDncNumber(DncViewModel vm) {

			ControllerReturnStatus status = ControllerReturnStatus.Success;
			string additionalErrInfo = string.Empty;

			var ad = GetAdInfo ();

			string fullName = ad [0];
			string loginIdentity = ad [1];
			string department = ad [2];

			try {
				var repo = new DncRepository();
				repo.AddDncPhoneNumber(vm.PhoneNumber, loginIdentity, fullName, department, vm.DncNameId);
			} catch (Exception ex) {
				status = ControllerReturnStatus.Fail;
				if (ex.InnerException != null) {
					if (ex.InnerException.ToString ().Contains ("duplicate")) {
						additionalErrInfo = " was NOT added to white list because it already is in the white list - by user ";
					}
				}
			}

			if (additionalErrInfo == string.Empty) {
				additionalErrInfo = " was NOT added to white list by user ";
			}

			// Tell the modal what happened when we tried to save.
			string message = "Phone number: " + vm.PhoneNumber;
			message += (status == 0 ? " was successfully added to DNC by user " + fullName : additionalErrInfo + fullName);

			string title = (status == 0 ? "Success on adding to DNC, phone number " + vm.PhoneNumber : "Error on DNC phone number " + vm.PhoneNumber);

			var result = new { Status = status, Title = title, Message = message };
			return Json (result, JsonRequestBehavior.AllowGet);
		}
	}
}