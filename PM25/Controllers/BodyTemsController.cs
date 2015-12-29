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
    public class BodyTemsController : Controller
    {
        private BodyTemDBContext db = new BodyTemDBContext();

        // GET: BodyTems
        public ActionResult Index()
        {
            return View(db.BodyTems.ToList());
        }

        // GET: BodyTems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BodyTem bodyTem = db.BodyTems.Find(id);
            if (bodyTem == null)
            {
                return HttpNotFound();
            }
            return View(bodyTem);
        }

        // GET: BodyTems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BodyTems/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,Img,Summary,Detail")] BodyTem bodyTem)
        {
            if (ModelState.IsValid)
            {
                db.BodyTems.Add(bodyTem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bodyTem);
        }

        // GET: BodyTems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BodyTem bodyTem = db.BodyTems.Find(id);
            if (bodyTem == null)
            {
                return HttpNotFound();
            }
            return View(bodyTem);
        }

        // POST: BodyTems/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID,Img,Summary,Detail")] BodyTem bodyTem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bodyTem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bodyTem);
        }

        // GET: BodyTems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BodyTem bodyTem = db.BodyTems.Find(id);
            if (bodyTem == null)
            {
                return HttpNotFound();
            }
            return View(bodyTem);
        }

        // POST: BodyTems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BodyTem bodyTem = db.BodyTems.Find(id);
            db.BodyTems.Remove(bodyTem);
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
