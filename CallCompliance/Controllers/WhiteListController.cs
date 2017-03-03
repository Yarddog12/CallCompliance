using System;
using System.Web.Mvc;
using CallCompliance.DAL.Repository.WhiteList;
using CallCompliance.Models;

namespace CallCompliance.Controllers
{
    public class WhiteListController : CallComplianceController {

		// GET: WhiteList
		public ActionResult Index() {
			WhiteListViewModel model = new WhiteListViewModel();
			return View (model);
        }

		[HttpPost]
		public ActionResult SaveWhiteListNumber(WhiteListViewModel vm) {

			ControllerReturnStatus status = ControllerReturnStatus.Success;
			string additionalErrInfo = string.Empty;

			var ad = GetAdInfo ();

			string fullName = ad [0];
			string loginIdentity = ad [1];
			string department = ad [2];

			try {
				var repo = new WhiteListRepository();
				repo.AddWhiteListPhoneNumber(vm.PhoneNumber, loginIdentity, fullName, department, vm.Notes, vm.DncOverride);

			} catch (Exception ex) {
				status = ControllerReturnStatus.Fail;
				if (ex.InnerException != null) {
					if (ex.InnerException.ToString().Contains("duplicate")) {
						additionalErrInfo = " was NOT added to white list because it already is in the white list - by user ";
					}
				}
			}

			// Tell the modal what happened when we tried to save.
			string message = "Phone number: " + vm.PhoneNumber;
			if (additionalErrInfo == string.Empty) {
				additionalErrInfo = " was NOT added to white list by user ";
			}
			message += (status == 0 ? " was successfully added to white list by user " + fullName : additionalErrInfo + fullName);

			string title = (status == 0 ? "Success on adding phone number " + vm.PhoneNumber : "Error on adding phone number " + vm.PhoneNumber);

			var result = new { Status = status, Title = title, Message = message };
			return Json (result, JsonRequestBehavior.AllowGet);
		}
	}
}