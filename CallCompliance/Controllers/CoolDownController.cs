using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CallCompliance.Controllers
{
    public class CoolDownController : CallComplianceController {
        // GET: CoolDown
        public ActionResult Index()
        {
            return View();
        }
    }
}