﻿using PM25.Models;
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
        public class viewModel
        {
            public List<Home> Homes { get; set; }
            public List<Pedia> Pedias { get; set; }

            public viewModel(List<Home> HomeList, List<Pedia> PediaList)
            {
                this.Homes = HomeList;
                this.Pedias = PediaList;
            }
        }
        public ActionResult Index()
        {
            
            //ViewBag.testss = db.Pedias;
            //ViewBag.testss2 = db.Homes;
            var vm = new viewModel(db.Homes.ToList(), db.Pedias.ToList());
            vm.Homes = db.Homes.ToList();
            vm.Pedias = db.Pedias.ToList();
            return View(vm);
        }

        public ActionResult More_info()
        {
            return View("More");
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
            
            return View();
        }

        public ActionResult New()
        {
            return View("SummaryNEW");
        }
    }
}