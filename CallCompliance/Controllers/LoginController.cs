using System;
using System.Web.Mvc;
using CallCompliance.Models;
using System.DirectoryServices.AccountManagement;

namespace CallCompliance.Controllers
{
    public class LoginController : CallComplianceController {

		// GET: Login
		public ActionResult Index() {

			var model = new LoginViewModel();
			model.Password = "Johx203101";
			model.UserName = "JBECKWITH";
			return View(model);
        }

		[HttpPost]
		public ActionResult ValidateLogin(LoginViewModel vm) {

			bool status = true;
			var model = new LoginViewModel();


			if (!string.IsNullOrEmpty(vm.UserName) || !string.IsNullOrEmpty(vm.Password)) {

				try {
					using (var context = new PrincipalContext (ContextType.Domain)) {

						var principal = UserPrincipal.FindByIdentity (context, User.Identity.Name);

						if (principal != null) {
							model.FullName = principal.DisplayName;					// ReqestorName
							model.UserName = principal.SamAccountName.ToUpper ();	// RequestId
							model.Department = "App Dev";						// ReqDepartment TODO: put all of this in a base class, and find department name.
						} else {
							model.FullName = "Authentication failed vm.UserName1 " + vm.UserName + " " + vm.Password;
							status = false;
						}
					}
						//using (var context = new PrincipalContext(ContextType.Domain)) {
						//	if (context.ValidateCredentials(vm.UserName, vm.Password)) {
						//		var principal = UserPrincipal.FindByIdentity(context, User.Identity.Name);
						//		if (principal != null) {
						//			model.FullName = principal.DisplayName; // RequestName
						//			model.UserName = principal.SamAccountName.ToUpper(); // RequestId
						//			model.ReqDepartment = "App Dev"; // TODO: put all of this in a base class, and find department name.
						//		}
						//	}
						//	else {
						//		model.FullName = "Authentication failed vm.UserName1 " + vm.UserName + " " + vm.Password;
						//		status = false;
						//	}
						//}
					}
				catch (Exception ex) {
					model.FullName = "Authentication failed vm.UserName2 " + vm.UserName + " " + vm.Password + " :" + ex.Message + " inner:";
					status = false;
				}
			}
			else {
				model.FullName = "Authentication failed vm.UserName3 " + vm.UserName + " " + vm.Password;
				status = false;
			}

			string message = (!status ? "Login Failed for user " + model.FullName : "Welcome to the Call Compliance Portal, " + model.FullName + "!");
			string title   = (!status ? "Login Failed" : "Login Successful.");

			var result = new { Status = status, Title = title, Message = message, DisplayName = model.FullName, UserName = vm.UserName };
			return Json(result, JsonRequestBehavior.AllowGet);
		}
	}
}