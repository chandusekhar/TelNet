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
    public class proizvodiController : Controller
    {
        private TelNetContext db = new TelNetContext();

        // GET: proizvodi
        public ActionResult Index()
        {
            var proizvodi = db.Proizvodi.Include(p => p.tipProizvoda);
            return View(proizvodi.ToList());
        }

        // GET: proizvodi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proizvod proizvod = db.Proizvodi.Find(id);
            if (proizvod == null)
            {
                return HttpNotFound();
            }
            return View(proizvod);
        }

        // GET: proizvodi/Create
        public ActionResult Create()
        {
            ViewBag.tipProizvodaID = new SelectList(db.TipoviProizvoda, "tipProizvodaID", "nazivTipa");
            return View();
        }

        // POST: proizvodi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "proizvodID,kvalitetaProizvoda,cijenaProizvoda,opisProizvoda,tipProizvodaID")] proizvod proizvod)
        {
            if (ModelState.IsValid)
            {
                db.Proizvodi.Add(proizvod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tipProizvodaID = new SelectList(db.TipoviProizvoda, "tipProizvodaID", "nazivTipa", proizvod.tipProizvodaID);
            return View(proizvod);
        }

        // GET: proizvodi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proizvod proizvod = db.Proizvodi.Find(id);
            if (proizvod == null)
            {
                return HttpNotFound();
            }
            ViewBag.tipProizvodaID = new SelectList(db.TipoviProizvoda, "tipProizvodaID", "nazivTipa", proizvod.tipProizvodaID);
            return View(proizvod);
        }

        // POST: proizvodi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "proizvodID,kvalitetaProizvoda,cijenaProizvoda,opisProizvoda,tipProizvodaID")] proizvod proizvod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proizvod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tipProizvodaID = new SelectList(db.TipoviProizvoda, "tipProizvodaID", "nazivTipa", proizvod.tipProizvodaID);
            return View(proizvod);
        }

        // GET: proizvodi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proizvod proizvod = db.Proizvodi.Find(id);
            if (proizvod == null)
            {
                return HttpNotFound();
            }
            return View(proizvod);
        }

        // POST: proizvodi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            proizvod proizvod = db.Proizvodi.Find(id);
            db.Proizvodi.Remove(proizvod);
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
