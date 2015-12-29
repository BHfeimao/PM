using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PM25.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult More_info()
        {
            return View("More");
        }

        public ActionResult Bodytem()
        {
            return View("SummaryBT");
        }

        public ActionResult Infrared()
        {
            return View("SummaryIF");
        }

        public ActionResult Now()
        {
            return View();
        }

        public ActionResult New()
        {
            return View("SummaryNEW");
        }
    }
}