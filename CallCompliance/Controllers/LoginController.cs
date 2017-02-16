using System;
using System.Web.Mvc;
using CallCompliance.Models;
using System.DirectoryServices.AccountManagement;

namespace CallCompliance.Controllers
{
    public class LoginController : CallComplianceController {

		// GET: Login
		public ActionResult Index() {
			ViewBag.Name = FullName;
			return View ();
        }

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult Index(LoginViewModel vm) {

			string userPrincipalName = vm.UserName + "@" + "ULTIMATEMEDICAL.LOCAL";
			string password = vm.Password;

			try {
				using (var context = new PrincipalContext(ContextType.Domain, "ULTIMATEMEDICAL.LOCAL")) {

					if (context.ValidateCredentials(userPrincipalName, password)) {
						var principal = UserPrincipal.FindByIdentity (context, vm.UserName);
						string [] buf = principal?.DistinguishedName.Split (new [] { "OU=" }, StringSplitOptions.None);

						string department = buf? [3].Substring (0, buf [3].Length - 1);
						string fullName = principal?.DisplayName;
						//App_Code.MyAuth.FullName = fullName;
						//App_Code.MyAuth.Department = department;
						//App_Code.MyAuth.LoginIdentity = principal?.SamAccountName.ToUpper();

						_logger.Info(principal?.DisplayName + " from Department " + department + " just logged in.");
						FullName = fullName;
						Department = department;
						LoginIdentity = principal?.SamAccountName.ToUpper ();
						return RedirectToAction("Welcome", "Home");
					}
				}
			}
			catch (Exception ex) {
				_logger.Error(ex, "login failed.");
				return View (vm);
			}

			// This is good.
			return View (vm);
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