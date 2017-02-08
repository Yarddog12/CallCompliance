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
			_logger.Info ("LoginController/Index()");
			return View(model);

        }

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult Index(LoginViewModel vm) {

			var model = new LoginViewModel();

			string userPrincipalName = vm.UserName + "@" + "ULTIMATEMEDICAL.LOCAL";
			string password = vm.Password;

			try {
				using (var context = new PrincipalContext(ContextType.Domain, "ULTIMATEMEDICAL.LOCAL")) {
					_logger.Info ("BEFORE context.ValidateCredentials(" + userPrincipalName + "," + password + ")");
					if (context.ValidateCredentials(userPrincipalName, password)) {
						_logger.Info ("BEFORE principal " );
						var principal = UserPrincipal.FindByIdentity (context, userPrincipalName);
						_logger.Info("AFTER " + principal?.GivenName);
						return RedirectToAction("Welcome", "Home");
					}
				}
			}
			catch (Exception ex) {
				_logger.Error(ex, "login failed.");
				return View (vm);
			}


			//if (!string.IsNullOrEmpty(vm.UserName) || !string.IsNullOrEmpty(vm.Password)) {
			//	_logger.Info ("LoginController/Index(LoginViewModel vm) past if null check");
			//	try {
			//		using (var context = new PrincipalContext (ContextType.Domain)) {

			//			var principal = UserPrincipal.FindByIdentity (context, User.Identity.Name);
			//			_logger.Info ("LoginController/Index(LoginViewModel vm) principal = " + principal);
			//			if (principal != null) {
			//				model.FullName = principal.DisplayName;					// ReqestorName
			//				model.UserName = principal.SamAccountName.ToUpper ();	// RequestId
			//				model.Department = "App Dev";                           // ReqDepartment TODO: put all of this in a base class, and find department name.
			//				_logger.Info ("LoginController/Index(LoginViewModel vm) principal.DisplayName = " + principal.DisplayName);
			//			} else {
			//				_logger.Info("LoginController/Index(LoginViewModel vm principle must be null");
			//				return View(vm);
			//			}
			//		}
			//	}
			//	catch (Exception ex) {
			//		_logger.Error(ex,"LoginController/Index(LoginViewModel vm principle must be null");
			//		return View(vm);
			//	}
			//}
			//else {
			//	_logger.Info ("LoginController/Index(LoginViewModel vm values must be null");
			//	return View(vm);
			//}

			// This is good.
			return RedirectToAction("Welcome", "Home");
		}

		// POST: /Account/LogOff  (Rick's logout is in his business layer.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult LogOff() {
			//HttpContext.GetOwinContext().Authentication;

			// I need to wipe the cookie when logging out.
			return RedirectToAction ("Index", "Home");
		}
	}
}