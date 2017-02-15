using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CallCompliance.DAL.Repository.Reporting;
using CallCompliance.FactoryMapping;
using CallCompliance.Models;

namespace CallCompliance.Controllers
{
    public class ReportingController : CallComplianceController {
		// GET: Reporting
		public ActionResult Index() {

			var factory = new ReportingFactory();
			var repo = new ReportingRepository();

			// Map the Exception Reason names from the cplx EF class to the ExceptionReasonNamesModel
			var data = repo
				.GetReportNames()
				.ToList ()
				.Select (x => factory.Create (x));

			var model = new ReportingModel();

			// Put the list of Exception Reasons in the List for the drop down.
			model.ReportListNames.AddRange (data);
			return View (model);
		}
	}
}