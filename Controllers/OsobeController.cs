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
    public class OsobeController : Controller
    {
        private TelNetContext db = new TelNetContext();

        // GET: Osobe
        public ActionResult Index()
        {
            var osobe = db.Osobe.Include(o => o.tip);
            return View(osobe.ToList());
        }

        // GET: Osobe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osoba osoba = db.Osobe.Find(id);
            if (osoba == null)
            {
                return HttpNotFound();
            }
            return View(osoba);
        }

        // GET: Osobe/Create
        public ActionResult Create()
        {
            ViewBag.tipID = new SelectList(db.Tipovi, "tipID", "nazivTipa");
            return View();
        }

        // POST: Osobe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "osobaID,adresa,ime,prezime,username,password,datumRodjenja,telefon,tipID")] Osoba osoba)
        {
            if (ModelState.IsValid)
            {
                db.Osobe.Add(osoba);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tipID = new SelectList(db.Tipovi, "tipID", "nazivTipa", osoba.tipID);
            return View(osoba);
        }

        // GET: Osobe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osoba osoba = db.Osobe.Find(id);
            if (osoba == null)
            {
                return HttpNotFound();
            }
            ViewBag.tipID = new SelectList(db.Tipovi, "tipID", "nazivTipa", osoba.tipID);
            return View(osoba);
        }

        // POST: Osobe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "osobaID,adresa,ime,prezime,username,password,datumRodjenja,telefon,tipID")] Osoba osoba)
        {
            if (ModelState.IsValid)
            {
                db.Entry(osoba).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tipID = new SelectList(db.Tipovi, "tipID", "nazivTipa", osoba.tipID);
            return View(osoba);
        }

        // GET: Osobe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osoba osoba = db.Osobe.Find(id);
            if (osoba == null)
            {
                return HttpNotFound();
            }
            return View(osoba);
        }

        // POST: Osobe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Osoba osoba = db.Osobe.Find(id);
            db.Osobe.Remove(osoba);
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
