using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TelNet.DAL;
using telNet.Models;
using TelNet.Models;
using System.Data.Entity.Infrastructure;
using TelNet.ViewModels;

namespace TelNet.Controllers
{
    public class dobavljaciController : Controller
    {
        private TelNetContext db = new TelNetContext();

        // GET: dobavljaci
        public ActionResult Index(string sort)
        {
            //if the sort parameter is null or empty then we are initializing the value as descending name  
            ViewBag.SortByName = string.IsNullOrEmpty(sort) ? "descending naziv" : "";
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

        public ActionResult UnosiDobavljaca(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
          
            dobavljac dobavljac = db.Dobavljaci.Include(i => i.Unosi).Where(i => i.dobavljacID == id).Single();
            if (dobavljac == null)
            {
                return HttpNotFound();
            }
            ViewBag.Dobavljac = dobavljac.naziv;
            return View(dobavljac.Unosi);
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
                dobavljac.RokVazenjaRatinga = DateTime.Now.AddMonths(6);
                db.Dobavljaci.Add(dobavljac);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dobavljac);
        }
        // GET: dobavljaci/Edit/5
        public ActionResult EditRating(int? id)
        {
            dobavljac dobavljac = db.Dobavljaci.Find(id);
            DobavljacKomentar dbk = new DobavljacKomentar();
            dbk.dobavljac = dobavljac;
            dbk.komentar = "Bez komentara";
            if (dobavljac == null)
            {
                return HttpNotFound();
            }
            ViewBag.Koment = dbk;
            return View(dbk);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRating(DobavljacKomentar dbk)
        {
            if (ModelState.IsValid)
            {
                dbk.dobavljac.ratingUkupno = dbk.dobavljac.ratingKvalitet + dbk.dobavljac.ratingKomunikacija + dbk.dobavljac.ratingBrzinaIsporuke;
                dbk.dobavljac.RokVazenjaRatinga = DateTime.Now.AddMonths(6);
                DobavljacUnos unos = new DobavljacUnos(dbk.komentar, DateTime.Now, dbk.dobavljac.RokVazenjaRatinga, dbk.dobavljac.ratingKvalitet, dbk.dobavljac.ratingBrzinaIsporuke, dbk.dobavljac.ratingKomunikacija, dbk.dobavljac.ratingUkupno, dbk.dobavljac);
                db.Entry(dbk.dobavljac).State = EntityState.Modified;
                var dobo = db.Dobavljaci
           .Include(i => i.Unosi)
           .Where(i => i.dobavljacID == dbk.dobavljac.dobavljacID)
           .Single();

                if (TryUpdateModel(dobo, "",
                   new string[] { "naziv", "adresa", "ratingKvalitet", "ratingBrzinaIsporuke", "ratingKomunikacija", "ratingUkupno", "RokVazenjaRatinga" }))
                {
                    try
                    {
                        dobo.Unosi.Add(unos);
                        db.Entry(dobo).State = EntityState.Modified;

                    }
                    catch (RetryLimitExceededException /* dex */)
                    {
                        //Log the error (uncomment dex variable name and add a line here to write a log.
                        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                    }
                }
                db.UnosiDobavljaca.Add(unos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dbk.dobavljac);
        }
        // GET: dobavljaci/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dobavljac dobavljac = db.Dobavljaci.Find(id);
            DobavljacKomentar dbk = new DobavljacKomentar();
            dbk.dobavljac = dobavljac;
            dbk.komentar = "Bez komentara";
            if (dobavljac == null)
            {
                return HttpNotFound();
            }
            ViewBag.Koment = dbk;
            return View(dbk);
        }

        // POST: dobavljaci/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DobavljacKomentar dbk) //[Bind(Include = "dobavljacID,naziv,adresa,ratingKvalitet,ratingBrzinaIsporuke,ratingKomunikacija,ratingUkupno")] dobavljac dobavljac)
        {
            if (ModelState.IsValid)
            {
                dbk.dobavljac.ratingUkupno = dbk.dobavljac.ratingKvalitet + dbk.dobavljac.ratingKomunikacija + dbk.dobavljac.ratingBrzinaIsporuke;
                dbk.dobavljac.RokVazenjaRatinga = DateTime.Now.AddMonths(6);
                DobavljacUnos unos = new DobavljacUnos(dbk.komentar, DateTime.Now, dbk.dobavljac.RokVazenjaRatinga, dbk.dobavljac.ratingKvalitet, dbk.dobavljac.ratingBrzinaIsporuke, dbk.dobavljac.ratingKomunikacija, dbk.dobavljac.ratingUkupno, dbk.dobavljac);
               
                db.Entry(dbk.dobavljac).State = EntityState.Modified;
                var dobo = db.Dobavljaci
            .Include(i => i.Unosi)
            .Where(i => i.dobavljacID == dbk.dobavljac.dobavljacID)
            .Single();

                if (TryUpdateModel(dobo, "",
                   new string[] { "naziv", "adresa", "ratingKvalitet", "ratingBrzinaIsporuke", "ratingKomunikacija", "ratingUkupno","RokVazenjaRatinga" }))
                {
                    try
                    {
                        dobo.Unosi.Add(unos);
                        db.Entry(dobo).State = EntityState.Modified;

                    }
                    catch (RetryLimitExceededException /* dex */)
                    {
                        //Log the error (uncomment dex variable name and add a line here to write a log.
                        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                    }
                }
                db.UnosiDobavljaca.Add(unos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dbk.dobavljac);
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
