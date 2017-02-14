using System;
using System.Web.Mvc;
using CallCompliance.App_Code;
using CallCompliance.Models;

namespace CallCompliance.Controllers {
	public class CoolDownController : CallComplianceController {

		// GET: CoolDown
		public ActionResult Index() {

			var model = new CoolDownViewModel();
			_logger.Info ("CoolDownController/Index()");
			return View (model);
		}

		[HttpPost]
		public ActionResult SaveCoolDownNumber(CoolDownViewModel vm) {

			ControllerReturnStatus status = ControllerReturnStatus.Success;

			vm.FullName      = MyAuth.FullName;
			vm.Department    = MyAuth.Department;
			vm.LoginIdentity = MyAuth.LoginIdentity;

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

