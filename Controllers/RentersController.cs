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
    public class RentersController : Controller
    {
        private ShowBusinessDb db = new ShowBusinessDb();

        //
        // GET: /Renters/

        public ActionResult Index()
        {
            return View(db.Renters.ToList());
        }

        //
        // GET: /Renters/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Renters/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Renter renters)
        {
            if (ModelState.IsValid)
            {
                db.Renters.Add(renters);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(renters);
        }

        //
        // GET: /Renters/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Renter renters = db.Renters.Find(id);
            if (renters == null)
            {
                return HttpNotFound();
            }
            return View(renters);
        }

        //
        // POST: /Renters/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Renter renters)
        {
            if (ModelState.IsValid)
            {
                db.Entry(renters).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(renters);
        }

        //
        // GET: /Renters/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Renter renters = db.Renters.Find(id);
            if (renters == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }

        //
        // POST: /Renters/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Renter renters = db.Renters.Find(id);
            db.Renters.Remove(renters);
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