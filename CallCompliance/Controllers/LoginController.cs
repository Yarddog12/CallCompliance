using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CallCompliance.Models;
using System.DirectoryServices.AccountManagement;

namespace CallCompliance.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index() {
            return View();
        }

		[HttpPost]
		public ActionResult SaveUnblockNumber(LoginViewModel vm) {
			//var result = "dog";
			//return Json (result, JsonRequestBehavior.AllowGet);

			//ControllerReturnStatus status = ControllerReturnStatus.Success;
			string buf = string.Empty;
			var model = new LoginViewModel();

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
			} catch (Exception ex) {
				model.FullName = "Authentication failed";
			}

			string message = "Phone number: " + vm.PhoneNumber;
			message += (status == 0 ? " was successfully Un-Blocked." : " was NOT Un-Blocked.");

			string title = (status == 0 ? "Success on Un-Blocking phone number " + vm.PhoneNumber: "Error on Un-Blocking phone number " + vm.PhoneNumber + " : " + buf);

			var result = new { Status = status, Title = title, Message = message};
			return Json(result, JsonRequestBehavior.AllowGet);
		}
	}
}