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
    public class StorageController : Controller
    {
        //Initialize db
        private ShowBusinessDb db = new ShowBusinessDb();

        //
        // GET: /Storage/

        public ActionResult Index()
        {
            return View(db.Storage.ToList());
        }

        //
        // GET: /Storage/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Storage/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Storage storage)
        {
            if (ModelState.IsValid)
            {
                db.Storage.Add(storage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(storage);
        }

        //
        // GET: /Storage/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Storage storage = db.Storage.Find(id);
            if (storage == null)
            {
                return HttpNotFound();
            }
            return View(storage);
        }

        //
        // POST: /Storage/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Storage storage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(storage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(storage);
        }

        //
        // GET: /Storage/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Storage storage = db.Storage.Find(id);
            if (storage == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }

        //
        // POST: /Storage/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Storage storage = db.Storage.Find(id);
            db.Storage.Remove(storage);
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