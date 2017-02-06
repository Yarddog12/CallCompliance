using System;
using System.Linq;
using System.Web.Mvc;
using CallCompliance.DAL.Repository.Unblock;
using CallCompliance.FactoryMapping;
using CallCompliance.Models;

namespace CallCompliance.Controllers
{
    public class UnblockController : CallComplianceController {

		// GET: Unblock
		public ActionResult Index() {

			var factory = new UnBlockFactory();
			var repo = new UnBlockNumberRepository();

			var data = repo
				.GetExceptionReasonNames ()
				.ToList ()
				.Select (x => factory.Create (x));

			var model = new UnblockViewModel();
			model.ExceptionReasonNames.AddRange(data);

			// TODO: temporary until I map the RequesterId (JBECKWITH), and RequesterName (FullName)
			model.LoginIdentity = User.Identity.Name;

			return View (model);
        }

		[HttpPost]
		public ActionResult SaveUnblockNumber(UnblockViewModel vm) {

			ControllerReturnStatus status = ControllerReturnStatus.Success;

			// TODO: temp until get vm working
			vm.LoginIdentity = "JBECKWITH";			// UserName
			vm.FullName = "John Beckwith";	// FullName
			vm.Department= "App Dev";

			try {
				var repo = new UnBlockNumberRepository();
				repo.AddExceptionPhoneNumber(vm.PhoneNumber, vm.LoginIdentity, vm.FullName, vm.Department, vm.ReasonId, vm.StudentId, vm.NameAssigned, vm.Notes);
				_logger.Info("Phone number " + vm.PhoneNumber + " successfully blocked by user " + vm.FullName);
			}
			catch (Exception ex) {
				status = ControllerReturnStatus.Fail;
				_logger.Error(ex, "Phone number " + vm.PhoneNumber + " could not be blocked by user " + vm.FullName);
			}

			string message = "Phone number: " + vm.PhoneNumber;
			message += (status == 0 ? " was successfully Un-Blocked by user " + vm.FullName : " was NOT Un-Blocked by user " + vm.FullName);

			string title = (status == 0 ? "Success on Un-Blocking phone number " + vm.PhoneNumber : "Error on Un-Blocking phone number " + vm.PhoneNumber);
			
			var result = new { Status = status, Title = title, Message = message};
			return Json (result, JsonRequestBehavior.AllowGet);
		}
	}
}