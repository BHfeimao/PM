using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PM25.Models;
using System.IO;

namespace PM25.Controllers
{
    public class NowsController : Controller
    {
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Up(HttpPostedFileBase upfile)
        {
            //檢查是否有選擇檔案
            if (upfile != null)
            {
                //檢查檔案大小要限制也可以在這裡做
                if (upfile.ContentLength > 0)
                {
                    string savedName = Path.Combine(Server.MapPath("~/Temp/"), upfile.FileName);
                    upfile.SaveAs(savedName);
                    Session["name"] = upfile.FileName;
                }
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        private DataDBContext db = new DataDBContext();
        // GET: Nows
        public ActionResult Index()
        {
            Session["name"] = "";
            return View(db.Nows.ToList());
        }

        // GET: Nows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Now now = db.Nows.Find(id);
            if (now == null)
            {
                return HttpNotFound();
            }
            return View(now);
        }

        // GET: Nows/Create
        public ActionResult Create()
        {
            ViewBag.name = Session["name"];
            return View();
        }

        // POST: Nows/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,title,summary,downloadURL")] Now now)
        {
            if (ModelState.IsValid)
            {
                db.Nows.Add(now);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(now);
        }

        // GET: Nows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Now now = db.Nows.Find(id);
            if (now == null)
            {
                return HttpNotFound();
            }
            ViewBag.name = Session["name"];
            return View(now);
        }

        // POST: Nows/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID,title,summary,downloadURL")] Now now)
        {
            if (ModelState.IsValid)
            {
                db.Entry(now).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(now);
        }

        // GET: Nows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Now now = db.Nows.Find(id);
            if (now == null)
            {
                return HttpNotFound();
            }
            return View(now);
        }

        // POST: Nows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Now now = db.Nows.Find(id);
            db.Nows.Remove(now);
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
