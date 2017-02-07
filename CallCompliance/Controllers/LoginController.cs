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
			return View(model);
        }

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult Index(LoginViewModel vm) {

			var model = new LoginViewModel();

			if (!string.IsNullOrEmpty(vm.UserName) || !string.IsNullOrEmpty(vm.Password)) {

				try {
					using (var context = new PrincipalContext (ContextType.Domain)) {

						var principal = UserPrincipal.FindByIdentity (context, User.Identity.Name);

						if (principal != null) {
							model.FullName = principal.DisplayName;					// ReqestorName
							model.UserName = principal.SamAccountName.ToUpper ();	// RequestId
							model.Department = "App Dev";							// ReqDepartment TODO: put all of this in a base class, and find department name.
						} else {
							return View(vm);
						}
					}
				}
				catch (Exception ex) {
					return View(vm);
				}
			}
			else {
				return View(vm);
			}

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