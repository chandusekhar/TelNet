using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TelNet.DAL;
using telNet.Models;

namespace TelNet.Controllers
{
    public class katalogController : Controller
    {
        private TelNetContext db = new TelNetContext();

        // GET: katalog
        public ActionResult Index()
        {
            return View(db.Katalozi.ToList());
        }

        // GET: katalog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            katalog katalog = db.Katalozi.Find(id);
            if (katalog == null)
            {
                return HttpNotFound();
            }
            return View(katalog);
        }

        // GET: katalog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: katalog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "katalogID,nazivKataloga,opis")] katalog katalog)
        {
            if (ModelState.IsValid)
            {
                db.Katalozi.Add(katalog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(katalog);
        }

        // GET: katalog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            katalog katalog = db.Katalozi.Find(id);
            if (katalog == null)
            {
                return HttpNotFound();
            }
            return View(katalog);
        }

        // POST: katalog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "katalogID,nazivKataloga,opis")] katalog katalog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(katalog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(katalog);
        }

        // GET: katalog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            katalog katalog = db.Katalozi.Find(id);
            if (katalog == null)
            {
                return HttpNotFound();
            }
            return View(katalog);
        }

        // POST: katalog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            katalog katalog = db.Katalozi.Find(id);
            db.Katalozi.Remove(katalog);
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
