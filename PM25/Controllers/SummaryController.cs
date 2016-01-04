using PM25.Models;
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
        public DataDBContext db = new DataDBContext();
        public ActionResult DetailBT(int id)
        {
            ViewBag.i = 0;
            var vm = new HomeController.BTModel(db.Pedias.ToList(), db.BodyTems.ToList());
            vm.BodyTems = db.BodyTems.ToList();
            vm.Pedias = db.Pedias.ToList();
            ViewBag.id = id;
            return View(vm);
        }
        public ActionResult DetailIF(int id)
        {
            ViewBag.i = 0;
            var vm = new HomeController.IFModel(db.Pedias.ToList(), db.Infras.ToList());
            vm.Infras = db.Infras.ToList();
            vm.Pedias = db.Pedias.ToList();
            ViewBag.id = id;
            return View(vm);
        }
        public ActionResult DetailNEW(int id)
        {
            ViewBag.i = 0;
            var vm = new HomeController.NEWModel(db.Pedias.ToList(), db.News.ToList());
            vm.News = db.News.ToList();
            vm.Pedias = db.Pedias.ToList();
            ViewBag.id = id;
            return View(vm);
        }
    }
}