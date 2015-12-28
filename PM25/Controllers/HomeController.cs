using PM25.Models;
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
            PediaDBContext db = new PediaDBContext(); 
            
            return View(db.Pedias.ToList());
        }

        public ActionResult More_info()
        {
            return View("More");
        }

        public ActionResult Bodytem()
        {
            return View("Summary");
        }

        public ActionResult Now()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}