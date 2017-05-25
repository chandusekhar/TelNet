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
        public ActionResult Index(string sort)
        {
            //if the sort parameter is null or empty then we are initializing the value as descending name  
            ViewBag.SortByNaziv = string.IsNullOrEmpty(sort) ? "descending naziv" : "";
            //if the sort value is gender then we are initializing the value as descending gender  
            ViewBag.SortByRating = sort == "Rating" ? "descending rating" : "Rating";
            var records = db.Dobavljaci.AsQueryable();
            
            switch (sort)
            {

                case "descending naziv":
                    records = records.OrderByDescending(x => x.naziv);
                    break;

                case "descending rating":
                    records = records.OrderByDescending(x => x.ratingUkupno);
                    break;

                case "Rating":
                    records = records.OrderBy(x => x.ratingUkupno);
                    break;

                default:
                    records = records.OrderBy(x => x.naziv);
                    break;

            }
            return View(records.ToList());
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
        public ActionResult Create([Bind(Include = "dobavljacID,naziv,adresa,ratingKvalitet,ratingBrzinaIsporuke,ratingKomunikacija")] dobavljac dobavljac)
        {
            if (ModelState.IsValid)
            {
                dobavljac.ratingUkupno = dobavljac.ratingKvalitet + dobavljac.ratingKomunikacija+dobavljac.ratingBrzinaIsporuke;
                db.Dobavljaci.Add(dobavljac);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dobavljac);
        }
        // GET: dobavljaci/Edit/5
        public ActionResult EditRating(int? id)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRating([Bind(Include = "dobavljacID,naziv, adresa,ratingKvalitet,ratingBrzinaIsporuke,ratingKomunikacija")] dobavljac dobavljac)
        {
            if (ModelState.IsValid)
            {
                dobavljac.ratingUkupno = dobavljac.ratingKvalitet + dobavljac.ratingKomunikacija + dobavljac.ratingBrzinaIsporuke;
                db.Entry(dobavljac).State = EntityState.Modified;
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
        public ActionResult Edit([Bind(Include = "dobavljacID,naziv,adresa,ratingKvalitet,ratingBrzinaIsporuke,ratingKomunikacija,ratingUkupno")] dobavljac dobavljac)
        {
            if (ModelState.IsValid)
            {
                dobavljac.ratingUkupno = dobavljac.ratingKvalitet + dobavljac.ratingKomunikacija + dobavljac.ratingBrzinaIsporuke;
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
