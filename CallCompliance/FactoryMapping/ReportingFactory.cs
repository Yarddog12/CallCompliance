using System;
using CallCompliance.DAL.Models;
using CallCompliance.Models;

namespace CallCompliance.FactoryMapping {
	public class ReportingFactory {

		private static int id { get; set; } = 0;
		public ReportNamesModel Create(cplxCallComplianceReports c) {
			if (c == null) {
				throw new ArgumentNullException ("cplxCallComplianceReports", "No report names for dropdown box returned.");
			}

			return new ReportNamesModel (id++, c.ReportName);
		}
	}
}