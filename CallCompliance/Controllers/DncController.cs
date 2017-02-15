using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CallCompliance.App_Code;
using CallCompliance.DAL.Repository.DNC;
using CallCompliance.DAL.Repository.Unblock;
using CallCompliance.FactoryMapping;
using CallCompliance.Models;

namespace CallCompliance.Controllers
{
    public class DNCController : CallComplianceController {

		// GET: Dnc
		public ActionResult Index() {

			var factory = new DncFactory();
			var repo = new DncRepository();

			// Map the Exception Reason names from the cplx EF class to the ExceptionReasonNamesModel
			var data = repo
				.GetDncNames()
				.ToList ()
				.Select (x => factory.Create (x));

			var model = new DncViewModel();

			// Put the list of DNC names in the List for the drop down.
			model.DncListNames.AddRange (data);
			return View (model);
		}

		[HttpPost]
		public ActionResult SaveDncNumber(DncViewModel vm) {

			ControllerReturnStatus status = ControllerReturnStatus.Success;

			vm.FullName      = MyAuth.FullName;
			vm.Department    = MyAuth.Department;
			vm.LoginIdentity = MyAuth.LoginIdentity;

			try {
				var repo = new DncRepository();
				repo.AddDncPhoneNumber(vm.PhoneNumber, vm.LoginIdentity, vm.FullName, vm.Department, vm.DncNameId);
			} catch {
				status = ControllerReturnStatus.Fail;
			}

			// Tell the modal what happened when we tried to save.
			string message = "Phone number: " + vm.PhoneNumber;
			message += (status == 0 ? " was successfully added to DNC by user " + vm.FullName : " was NOT added to DNC by user " + vm.FullName);

			string title = (status == 0 ? "Success on adding to DNC, phone number " + vm.PhoneNumber : "Error on DNC phone number " + vm.PhoneNumber);

			var result = new { Status = status, Title = title, Message = message };
			return Json (result, JsonRequestBehavior.AllowGet);
		}
	}
}