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
    public class CostumeController : Controller
    {
        private ShowBusinessDb db = new ShowBusinessDb();

        //
        // GET: /Costume/

        public ActionResult Index()
        {
            return View(db.Costumes.ToList());
        }

        //
        // GET: /Costume/Details/5

        public ActionResult Details(int id = 0)
        {
            Costume costume = db.Costumes.Find(id);
            if (costume == null)
            {
                return HttpNotFound();
            }
            return View(costume);
        }

        //
        // GET: /Costume/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Costume/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Costume costume)
        {
            //Check if model is valid, then add Costume to table and save changes to Database
            if (ModelState.IsValid)
            {
                db.Costumes.Add(costume);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(costume);
        }

        //
        // GET: /Costume/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Costume costume = db.Costumes.Find(id);
            if (costume == null)
            {
                return HttpNotFound();
            }
            return View(costume);
        }

        //
        // POST: /Costume/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Costume costume)
        {
            //Check if model is valid, then edit the data in the table and save changes to Database
            if (ModelState.IsValid)
            {
                db.Entry(costume).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(costume);
        }

        //
        // GET: /Costume/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Costume costume = db.Costumes.Find(id);
            if (costume == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }

        //
        // POST: /Costume/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            //Check if model is valid, then asynchronously delete the Costume
            Costume costume = db.Costumes.Find(id);
            db.Costumes.Remove(costume);
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