using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Web.Mvc;
using CallCompliance.DAL.Repository.Unblock;
using CallCompliance.FactoryMapping;
using CallCompliance.Models;

namespace CallCompliance.Controllers
{
    public class UnblockController : Controller
    {

		public enum ControllerReturnStatus : byte {
			Success,
			Fail
		}

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

			// move into a base class
			try {

				using (var context = new PrincipalContext(ContextType.Domain)) {
					var principal = UserPrincipal.FindByIdentity(context, User.Identity.Name);
					if (principal != null) {
						model.RequestName = principal.DisplayName;
						model.RequestId = principal.SamAccountName.ToUpper();
						// TODO: put all of this in a base class, and find department name.
						model.ReqDepartment = "App Dev";
					}
				}
			}
			catch (Exception ex) {
				model.FullName = "Authentication failed";
			}

			return View (model);
        }

		[HttpPost]
		public ActionResult SaveUnblockNumber(UnblockViewModel vm) {
			//var result = "dog";
			//return Json (result, JsonRequestBehavior.AllowGet);

			ControllerReturnStatus status = ControllerReturnStatus.Success;
			string buf = string.Empty;

			try {
				var repo = new UnBlockNumberRepository();
				repo.AddExceptionPhoneNumber(vm.PhoneNumber, vm.RequestId, vm.RequestName, vm.ReqDepartment, vm.ReasonId, vm.StudentId, vm.NameAssigned, vm.Notes);
			}
			catch (Exception ex) {
				status = ControllerReturnStatus.Fail;
				buf = ex.Message + ex.InnerException;
			}

			string message = "Phone number: " + vm.PhoneNumber;
			message += (status == 0 ? " was successfully Un-Blocked." : " was NOT Un-Blocked.");

			string title = (status == 0 ? "Success on Un-Blocking phone number " + vm.PhoneNumber: "Error on Un-Blocking phone number " + vm.PhoneNumber + " : " + buf);
			
			var result = new { Status = status, Title = title, Message = message};
			return Json (result, JsonRequestBehavior.AllowGet);
		}
	}
}