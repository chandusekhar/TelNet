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
    public class paketiController : Controller
    {
        private TelNetContext db = new TelNetContext();

        // GET: paketi
        public ActionResult Index()
        {
            var paketi = db.Paketi.Include(p => p.katalog);
            return View(paketi.ToList());
        }

        // GET: paketi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paket paket = db.Paketi.Find(id);
            if (paket == null)
            {
                return HttpNotFound();
            }
            return View(paket);
        }

        // GET: paketi/Create
        public ActionResult Create()
        {
            ViewBag.katalogID = new SelectList(db.Katalozi, "katalogID", "nazivKataloga");
            return View();
        }

        // POST: paketi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "paketID,nazivPaketa,cijenaPaketa,opis,katalogID")] paket paket)
        {
            if (ModelState.IsValid)
            {
                db.Paketi.Add(paket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.katalogID = new SelectList(db.Katalozi, "katalogID", "nazivKataloga", paket.katalogID);
            return View(paket);
        }

        // GET: paketi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paket paket = db.Paketi.Find(id);
            if (paket == null)
            {
                return HttpNotFound();
            }
            ViewBag.katalogID = new SelectList(db.Katalozi, "katalogID", "nazivKataloga", paket.katalogID);
            return View(paket);
        }

        // POST: paketi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "paketID,nazivPaketa,cijenaPaketa,opis,katalogID")] paket paket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.katalogID = new SelectList(db.Katalozi, "katalogID", "nazivKataloga", paket.katalogID);
            return View(paket);
        }

        // GET: paketi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paket paket = db.Paketi.Find(id);
            if (paket == null)
            {
                return HttpNotFound();
            }
            return View(paket);
        }

        // POST: paketi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            paket paket = db.Paketi.Find(id);
            db.Paketi.Remove(paket);
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
