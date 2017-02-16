using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CallCompliance.Controllers
{
    public class AdminController : CallComplianceController {

		// GET: Admin
		public ActionResult Index() {
			ViewBag.Name = FullName;
			return View();
        }
    }
}