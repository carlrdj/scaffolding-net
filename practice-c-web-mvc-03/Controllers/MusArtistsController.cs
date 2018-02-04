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
    public class MusArtistsController : Controller
    {
        private practice_c_web_mvc_03Context db = new practice_c_web_mvc_03Context();

        // GET: MusArtists
        public ActionResult Index()
        {
            var musArtists = db.MusArtists.Include(m => m.Genre);
            return View(musArtists.ToList());
        }

        // GET: MusArtists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusArtist musArtist = db.MusArtists.Find(id);
            if (musArtist == null)
            {
                return HttpNotFound();
            }
            return View(musArtist);
        }

        // GET: MusArtists/Create
        public ActionResult Create()
        {
            ViewBag.MusGenreId = new SelectList(db.MusGenres, "Id", "Name");
            return View();
        }

        // POST: MusArtists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MusGenreId,Name,Status")] MusArtist musArtist)
        {
            if (ModelState.IsValid)
            {
                db.MusArtists.Add(musArtist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MusGenreId = new SelectList(db.MusGenres, "Id", "Name", musArtist.MusGenreId);
            return View(musArtist);
        }

        // GET: MusArtists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusArtist musArtist = db.MusArtists.Find(id);
            if (musArtist == null)
            {
                return HttpNotFound();
            }
            ViewBag.MusGenreId = new SelectList(db.MusGenres, "Id", "Name", musArtist.MusGenreId);
            return View(musArtist);
        }

        // POST: MusArtists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MusGenreId,Name,Status")] MusArtist musArtist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musArtist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MusGenreId = new SelectList(db.MusGenres, "Id", "Name", musArtist.MusGenreId);
            return View(musArtist);
        }

        // GET: MusArtists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusArtist musArtist = db.MusArtists.Find(id);
            if (musArtist == null)
            {
                return HttpNotFound();
            }
            return View(musArtist);
        }

        // POST: MusArtists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MusArtist musArtist = db.MusArtists.Find(id);
            db.MusArtists.Remove(musArtist);
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
