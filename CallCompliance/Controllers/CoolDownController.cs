﻿using System;
using System.Web.Mvc;
using CallCompliance.DAL.Repository.CoolDown;
using CallCompliance.Models;
using static CallCompliance.Fx.Formatters;

namespace CallCompliance.Controllers {
	public class CoolDownController : CallComplianceController {

		// GET: CoolDown
		public ActionResult Index() {
			CoolDownViewModel model = new CoolDownViewModel();
			return View (model);
		}
		/// <summary>
		/// User pressed the Save on the Cool down page.
		/// </summary>
		/// <param name="vm"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult SaveCoolDownNumber(CoolDownViewModel vm) {

			ControllerReturnStatus status = ControllerReturnStatus.Success;

			var ad = GetAdInfo ();

			string fullName			= ad [0];
			string loginIdentity	= ad [1];
			string department	= ad [2];

			try {
				var repo = new CoolDownNumberRepository();
				repo.AddCoolDownPhoneNumber(vm.PhoneNumber, loginIdentity, fullName, department, vm.Notes, vm.StudentId, vm.StudentName);
				
			} catch {
				status = ControllerReturnStatus.Fail;
			}

			string formattedPhone = Helpers.FormatPhoneNumber(vm.PhoneNumber);

			// Tell the modal what happened when we tried to save.
			string message = "Phone number: " + formattedPhone;
			message += (status == 0 ? " was successfully Cooled Down by user " + fullName : " was NOT Cooled Down by user " + fullName);

			string title = (status == 0 ? "Success on Cooled Down phone number " + formattedPhone : "Error on Cooled Down phone number " + formattedPhone);

			var result = new { Status = status, Title = title, Message = message };
			return Json (result, JsonRequestBehavior.AllowGet);
		}
	}
}

