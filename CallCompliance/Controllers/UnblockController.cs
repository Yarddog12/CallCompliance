using System;
using System.Linq;
using System.Web.Mvc;
using CallCompliance.DAL.Repository.Unblock;
using CallCompliance.FactoryMapping;
using CallCompliance.Models;

using CallCompliance.App_Code;

namespace CallCompliance.Controllers
{
    public class UnblockController : CallComplianceController {

		// GET: Unblock
		public ActionResult Index() {

			var factory = new UnBlockFactory();
			var repo = new UnBlockNumberRepository();

			// Map the Exception Reason names from the cplx EF class to the ExceptionReasonNamesModel
			var data = repo
				.GetExceptionReasonNames ()
				.ToList ()
				.Select (x => factory.Create (x));

			var model = new UnblockViewModel();

			// Put the list of Exception Reasons in the List for the drop down.
			model.ExceptionReasonNames.AddRange(data);
			return View (model);
        }

		[HttpPost]
		public ActionResult SaveUnblockNumber(UnblockViewModel vm) {

			ControllerReturnStatus status = ControllerReturnStatus.Success;

			vm.FullName      = MyAuth.FullName;
			vm.Department    = MyAuth.Department;
			vm.LoginIdentity = MyAuth.LoginIdentity;

			try {
				var repo = new UnBlockNumberRepository();
				repo.AddExceptionPhoneNumber(vm.PhoneNumber, vm.LoginIdentity, vm.FullName, vm.Department, vm.ReasonId, vm.StudentId, vm.NameAssigned, vm.Notes);
			}
			catch {
				status = ControllerReturnStatus.Fail;
			}

			// Tell the modal what happened when we tried to save.
			string message = "Phone number: " + vm.PhoneNumber;
			message += (status == 0 ? " was successfully Un-Blocked by user " + vm.FullName : " was NOT Un-Blocked by user " + vm.FullName);

			string title = (status == 0 ? "Success on Un-Blocking phone number " + vm.PhoneNumber : "Error on Un-Blocking phone number " + vm.PhoneNumber);
			
			var result = new { Status = status, Title = title, Message = message};
			return Json (result, JsonRequestBehavior.AllowGet);
		}
	}
}