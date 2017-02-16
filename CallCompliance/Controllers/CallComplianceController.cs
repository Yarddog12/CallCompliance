using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using CallCompliance.DAL.Logging;
using NLog;

namespace CallCompliance.Controllers
{
    public class CallComplianceController : Controller {

		protected static Logger _logger = DiagnosticLogging.LoggerInitialization();

		protected static string LoginIdentity { get; set; }
		protected static string Department { get; set; }
		protected static string FullName { get; set; }

		public enum ControllerReturnStatus : byte {
			Success,
			Fail
		}

	}
}