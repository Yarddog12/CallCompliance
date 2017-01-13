using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CallCompliance.DAL.Models;
using CallCompliance.DAL.Repository.Unblock;

namespace CallCompliance.Controllers
{
    public class UnblockController : Controller
    {
        // GET: Unblock
        public ActionResult Index() {

			var repo = new UnBlockNumberRepository();
	        var model = repo.GetExceptionReasonNames();
			return View (model);
        }
    }
}