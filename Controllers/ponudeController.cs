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
    public class ponudeController : Controller
    {
        private TelNetContext db = new TelNetContext();

        // GET: ponude
        public ActionResult Index()
        {
            var ponude = db.Ponude.Include(p => p.dobavljac).Include(p => p.statusPonude);
            return View(ponude.ToList());
        }

        // GET: ponude/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ponuda ponuda = db.Ponude.Find(id);
            if (ponuda == null)
            {
                return HttpNotFound();
            }
            return View(ponuda);
        }

        // GET: ponude/Create
        public ActionResult Create()
        {
            ViewBag.dobavljacID = new SelectList(db.Dobavljaci, "dobavljacID", "naziv");
            ViewBag.statusPonudeID = new SelectList(db.StatusiPonuda, "statusPonudeID", "nazivStatusa");
            return View();
        }

        // POST: ponude/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ponudaID,ponudaProizvoda,ukupnaCijena,datumIsporuke,statusPonudeID,dobavljacID")] ponuda ponuda)
        {
            if (ModelState.IsValid)
            {
                db.Ponude.Add(ponuda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.dobavljacID = new SelectList(db.Dobavljaci, "dobavljacID", "naziv", ponuda.dobavljacID);
            ViewBag.statusPonudeID = new SelectList(db.StatusiPonuda, "statusPonudeID", "nazivStatusa", ponuda.statusPonudeID);
            return View(ponuda);
        }

        // GET: ponude/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ponuda ponuda = db.Ponude.Find(id);
            if (ponuda == null)
            {
                return HttpNotFound();
            }
            ViewBag.dobavljacID = new SelectList(db.Dobavljaci, "dobavljacID", "naziv", ponuda.dobavljacID);
            ViewBag.statusPonudeID = new SelectList(db.StatusiPonuda, "statusPonudeID", "nazivStatusa", ponuda.statusPonudeID);
            return View(ponuda);
        }

        // POST: ponude/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ponudaID,ponudaProizvoda,ukupnaCijena,datumIsporuke,statusPonudeID,dobavljacID")] ponuda ponuda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ponuda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.dobavljacID = new SelectList(db.Dobavljaci, "dobavljacID", "naziv", ponuda.dobavljacID);
            ViewBag.statusPonudeID = new SelectList(db.StatusiPonuda, "statusPonudeID", "nazivStatusa", ponuda.statusPonudeID);
            return View(ponuda);
        }

        // GET: ponude/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ponuda ponuda = db.Ponude.Find(id);
            if (ponuda == null)
            {
                return HttpNotFound();
            }
            return View(ponuda);
        }

        // POST: ponude/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ponuda ponuda = db.Ponude.Find(id);
            db.Ponude.Remove(ponuda);
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
