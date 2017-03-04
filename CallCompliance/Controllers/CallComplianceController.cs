using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Web.Mvc;
using CallCompliance.DAL.Logging;
using NLog;

namespace CallCompliance.Controllers {
	public class CallComplianceController : Controller {

		protected static Logger _logger = DiagnosticLogging.LoggerInitialization();

		// asp.net identity.

		public enum ControllerReturnStatus : byte {
			Success,
			Fail
		}

		protected List<string> GetAdInfo () {

			List<string> ad = new List<string>();

			using (var context = new PrincipalContext(ContextType.Domain, "ULTIMATEMEDICAL.LOCAL")) {

				try {

					var principal = UserPrincipal.FindByIdentity(context, User.Identity.Name);
					if (principal != null) {

						string[] buf = principal?.DistinguishedName.Split(new[] {"OU="}, StringSplitOptions.None);
						string department = buf?[3].Substring(0, buf[3].Length - 1);

						ad.Add (principal.DisplayName);                 // John Beckwith
						ad.Add (principal.SamAccountName.ToUpper ());   // JBECKWITH
						ad.Add (department);							// Application_Development
					}
				}
				catch (Exception ex) {
					_logger.Error(ex, "Error getting AD information");
				}

				return ad; 
			}
		}

	}
}