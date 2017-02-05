using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CallCompliance.Controllers
{
    public class ReportingController : CallComplianceController {
        // GET: Reporting
        public ActionResult Index()
        {
            return View();
        }
    }
}