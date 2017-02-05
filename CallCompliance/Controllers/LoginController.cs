using System;
using System.Web.Mvc;
using CallCompliance.Models;
using System.DirectoryServices.AccountManagement;

namespace CallCompliance.Controllers
{
    public class LoginController : CallComplianceController {

		public enum ControllerReturnStatus : byte {
			Success,
			Fail
		}

		// GET: Login
		public ActionResult Index() {

			var model = new LoginViewModel();
			model.Password = "Johx203101";
			model.UserName = "jbeckwith";
			return View(model);
        }

		[HttpPost]
		public ActionResult ValidateLogin(LoginViewModel vm) {

			bool status = true;
			var model = new LoginViewModel();

			if (!string.IsNullOrEmpty(vm.UserName) || !string.IsNullOrEmpty(vm.Password)) {
				try {

					using (var context = new PrincipalContext(ContextType.Domain)) {
						if (context.ValidateCredentials(vm.UserName, vm.Password)) {
							var principal = UserPrincipal.FindByIdentity(context, User.Identity.Name);
							if (principal != null) {
								model.FullName = principal.DisplayName; // RequestName
								model.UserName = principal.SamAccountName.ToUpper(); // RequestId
								model.ReqDepartment = "App Dev"; // TODO: put all of this in a base class, and find department name.
							}
						}
						else {
							model.FullName = "Authentication failed";
							status = false;
						}
					}
				}
				catch (Exception ex) {
					model.FullName = "Authentication failed";
					status = false;
				}
			}
			else {
				model.FullName = "Authentication failed";
				status = false;
			}

			string message = (!status ? "Login Failed for user " + vm.UserName : "Welcome to the Call Compliance Portal, " + model.FullName + "!");
			string title   = (!status ? "Login Failed" : "Login Successful.");

			var result = new { Status = status, Title = title, Message = message, DisplayName = model.FullName, UserName = vm.UserName };
			return Json(result, JsonRequestBehavior.AllowGet);
		}
	}
}