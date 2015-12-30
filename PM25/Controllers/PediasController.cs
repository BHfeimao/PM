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
    public class PediasController : Controller
    {
        private DataDBContext db = new DataDBContext();

        // GET: Pedias
        public ActionResult Index()
        {
            return View(db.Pedias.ToList());
        }

        // GET: Pedias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedia pedia = db.Pedias.Find(id);
            if (pedia == null)
            {
                return HttpNotFound();
            }
            return View(pedia);
        }

        // GET: Pedias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pedias/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,title,text")] Pedia pedia)
        {
            if (ModelState.IsValid)
            {
                db.Pedias.Add(pedia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pedia);
        }

        // GET: Pedias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedia pedia = db.Pedias.Find(id);
            if (pedia == null)
            {
                return HttpNotFound();
            }
            return View(pedia);
        }

        // POST: Pedias/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID,title,text")] Pedia pedia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pedia);
        }

        // GET: Pedias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedia pedia = db.Pedias.Find(id);
            if (pedia == null)
            {
                return HttpNotFound();
            }
            return View(pedia);
        }

        // POST: Pedias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedia pedia = db.Pedias.Find(id);
            db.Pedias.Remove(pedia);
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
