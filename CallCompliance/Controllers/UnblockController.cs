using System;
using System.Collections.Generic;
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

			return View (model);
        }

		[HttpPost]
		public ActionResult SaveUnblockNumber(UnblockViewModel vm) {
			var result = "dog";
			return Json (result, JsonRequestBehavior.AllowGet);
			//int userId = 0;
			//// phoneNumber, reqId, reqName, reqDepartment, reasonId, studentId, nameAssigned, notes
			var repo = new UnBlockNumberRepository();
			repo.AddExceptionPhoneNumber("555-1212", "JBECKWITH", "John Beckwith", "App Dev", 8, 0, "Charles", "awesome notes");
			//ControllerReturnStatus status = ControllerReturnStatus.Success;

			//var result = new { UserId = userId, Status = status, Message = "User data for username (" + vm.UserName + ") was successfully " + (vm.IsNew ? "added." : "updated.") };
			//var result = "dog";
			//return Json (result, JsonRequestBehavior.AllowGet);
		}
	}
}