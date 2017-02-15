using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CallCompliance.App_Code;
using CallCompliance.DAL.Repository.Unblock;
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

			vm.FullName      = MyAuth.FullName;
			vm.Department    = MyAuth.Department;
			vm.LoginIdentity = MyAuth.LoginIdentity;

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