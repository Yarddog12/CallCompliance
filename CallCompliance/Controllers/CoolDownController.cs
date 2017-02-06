using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CallCompliance.Models;

namespace CallCompliance.Controllers {
	public class CoolDownController : CallComplianceController {

		// GET: CoolDown
		public ActionResult Index() {
			var model = new CoolDownViewModel();

			// TODO: temporary until I map the RequesterId (JBECKWITH), and RequesterName (FullName)
			model.LoginIdentity = User.Identity.Name;

			return View(model);

		}

		[HttpPost]
		public ActionResult SaveCoolDownNumber(CoolDownViewModel vm) {

			ControllerReturnStatus status = ControllerReturnStatus.Success;

			// TODO: temp until get vm working
			vm.LoginIdentity = "JBECKWITH";         // UserName
			vm.FullName = "John Beckwith";  // FullName
			vm.Department = "App Dev";

			try {
				//var repo = new UnBlockNumberRepository ();
				//repo.AddExceptionPhoneNumber (vm.PhoneNumber, vm.LoginIdentity, vm.FullName, vm.Department, vm.ReasonId, vm.StudentId, vm.NameAssigned, vm.Notes);
				_logger.Info ("Phone number " + vm.PhoneNumberCoolDown + " successfully Cooled Down by user " + vm.FullName);
			} catch (Exception ex) {
				status = ControllerReturnStatus.Fail;
				_logger.Error (ex, "Phone number " + vm.PhoneNumberCoolDown + " could not be Cooled Down by user " + vm.FullName);
			}

			string message = "Phone number: " + vm.PhoneNumberCoolDown;
			message += (status == 0 ? " was successfully Cooled Down by user " + vm.FullName : " was NOT Cooled Down by user " + vm.FullName);

			string title = (status == 0 ? "Success on Cooled Down phone number " + vm.PhoneNumberCoolDown : "Error on Cooled Down phone number " + vm.PhoneNumberCoolDown);

			var result = new { Status = status, Title = title, Message = message };
			return Json (result, JsonRequestBehavior.AllowGet);
		}
	}
}

