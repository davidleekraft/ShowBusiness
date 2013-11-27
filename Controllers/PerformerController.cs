using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnhandledExceptionProject.Models;

namespace UnhandledExceptionProject.Controllers
{
    public class PerformerController : Controller
    {
        //Initialize DB
        private ShowBusinessDb db = new ShowBusinessDb();

        //
        // GET: /Performer/

        public ActionResult Index()
        {
            return View(db.Performers.ToList());
        }

        //
        // GET: /Performer/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Performer/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Performer performer)
        {
            if (ModelState.IsValid)
            {
                db.Performers.Add(performer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(performer);
        }

        //
        // GET: /Performer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Performer performer = db.Performers.Find(id);
            if (performer == null)
            {
                return HttpNotFound();
            }
            return View(performer);
        }

        //
        // POST: /Performer/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Performer performer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(performer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(performer);
        }

        //
        // GET: /Performer/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Performer performer = db.Performers.Find(id);
            if (performer == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }

        //
        // POST: /Performer/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Performer performer = db.Performers.Find(id);
            db.Performers.Remove(performer);
            db.SaveChanges();
            return JavaScript("$(this).parent().parent().parent().remove();");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}