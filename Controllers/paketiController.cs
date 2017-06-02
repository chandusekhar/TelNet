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
using TelNet.ViewModels;
using System.Data.Entity.Infrastructure;

namespace TelNet.Controllers
{
     public class paketiController : Controller
    {
        private TelNetContext db = new TelNetContext();

        // GET: paketi
        public ActionResult Index(int? id)
        {
            var viewModel = new PaketViewModel();
            viewModel.Paketi = db.Paketi.Include(i => i.Usluge);

        if (id != null)
            {
                ViewBag.paketID = id.Value;
                viewModel.Usluge = viewModel.Paketi.Where(
                    i => i.paketID == id.Value).Single().Usluge;
            }

           
            return View(viewModel);
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
        [Authorize(Roles = "Admin, Employee")]
        // GET: paketi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: paketi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Employee")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "paketID,nazivPaketa,cijenaPaketa,opis")] paket paket)
        {
            if (ModelState.IsValid)
            {
                db.Paketi.Add(paket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           return View(paket);
        }

        // GET: paketi/Edit/5
        [Authorize(Roles = "Admin, Employee")]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paket paket = db.Paketi.Include(i => i.Usluge)
    .Where(i => i.paketID == id)
    .Single();
            PopuniIzabraneUsluge(paket);
            if (paket == null)
            {
                return HttpNotFound();
            }
            return View(paket);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Employee")]

        public ActionResult Edit(int? id, string[] izabraneUsluge)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var paketToUpdate = db.Paketi
               .Include(i => i.Usluge)
               .Where(i => i.paketID == id)
               .Single();

            if (TryUpdateModel(paketToUpdate, "",
               new string[] { "nazivPaketa", "cijenaPaketa", "opis"}))
            {
                try
                {
                  
                   UpdateIzabraneUsluge(izabraneUsluge, paketToUpdate);

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
           PopuniIzabraneUsluge(paketToUpdate);
            return View(paketToUpdate);
        }
        // POST: paketi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "paketID,nazivPaketa,cijenaPaketa,opis")] paket paket, string[] izabraneUsluge)
        {
            if (ModelState.IsValid)
            {
                var instructorToUpdate = db.Paketi.Include(i => i.Usluge).Where(i => i.paketID == id).Single();
      
                paket =UpdateIzabraneUsluge(izabraneUsluge,paket);

                db.Entry(paket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopuniIzabraneUsluge(paket);
            return View(paket);
        }
        */
     
        private paket UpdateIzabraneUsluge(string[] izabraneUsluge, paket paket)
        {
            if (izabraneUsluge == null)
            {
                paket.Usluge= new List<usluga>();
                return paket;
            }

            var izabraneUslugeHS = new HashSet<string>(izabraneUsluge);
            var paketUsluge = new HashSet<int>
                (paket.Usluge.Select(c => c.uslugaID));
            foreach (var usluga in db.Usluge)
            {
                if (izabraneUslugeHS.Contains(usluga.uslugaID.ToString()))
                {
                    if (!paketUsluge.Contains(usluga.uslugaID))
                    {
                        paket.Usluge.Add(usluga);
                    }
                }
                else
                {
                    if (paketUsluge.Contains(usluga.uslugaID))
                    {
                        paket.Usluge.Remove(usluga);
                    }
                }
            }
            return paket;
        }
        // GET: paketi/Delete/5
        [Authorize(Roles = "Admin, Employee")]

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
        private void PopuniIzabraneUsluge(paket paket)
        {
            var sveUsluge = db.Usluge;
            var paketUsluge = new HashSet<int>(paket.Usluge.Select(c => c.uslugaID));
            var viewModel = new List<IzabraneUsluge>();
            foreach (var usluga in sveUsluge)
            {
                viewModel.Add(new IzabraneUsluge
                {
                    uslugaID = usluga.uslugaID,
                    naziv = usluga.nazivUsluge,
                    Izabrana = paketUsluge.Contains(usluga.uslugaID)
                });
            }
            ViewBag.Usluge = viewModel;
        }
        // POST: paketi/Delete/5
        [Authorize(Roles = "Admin, Employee")]

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
