using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorldWideFloors.Models;

namespace WorldWideFloors.Controllers
{
    public class GluesController : Controller
    {
        private WorldWideFloorsContext db = new WorldWideFloorsContext();

        // GET: Glues
        public ActionResult Index()
        {
            return View(db.Glues.ToList());
        }

        // GET: Glues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Glue glue = db.Glues.Find(id);
            if (glue == null)
            {
                return HttpNotFound();
            }
            return View(glue);
        }

        // GET: Glues/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Glues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MaterialType,MaterialAmount,Price")] Glue glue)
        {
            if (ModelState.IsValid)
            {
                db.Glues.Add(glue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(glue);
        }

        // GET: Glues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Glue glue = db.Glues.Find(id);
            if (glue == null)
            {
                return HttpNotFound();
            }
            return View(glue);
        }

        // POST: Glues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MaterialType,MaterialAmount,Price")] Glue glue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(glue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(glue);
        }

        // GET: Glues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Glue glue = db.Glues.Find(id);
            if (glue == null)
            {
                return HttpNotFound();
            }
            return View(glue);
        }

        // POST: Glues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Glue glue = db.Glues.Find(id);
            db.Glues.Remove(glue);
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
