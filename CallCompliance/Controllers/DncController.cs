using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CallCompliance.Controllers
{
    public class DNCController : CallComplianceController {
        // GET: Dnc
        public ActionResult Index()
        {
            return View();
        }
    }
}