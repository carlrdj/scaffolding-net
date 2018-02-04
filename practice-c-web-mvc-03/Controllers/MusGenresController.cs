using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using practice_c_web_mvc_03.Models;

namespace practice_c_web_mvc_03.Controllers
{
    public class MusGenresController : Controller
    {
        private practice_c_web_mvc_03Context db = new practice_c_web_mvc_03Context();

        // GET: MusGenres
        public ActionResult Index()
        {
            return View(db.MusGenres.ToList());
        }

        // GET: MusGenres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusGenre musGenre = db.MusGenres.Find(id);
            if (musGenre == null)
            {
                return HttpNotFound();
            }
            return View(musGenre);
        }

        // GET: MusGenres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MusGenres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Status")] MusGenre musGenre)
        {
            if (ModelState.IsValid)
            {
                db.MusGenres.Add(musGenre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(musGenre);
        }

        // GET: MusGenres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusGenre musGenre = db.MusGenres.Find(id);
            if (musGenre == null)
            {
                return HttpNotFound();
            }
            return View(musGenre);
        }

        // POST: MusGenres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Status")] MusGenre musGenre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musGenre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(musGenre);
        }

        // GET: MusGenres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusGenre musGenre = db.MusGenres.Find(id);
            if (musGenre == null)
            {
                return HttpNotFound();
            }
            return View(musGenre);
        }

        // POST: MusGenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MusGenre musGenre = db.MusGenres.Find(id);
            db.MusGenres.Remove(musGenre);
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
