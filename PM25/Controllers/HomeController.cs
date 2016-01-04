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
        DataDBContext db = new DataDBContext();
        public class IndexModel
        {
            public List<Home> Homes { get; set; }
            public List<Pedia> Pedias { get; set; }         
            public IndexModel(List<Home> HomeList, List<Pedia> PediaList)
            {
                this.Homes = HomeList;
                this.Pedias = PediaList;
            }
        }
        public class NowModel
        {
            public List<Pedia> Pedias { get; set; }
            public List<Now> Nows { get; set; }
            public NowModel(List<Pedia> PediaList, List<Now> NowList)
            {
                this.Pedias = PediaList;
                this.Nows = NowList;
            }                  
        }
        public ActionResult Index()
        {
            var vm = new IndexModel(db.Homes.ToList(), db.Pedias.ToList());
            vm.Homes = db.Homes.ToList();
            vm.Pedias = db.Pedias.ToList();
            ViewBag.i = 0;      
            return View(vm);           
        }
        public ActionResult More()
        {          
            return View(db.Pedias);
        }
        public ActionResult Bodytem()
        {
            return View();
        }

        public ActionResult Infrared()
        {
            return View("SummaryIF");
        }

        public ActionResult Now()
        {
            var vm = new NowModel(db.Pedias.ToList(), db.Nows.ToList());
            vm.Pedias = db.Pedias.ToList();
            vm.Nows = db.Nows.ToList();
            return View(vm);
        }
        public ActionResult New()
        {
            return View("SummaryNEW");
        }
    }
}