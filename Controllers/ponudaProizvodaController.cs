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
    public class ponudaProizvodaController : Controller
    {
        private TelNetContext db = new TelNetContext();

        // GET: ponudaProizvoda
        public ActionResult Index()
        {
            var ponudeProizvoda = db.PonudeProizvoda.Include(p => p.ponuda).Include(p => p.proizvod);
            return View(ponudeProizvoda.ToList());
        }

        // GET: ponudaProizvoda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ponudaProizvoda ponudaProizvoda = db.PonudeProizvoda.Find(id);
            if (ponudaProizvoda == null)
            {
                return HttpNotFound();
            }
            return View(ponudaProizvoda);
        }

        // GET: ponudaProizvoda/Create
        public ActionResult Create()
        {
            ViewBag.ponudaID = new SelectList(db.Ponude, "ponudaID", "ponudaID");
            ViewBag.proizvodID = new SelectList(db.Proizvodi, "proizvodID", "opisProizvoda");
            return View();
        }

        // POST: ponudaProizvoda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ponudaProizvodaID,proizvodID,ponudaID,opis")] ponudaProizvoda ponudaProizvoda)
        {
            if (ModelState.IsValid)
            {
                db.PonudeProizvoda.Add(ponudaProizvoda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ponudaID = new SelectList(db.Ponude, "ponudaID", "ponudaID", ponudaProizvoda.ponudaID);
            ViewBag.proizvodID = new SelectList(db.Proizvodi, "proizvodID", "opisProizvoda", ponudaProizvoda.proizvodID);
            return View(ponudaProizvoda);
        }

        // GET: ponudaProizvoda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ponudaProizvoda ponudaProizvoda = db.PonudeProizvoda.Find(id);
            if (ponudaProizvoda == null)
            {
                return HttpNotFound();
            }
            ViewBag.ponudaID = new SelectList(db.Ponude, "ponudaID", "ponudaID", ponudaProizvoda.ponudaID);
            ViewBag.proizvodID = new SelectList(db.Proizvodi, "proizvodID", "opisProizvoda", ponudaProizvoda.proizvodID);
            return View(ponudaProizvoda);
        }

        // POST: ponudaProizvoda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ponudaProizvodaID,proizvodID,ponudaID,opis")] ponudaProizvoda ponudaProizvoda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ponudaProizvoda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ponudaID = new SelectList(db.Ponude, "ponudaID", "ponudaID", ponudaProizvoda.ponudaID);
            ViewBag.proizvodID = new SelectList(db.Proizvodi, "proizvodID", "opisProizvoda", ponudaProizvoda.proizvodID);
            return View(ponudaProizvoda);
        }

        // GET: ponudaProizvoda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ponudaProizvoda ponudaProizvoda = db.PonudeProizvoda.Find(id);
            if (ponudaProizvoda == null)
            {
                return HttpNotFound();
            }
            return View(ponudaProizvoda);
        }

        // POST: ponudaProizvoda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ponudaProizvoda ponudaProizvoda = db.PonudeProizvoda.Find(id);
            db.PonudeProizvoda.Remove(ponudaProizvoda);
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
