using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CallCompliance.DAL.Models;
using CallCompliance.DAL.Repository.Admin;
using CallCompliance.Models;

namespace CallCompliance.Controllers
{
    public class AdminController : CallComplianceController {

		// GET: Admin
		public ActionResult Index() {

			AdminViewModel model = new AdminViewModel ();

			try {
				var repo = new AdminRepository ();
				var ret = repo.GetCallCap ();
				model = MapToModel (ret);

			} catch (Exception ex) {
				_logger.Error (ex, "Failed in GetCallCaps, AdminController");
			}

			return View (model);
        }

		[HttpPost]
		public ActionResult SaveCallCaps(AdminViewModel vm) {

			ControllerReturnStatus status = ControllerReturnStatus.Success;

			var ad = GetAdInfo ();

			string fullName = ad [0];
			string loginIdentity = ad [1];
			string department = ad [2];

			try {
				var repo = new AdminRepository();
				repo.UpdateCallCap (vm.ParmName1,  vm.ParmValue1, fullName);
				repo.UpdateCallCap (vm.ParmName2,  vm.ParmValue2, fullName);
				repo.UpdateCallCap (vm.ParmName3,  vm.ParmValue3, fullName);
				repo.UpdateCallCap (vm.ParmName4,  vm.ParmValue4, fullName);
				repo.UpdateCallCap (vm.ParmName5,  vm.ParmValue5, fullName);
				repo.UpdateCallCap (vm.ParmName6,  vm.ParmValue6, fullName);
				repo.UpdateCallCap (vm.ParmName7,  vm.ParmValue7, fullName);
				repo.UpdateCallCap (vm.ParmName8,  vm.ParmValue8, fullName);
				repo.UpdateCallCap (vm.ParmName9,  vm.ParmValue9, fullName);
				repo.UpdateCallCap (vm.ParmName10, vm.ParmValue10, fullName);
				repo.UpdateCallCap (vm.ParmName11, vm.ParmValue11, fullName);
				repo.UpdateCallCap (vm.ParmName12, vm.ParmValue12, fullName);

			} catch {
				status = ControllerReturnStatus.Fail;
			}

			// Tell the modal what happened when we tried to save.
			string message = "Call Cap Update";
			message += (status == 0 ? " was successfully updated by user " + fullName : " was NOT updated by user " + fullName);

			string title = (status == 0 ? "Success on Call Cap Update" : "Error on Call Cap Update bu " + fullName);

			var result = new { Status = status, Title = title, Message = message };
			return Json (result, JsonRequestBehavior.AllowGet);
		}

		//public ActionResult GetCallCaps() {

		//	AdminViewModel model = new AdminViewModel();

		//	try {
		//		var repo = new AdminRepository ();
		//		var ret = repo.GetCallCap();
		//		model = MapToModel(ret);

		//	} catch (Exception ex) {
		//		_logger.Error (ex, "Failed in GetCallCaps, AdminController");
		//	}

		//	return View(model);
		//}

	    private AdminViewModel MapToModel(List<cplxParametersValues> model) {

			AdminViewModel mod = new AdminViewModel();
		    mod.ParmName1 = model[0].ParameterName;
		    mod.ParmValue1 = model[0].ParameterValue;
			mod.ParmName2 = model [1].ParameterName;
			mod.ParmValue2 = model [1].ParameterValue;
			mod.ParmName3= model [2].ParameterName;
			mod.ParmValue3 = model [2].ParameterValue;
			mod.ParmName4 = model [3].ParameterName;
			mod.ParmValue4 = model [3].ParameterValue;
			mod.ParmName5 = model [4].ParameterName;
			mod.ParmValue5 = model [4].ParameterValue;
			mod.ParmName6 = model [5].ParameterName;
			mod.ParmValue6 = model [5].ParameterValue;
			mod.ParmName7 = model [6].ParameterName;
			mod.ParmValue7 = model [6].ParameterValue;
			mod.ParmName8 = model [7].ParameterName;
			mod.ParmValue8 = model [7].ParameterValue;
			mod.ParmName9 = model [8].ParameterName;
			mod.ParmValue9 = model [8].ParameterValue;
			mod.ParmName10 = model [9].ParameterName;
			mod.ParmValue10 = model [9].ParameterValue;
			mod.ParmName11 = model [10].ParameterName;
			mod.ParmValue11 = model [10].ParameterValue;
			mod.ParmName12 = model [11].ParameterName;
			mod.ParmValue12 = model [11].ParameterValue;

		    return mod;
	    }
	}
}