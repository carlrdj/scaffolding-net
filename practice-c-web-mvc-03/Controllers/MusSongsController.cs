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
    public class MusSongsController : Controller
    {
        private practice_c_web_mvc_03Context db = new practice_c_web_mvc_03Context();

        // GET: MusSongs
        public ActionResult Index()
        {
            var musSongs = db.MusSongs.Include(m => m.Artist);
            return View(musSongs.ToList());
        }

        // GET: MusSongs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusSong musSong = db.MusSongs.Find(id);
            if (musSong == null)
            {
                return HttpNotFound();
            }
            return View(musSong);
        }

        // GET: MusSongs/Create
        public ActionResult Create()
        {
            ViewBag.MusArtistId = new SelectList(db.MusArtists, "Id", "Name");
            return View();
        }

        // POST: MusSongs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MusArtistId,Name,Time,Status")] MusSong musSong)
        {
            if (ModelState.IsValid)
            {
                db.MusSongs.Add(musSong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MusArtistId = new SelectList(db.MusArtists, "Id", "Name", musSong.MusArtistId);
            return View(musSong);
        }

        // GET: MusSongs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusSong musSong = db.MusSongs.Find(id);
            if (musSong == null)
            {
                return HttpNotFound();
            }
            ViewBag.MusArtistId = new SelectList(db.MusArtists, "Id", "Name", musSong.MusArtistId);
            return View(musSong);
        }

        // POST: MusSongs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MusArtistId,Name,Time,Status")] MusSong musSong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musSong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MusArtistId = new SelectList(db.MusArtists, "Id", "Name", musSong.MusArtistId);
            return View(musSong);
        }

        // GET: MusSongs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusSong musSong = db.MusSongs.Find(id);
            if (musSong == null)
            {
                return HttpNotFound();
            }
            return View(musSong);
        }

        // POST: MusSongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MusSong musSong = db.MusSongs.Find(id);
            db.MusSongs.Remove(musSong);
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
