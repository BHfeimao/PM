using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PM25.Controllers
{
    public class SummaryController : Controller
    {
        // GET: Summary
        public ActionResult Detail()
        {
            return View("Detail");
        }
    }
}