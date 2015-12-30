using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PM25.Models;

namespace PM25.Controllers
{
    public class HomesController : Controller
    {
        private DataDBContext db = new DataDBContext();

        // GET: Homes
        public ActionResult Index()
        {
            return View(db.Homes.ToList());
        }

        // GET: Homes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Home home = db.Homes.Find(id);
            if (home == null)
            {
                return HttpNotFound();
            }
            return View(home);
        }

        // GET: Homes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Homes/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,preface")] Home home)
        {
            if (ModelState.IsValid)
            {
                db.Homes.Add(home);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(home);
        }

        // GET: Homes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Home home = db.Homes.Find(id);
            if (home == null)
            {
                return HttpNotFound();
            }
            return View(home);
        }

        // POST: Homes/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID,preface")] Home home)
        {
            if (ModelState.IsValid)
            {
                db.Entry(home).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(home);
        }

        // GET: Homes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Home home = db.Homes.Find(id);
            if (home == null)
            {
                return HttpNotFound();
            }
            return View(home);
        }

        // POST: Homes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Home home = db.Homes.Find(id);
            db.Homes.Remove(home);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
