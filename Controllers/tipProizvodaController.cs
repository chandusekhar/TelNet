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
    public class tipProizvodaController : Controller
    {
        private TelNetContext db = new TelNetContext();

        // GET: tipProizvoda
        public ActionResult Index()
        {
            return View(db.TipoviProizvoda.ToList());
        }

        // GET: tipProizvoda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipProizvoda tipProizvoda = db.TipoviProizvoda.Find(id);
            if (tipProizvoda == null)
            {
                return HttpNotFound();
            }
            return View(tipProizvoda);
        }

        // GET: tipProizvoda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipProizvoda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tipProizvodaID,nazivTipa,proizvodjac")] tipProizvoda tipProizvoda)
        {
            if (ModelState.IsValid)
            {
                db.TipoviProizvoda.Add(tipProizvoda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipProizvoda);
        }

        // GET: tipProizvoda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipProizvoda tipProizvoda = db.TipoviProizvoda.Find(id);
            if (tipProizvoda == null)
            {
                return HttpNotFound();
            }
            return View(tipProizvoda);
        }

        // POST: tipProizvoda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tipProizvodaID,nazivTipa,proizvodjac")] tipProizvoda tipProizvoda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipProizvoda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipProizvoda);
        }

        // GET: tipProizvoda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipProizvoda tipProizvoda = db.TipoviProizvoda.Find(id);
            if (tipProizvoda == null)
            {
                return HttpNotFound();
            }
            return View(tipProizvoda);
        }

        // POST: tipProizvoda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipProizvoda tipProizvoda = db.TipoviProizvoda.Find(id);
            db.TipoviProizvoda.Remove(tipProizvoda);
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
