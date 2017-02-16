using System;
using System.Web.Mvc;
using CallCompliance.DAL.Repository.WhiteList;
using CallCompliance.Models;

namespace CallCompliance.Controllers
{
    public class WhiteListController : CallComplianceController {

		// GET: WhiteList
		public ActionResult Index() {
			ViewBag.Name = FullName;
			return View ();
        }

		[HttpPost]
		public ActionResult SaveWhiteListNumber(WhiteListViewModel vm) {

			ControllerReturnStatus status = ControllerReturnStatus.Success;

			vm.FullName      = FullName;
			vm.Department    = Department;
			vm.LoginIdentity = LoginIdentity;

			try {
				var repo = new WhiteListRepository();
				repo.AddWhiteListPhoneNumber(vm.PhoneNumber, vm.LoginIdentity, vm.FullName, vm.Department, vm.Notes);

			} catch {
				status = ControllerReturnStatus.Fail;
			}

			// Tell the modal what happened when we tried to save.
			string message = "Phone number: " + vm.PhoneNumber;
			message += (status == 0 ? " was successfully added to white list by user " + vm.FullName : " was NOT added to white list by user " + vm.FullName);

			string title = (status == 0 ? "Success on adding phone number " + vm.PhoneNumber : "Error on adding phone number " + vm.PhoneNumber);

			var result = new { Status = status, Title = title, Message = message };
			return Json (result, JsonRequestBehavior.AllowGet);
		}
	}
}