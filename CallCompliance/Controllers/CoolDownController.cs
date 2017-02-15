using System;
using System.Web.Mvc;
using CallCompliance.App_Code;
using CallCompliance.DAL.Repository.CoolDown;
using CallCompliance.Models;

namespace CallCompliance.Controllers {
	public class CoolDownController : CallComplianceController {

		// GET: CoolDown
		public ActionResult Index() {

			var model = new CoolDownViewModel();
			return View (model);
		}
		/// <summary>
		/// User pressed the Save on the Cool down page.
		/// </summary>
		/// <param name="vm"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult SaveCoolDownNumber(CoolDownViewModel vm) {

			ControllerReturnStatus status = ControllerReturnStatus.Success;

			vm.FullName      = MyAuth.FullName;
			vm.Department    = MyAuth.Department;
			vm.LoginIdentity = MyAuth.LoginIdentity;

			try {
				var repo = new CoolDownNumberRepository();
				repo.AddCoolDownPhoneNumber(vm.PhoneNumber, vm.LoginIdentity, vm.FullName, vm.Department, vm.Notes, vm.StudentId, vm.StudentName);
				
			} catch {
				status = ControllerReturnStatus.Fail;
			}

			// Tell the modal what happened when we tried to save.
			string message = "Phone number: " + vm.PhoneNumber;
			message += (status == 0 ? " was successfully Cooled Down by user " + vm.FullName : " was NOT Cooled Down by user " + vm.FullName);

			string title = (status == 0 ? "Success on Cooled Down phone number " + vm.PhoneNumber : "Error on Cooled Down phone number " + vm.PhoneNumber);

			var result = new { Status = status, Title = title, Message = message };
			return Json (result, JsonRequestBehavior.AllowGet);
		}
	}
}

