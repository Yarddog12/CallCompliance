using System;
using System.Collections.Generic;
using System.Linq;
using CallCompliance.DAL.Models;

namespace CallCompliance.DAL.Repository.Reporting {
	public class ReportingRepository : UserManagementBase {

		public static string ClassNameError = "Error in ReportingRepository ->";

		/// <summary>
		/// This is for Reporting drop down names
		/// </summary>
		/// <returns></returns>
		public IEnumerable<cplxCallComplianceReports> GetReportNames () {

			List<cplxCallComplianceReports> ret = new List<cplxCallComplianceReports> ();
			try {
				using (var dbContext = new CallComplianceReportingModelContainer()) {
					ret = dbContext.GetCallComplianceReports().ToList();
				}
			} catch (Exception ex) {
				_logger.Error (ex, ClassNameError + "GetReportNames ()");
				throw;
			}

			return ret;
		}
	}
}
