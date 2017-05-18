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
    public class dobavljaciController : Controller
    {
        private TelNetContext db = new TelNetContext();

        // GET: dobavljaci
        public ActionResult Index()
        {
            return View(db.Dobavljaci.ToList());
        }

        // GET: dobavljaci/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dobavljac dobavljac = db.Dobavljaci.Find(id);
            if (dobavljac == null)
            {
                return HttpNotFound();
            }
            return View(dobavljac);
        }

        // GET: dobavljaci/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: dobavljaci/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "dobavljacID,naziv,adresa,ratingID")] dobavljac dobavljac)
        {
            if (ModelState.IsValid)
            {
                db.Dobavljaci.Add(dobavljac);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dobavljac);
        }

        // GET: dobavljaci/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dobavljac dobavljac = db.Dobavljaci.Find(id);
            if (dobavljac == null)
            {
                return HttpNotFound();
            }
            return View(dobavljac);
        }

        // POST: dobavljaci/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "dobavljacID,naziv,adresa,ratingID")] dobavljac dobavljac)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dobavljac).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dobavljac);
        }

        // GET: dobavljaci/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dobavljac dobavljac = db.Dobavljaci.Find(id);
            if (dobavljac == null)
            {
                return HttpNotFound();
            }
            return View(dobavljac);
        }

        // POST: dobavljaci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dobavljac dobavljac = db.Dobavljaci.Find(id);
            db.Dobavljaci.Remove(dobavljac);
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
