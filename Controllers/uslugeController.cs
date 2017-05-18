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
    [Authorize(Roles = "Admin")]
    public class uslugeController : Controller
    {
        private TelNetContext db = new TelNetContext();

        // GET: usluge
        [AllowAnonymous]
        public ActionResult Index()
        {
            var usluge = db.Usluge.Include(u => u.katalog);
            return View(usluge.ToList());
        }

        // GET: usluge/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usluga usluga = db.Usluge.Find(id);
            if (usluga == null)
            {
                return HttpNotFound();
            }
            return View(usluga);
        }

        // GET: usluge/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.katalogID = new SelectList(db.Katalozi, "katalogID", "nazivKataloga");
            return View();
        }

        // POST: usluge/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "uslugaID,nazivUsluge,tipUsluge,cijenaUsluge,opis,katalogID")] usluga usluga)
        {
            if (ModelState.IsValid)
            {
                db.Usluge.Add(usluga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.katalogID = new SelectList(db.Katalozi, "katalogID", "nazivKataloga", usluga.katalogID);
            return View(usluga);
        }

        // GET: usluge/Edit/5
        [Authorize(Roles = "Admin")]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usluga usluga = db.Usluge.Find(id);
            if (usluga == null)
            {
                return HttpNotFound();
            }
            ViewBag.katalogID = new SelectList(db.Katalozi, "katalogID", "nazivKataloga", usluga.katalogID);
            return View(usluga);
        }

        // POST: usluge/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public ActionResult Edit([Bind(Include = "uslugaID,nazivUsluge,tipUsluge,cijenaUsluge,opis,katalogID")] usluga usluga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usluga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.katalogID = new SelectList(db.Katalozi, "katalogID", "nazivKataloga", usluga.katalogID);
            return View(usluga);
        }

        // GET: usluge/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usluga usluga = db.Usluge.Find(id);
            if (usluga == null)
            {
                return HttpNotFound();
            }
            return View(usluga);
        }

        // POST: usluge/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public ActionResult DeleteConfirmed(int id)
        {
            usluga usluga = db.Usluge.Find(id);
            db.Usluge.Remove(usluga);
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
