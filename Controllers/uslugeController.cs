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
using TelNet.Models;
using TelNet.ViewModels;
using System.Data.Entity.Infrastructure;

namespace TelNet.Controllers
{
    [Authorize(Roles = "Admin, Employee")]
    public class uslugeController : Controller
    {
        private TelNetContext db = new TelNetContext();

        // GET: usluge
        [AllowAnonymous]
        public ActionResult Index()
        {
            var usluge = db.Usluge;
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
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: usluge/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        public ActionResult Narudzba(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usluga usluga = db.Usluge.Find(id);
            UslugaNarudzba un = new UslugaNarudzba();
            un.komentar = "Bez komentara";
            un.datum = DateTime.Now;
            un.imePrezimeKupca = "";
            un.adresaKupca = "";
            un.usluga = usluga;
            if (usluga == null)
            {
                return HttpNotFound();
            }
            return View(un);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Narudzba(UslugaNarudzba usluganarudzba)
        {
            if (ModelState.IsValid)
            {
                narudzbaUsluga narudzba = new narudzbaUsluga();
                var user = User.Identity.Name;
                narudzba.odgovornaOsobaID = user;
                narudzba.komentar = usluganarudzba.komentar;
                narudzba.adresaKupca = usluganarudzba.adresaKupca;
                narudzba.imePrezimeKupca = usluganarudzba.imePrezimeKupca;
                narudzba.usluga = usluganarudzba.usluga;
                narudzba.datumNarudzbe = usluganarudzba.datum;
                db.Entry(usluganarudzba.usluga).State = EntityState.Modified;

                var dobo = db.Usluge.Include(i => i.narudzbeUsluga).Where(i => i.uslugaID == usluganarudzba.usluga.uslugaID).Single();
                    

                if (TryUpdateModel(dobo, "",
                   new string[] { "nazivUsluge", "tipUsluge","cijenaUsluge","opis" }))
                {
                    try
                    {
                        dobo.narudzbeUsluga.Add(narudzba);
                        db.Entry(dobo).State = EntityState.Modified;
                        db.NarudzbeUsluga.Add(narudzba);
                        db.SaveChanges();


                    }
                    catch (RetryLimitExceededException /* dex */)
                    {
                        //Log the error (uncomment dex variable name and add a line here to write a log.
                        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                    }
                }
             
                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Create([Bind(Include = "uslugaID,nazivUsluge,tipUsluge,cijenaUsluge,opis")] usluga usluga)
        {
            if (ModelState.IsValid)
            {
                db.Usluge.Add(usluga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usluga);
        }

        // GET: usluge/Edit/5
        [Authorize(Roles = "Admin, Employee")]
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
          return View(usluga);
        }

        // POST: usluge/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Edit([Bind(Include = "uslugaID,nazivUsluge,tipUsluge,cijenaUsluge,opis")] usluga usluga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usluga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
        [Authorize(Roles = "Admin, Employee")]
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
