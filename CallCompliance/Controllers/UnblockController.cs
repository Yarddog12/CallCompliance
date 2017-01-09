using CallCompliance.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CallCompliance.Controllers
{
    public class UnblockController : Controller
    {
        // GET: Unblock
        public ActionResult Index() {

            //var viewModel = new UnblockViewModel {
            //    ReasonOverrides = dbContext.ReasonOverrides.ToList ();
            //}
            return View ();
        }
    }
}