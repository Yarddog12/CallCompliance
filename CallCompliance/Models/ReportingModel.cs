using System;
using System.Collections.Generic;

namespace CallCompliance.Models {
	public class ReportingModel : UserManagementModelBase {

		public string SelectedReportName { get; set; }
		public List<ReportNamesModel> ReportListNames { get; set; } = new List<ReportNamesModel> ();
	}

	public class ReportNamesModel {
		public string ReportName { get; set; }
		 
		public ReportNamesModel () { }

		public ReportNamesModel (string reportNames) {
			ReportName = reportNames;
		}
	}
}