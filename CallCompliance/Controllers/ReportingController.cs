using System;
using System.Linq;
using System.Web.Mvc;
using CallCompliance.DAL.Repository.Reporting;
using CallCompliance.FactoryMapping;
using CallCompliance.Models;

using Microsoft.Reporting.WebForms;

namespace CallCompliance.Controllers
{
    public class ReportingController : CallComplianceController {
		// GET: Reporting
		public ActionResult Index() {

			ViewBag.Name = FullName;

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

			try {
				ReportViewer reportViewer = new ReportViewer ();
				ServerReport serverReport = reportViewer.ServerReport;

				reportViewer.ProcessingMode = ProcessingMode.Remote;


				// Set the report server URL and report path
				//reportViewer.ServerReport.ReportServerUrl = new Uri ("http://localhost/ReportServer/");
				serverReport.ReportServerUrl = new Uri ("http://mlk-ssr-d-sq01/Reports/");

				//reportViewer.ServerReport.ReportPath = "/AdventureWorks 2012/Sales_by_Region";
				serverReport.ReportPath = "Call+Compliance%2fODS+Status";

				serverReport.Refresh();

				//reportViewer.ServerReport.ReportPath =
				// "http://mlk-ssr-d-sq01/Reports/Pages/Report.aspx?ItemPath=%2fCall+Compliance%2fODS+Status";
				//reportViewer.ServerReport.ReportServerUrl = new Uri("http://reporting-dev.ultimatemedical.edu/");
				ViewBag.ReportViewer = reportViewer;
			} catch (Exception ex) {

			}
			return View (model);
		}

	    public ViewResult LaunchReport() {
			try {
				ReportViewer reportViewer = new ReportViewer ();
				ServerReport serverReport = reportViewer.ServerReport;

				reportViewer.ProcessingMode = ProcessingMode.Remote;


			    // Set the report server URL and report path
			    serverReport.ReportServerUrl = new Uri("http://reporting-dev.ultimatemedical.edu/");
			    serverReport.ReportPath = "/Reports/Pages/Report.aspx?ItemPath=%2fCall+Compliance%2fODS+Status";

			    //reportViewer.ServerReport.ReportPath = "/AdventureWorks 2012/Sales_by_Region";
			    //reportViewer.ServerReport.ReportServerUrl = new Uri ("http://localhost/ReportServer/");
			    //reportViewer.ServerReport.ReportPath =
				   // "http://mlk-ssr-d-sq01/Reports/Pages/Report.aspx?ItemPath=%2fCall+Compliance%2fODS+Status";
			    //reportViewer.ServerReport.ReportServerUrl = new Uri("http://reporting-dev.ultimatemedical.edu/");
			    ViewBag.ReportViewer = reportViewer;
		    }
		    catch (Exception ex) {
			    
		    }

		    return View();
		    //var result = new { Status = true, Title = "title", Message = "all good" };
		    //return Json (result, JsonRequestBehavior.AllowGet);

		    //return RedirectToAction ("LaunchReport", "Reporting");
	    }
	}


}