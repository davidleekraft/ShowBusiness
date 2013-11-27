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
    public class PatternController : Controller
    {
        private ShowBusinessDb db = new ShowBusinessDb();

        //
        // GET: /Pattern/

        public ActionResult Index()
        {
            return View(db.Patterns.ToList());
        }

        //
        // GET: /Pattern/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Pattern/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pattern pattern)
        {
            //Check if model is valid, then add Pattern to table and save changes to Database
            if (ModelState.IsValid)
            {
                db.Patterns.Add(pattern);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pattern);
        }

        //
        // GET: /Pattern/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Pattern pattern = db.Patterns.Find(id);
            if (pattern == null)
            {
                return HttpNotFound();
            }
            return View(pattern);
        }

        //
        // POST: /Pattern/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pattern pattern)
        {
            //Check if model is valid, then edit Materials to table and save changes to Pattern
            if (ModelState.IsValid)
            {
                db.Entry(pattern).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pattern);
        }

        //
        // GET: /Pattern/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Pattern pattern = db.Patterns.Find(id);
            if (pattern == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }

        //
        // POST: /Pattern/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            //Check if model is valid, then asynchronously delete the Pattern
            Pattern pattern = db.Patterns.Find(id);
            db.Patterns.Remove(pattern);
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