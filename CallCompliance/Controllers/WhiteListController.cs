using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CallCompliance.Controllers
{
    public class WhiteListController : CallComplianceController {
        // GET: WhiteList
        public ActionResult Index()
        {
            return View();
        }
    }
}