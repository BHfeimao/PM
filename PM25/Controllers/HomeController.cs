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

        public class BTModel
        {
            public List<Pedia> Pedias { get; set; }
            public List<BodyTem> BodyTems { get; set; }
            public BTModel(List<Pedia> PediaList, List<BodyTem> BodyTemList)
            {
                this.Pedias = PediaList;
                this.BodyTems = BodyTemList;
            }
        }
        public class IFModel
        {
            public List<Pedia> Pedias { get; set; }
            public List<Infra> Infras { get; set; }
            public IFModel(List<Pedia> PediaList,List<Infra>InfraList)
            {
                this.Pedias = PediaList;
                this.Infras = InfraList;
            }
        }
        public class NEWModel
        {
            public List<Pedia> Pedias { get; set; }
            public List<New> News { get; set; }
            public NEWModel(List<Pedia> PediaList,List<New> NewList)
            {
                this.Pedias = PediaList;
                this.News = NewList;
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
            ViewBag.i = 0;
            var vm = new BTModel(db.Pedias.ToList(), db.BodyTems.ToList());
            vm.BodyTems = db.BodyTems.ToList();
            vm.Pedias = db.Pedias.ToList();
            return View(vm);
        }

        public ActionResult Infrared()
        {
            ViewBag.i = 0;
            var vm = new IFModel(db.Pedias.ToList(), db.Infras.ToList());
            vm.Pedias = db.Pedias.ToList();
            vm.Infras = db.Infras.ToList();
            return View(vm);
        }

        public ActionResult Now()
        {
            var vm = new NowModel(db.Pedias.ToList(), db.Nows.ToList());
            vm.Pedias = db.Pedias.ToList();
            vm.Nows = db.Nows.ToList();
            ViewBag.i = 0;
            return View(vm);
        }
        public ActionResult New()
        {
            ViewBag.i = 0;
            var vm = new NEWModel(db.Pedias.ToList(), db.News.ToList());
            vm.Pedias = db.Pedias.ToList();
            vm.News = db.News.ToList();
            return View(vm);
        }
    }
}