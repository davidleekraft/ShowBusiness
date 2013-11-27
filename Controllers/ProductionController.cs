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
    public class ProductionController : Controller
    {
        private ShowBusinessDb db = new ShowBusinessDb();

        //
        // GET: /Production/

        public ActionResult Index()
        {
            return View(db.Productions.ToList());
        }

        //
        // GET: /Production/Details/5

        public ActionResult Details(int id = 0)
        {
            Production production = db.Productions.Find(id);
            if (production == null)
            {
                return HttpNotFound();
            }
            return View(production);
        }

        //
        // GET: /Production/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Production/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Production production)
        {
            if (ModelState.IsValid)
            {
                db.Productions.Add(production);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(production);
        }

        //
        // GET: /Production/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Production production = db.Productions.Find(id);
            if (production == null)
            {
                return HttpNotFound();
            }
            return View(production);
        }

        //
        // POST: /Production/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Production production)
        {
            if (ModelState.IsValid)
            {
                db.Entry(production).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(production);
        }

        //
        // GET: /Production/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Production production = db.Productions.Find(id);
            if (production == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index"); 
        }

        //
        // POST: /Production/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Production production = db.Productions.Find(id);
            db.Productions.Remove(production);
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