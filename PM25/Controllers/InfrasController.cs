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
    public class InfrasController : Controller
    {
        private DataDBContext db = new DataDBContext();

        // GET: Infras
        public ActionResult Index()
        {
            return View(db.Infras.ToList());
        }

        // GET: Infras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Infra infra = db.Infras.Find(id);
            if (infra == null)
            {
                return HttpNotFound();
            }
            return View(infra);
        }

        // GET: Infras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Infras/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,img,summary,detail")] Infra infra)
        {
            if (ModelState.IsValid)
            {
                db.Infras.Add(infra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(infra);
        }

        // GET: Infras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Infra infra = db.Infras.Find(id);
            if (infra == null)
            {
                return HttpNotFound();
            }
            return View(infra);
        }

        // POST: Infras/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID,img,summary,detail")] Infra infra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(infra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(infra);
        }

        // GET: Infras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Infra infra = db.Infras.Find(id);
            if (infra == null)
            {
                return HttpNotFound();
            }
            return View(infra);
        }

        // POST: Infras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Infra infra = db.Infras.Find(id);
            db.Infras.Remove(infra);
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
