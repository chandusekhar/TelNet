using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TelNet.DAL;
using TelNet.Models;

namespace TelNet.Controllers
{
    public class ProizvodiController : Controller
    {
        private TelNetContext db = new TelNetContext();

        // GET: Proizvodi
        public ActionResult Index()
        {
            var proizvodi = db.Proizvodi.Include(p => p.Dobavljac).Include(p => p.TipProizvoda);
            return View(proizvodi.ToList());
        }

        // GET: Proizvodi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proizvod proizvod = db.Proizvodi.Find(id);
            if (proizvod == null)
            {
                return HttpNotFound();
            }
            return View(proizvod);
        }

        // GET: Proizvodi/Create
        public ActionResult Create()
        {
            ViewBag.dobavljacID = new SelectList(db.Dobavljaci, "dobavljacID", "naziv");
            ViewBag.tipProizvodaID = new SelectList(db.TipoviProizvoda, "tipProizvodaID", "nazivTipa");
            return View();
        }

        // POST: Proizvodi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "proizvodID,cijenaProizvoda,opisProizvoda,tipProizvodaID,dobavljacID")] Proizvod proizvod)
        {
            if (ModelState.IsValid)
            {
                db.Proizvodi.Add(proizvod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.dobavljacID = new SelectList(db.Dobavljaci, "dobavljacID", "naziv", proizvod.dobavljacID);
            ViewBag.tipProizvodaID = new SelectList(db.TipoviProizvoda, "tipProizvodaID", "nazivTipa", proizvod.tipProizvodaID);
            return View(proizvod);
        }

        // GET: Proizvodi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proizvod proizvod = db.Proizvodi.Find(id);
            if (proizvod == null)
            {
                return HttpNotFound();
            }
            ViewBag.dobavljacID = new SelectList(db.Dobavljaci, "dobavljacID", "naziv", proizvod.dobavljacID);
            ViewBag.tipProizvodaID = new SelectList(db.TipoviProizvoda, "tipProizvodaID", "nazivTipa", proizvod.tipProizvodaID);
            return View(proizvod);
        }

        // POST: Proizvodi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "proizvodID,cijenaProizvoda,opisProizvoda,tipProizvodaID,dobavljacID")] Proizvod proizvod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proizvod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.dobavljacID = new SelectList(db.Dobavljaci, "dobavljacID", "naziv", proizvod.dobavljacID);
            ViewBag.tipProizvodaID = new SelectList(db.TipoviProizvoda, "tipProizvodaID", "nazivTipa", proizvod.tipProizvodaID);
            return View(proizvod);
        }

        // GET: Proizvodi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proizvod proizvod = db.Proizvodi.Find(id);
            if (proizvod == null)
            {
                return HttpNotFound();
            }
            return View(proizvod);
        }

        // POST: Proizvodi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proizvod proizvod = db.Proizvodi.Find(id);
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
