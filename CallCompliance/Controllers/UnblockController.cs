using System;
using System.Linq;
using System.Web.Mvc;
using CallCompliance.DAL.Repository.Unblock;
using CallCompliance.FactoryMapping;
using CallCompliance.Models;
using static CallCompliance.Fx.Formatters;

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

			var ad = GetAdInfo();

			string fullName      = ad[0];
			string loginIdentity = ad[1];
			string department    = ad[2];

			try {
				var repo = new UnBlockNumberRepository();
				repo.AddExceptionPhoneNumber(vm.PhoneNumber, loginIdentity, fullName, department, vm.ReasonId, vm.StudentId, vm.NameAssigned, vm.Notes, vm.IsStudent);
			}
			catch {
				status = ControllerReturnStatus.Fail;
			}

			// Tell the modal what happened when we tried to save.
			string formattedPhone = Helpers.FormatPhoneNumber(vm.PhoneNumber);

			string message = "Phone number: " + formattedPhone;
			message += (status == 0 ? " was successfully Un-Blocked by user " + fullName : " was NOT Un-Blocked by user " + fullName);

			string title = (status == 0 ? "Success on Un-Blocking phone number " + formattedPhone : "Error on Un-Blocking phone number " + formattedPhone);
			
			var result = new { Status = status, Title = title, Message = message};
			return Json (result, JsonRequestBehavior.AllowGet);
		}
	}
}