using System;
using System.Collections.Generic;

namespace CallCompliance.Models {
	public class ReportingModel : UserManagementModelBase {

		public int ReportingId { get; set; }
		public List<ReportNamesModel> ReportListNames { get; set; } = new List<ReportNamesModel> ();
	}

	public class ReportNamesModel {
		 public int Id { get; set; }
		public string ReportNames { get; set; }
		 
		public ReportNamesModel () { }

		public ReportNamesModel (int id, string reportNames) {
			Id = id;
			ReportNames = reportNames;
		}
	}
}