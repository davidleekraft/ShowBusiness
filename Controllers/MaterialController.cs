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
    public class MaterialController : Controller
    {
        private ShowBusinessDb db = new ShowBusinessDb();

        //
        // GET: /Material/

        public ActionResult Index()
        {
            return View(db.Materials.ToList());
        }

        //
        // GET: /Material/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Material/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Material material)
        {
            //Check if model is valid, then add Materials to table and save changes to Database
            if (ModelState.IsValid)
            {
                db.Materials.Add(material);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(material);
        }

        //
        // GET: /Material/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Material material = db.Materials.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        //
        // POST: /Material/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Material material)
        {
            //Check if model is valid, then edit Materials to table and save changes to Database
            if (ModelState.IsValid)
            {
                db.Entry(material).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(material);
        }

        //
        // GET: /Material/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Material material = db.Materials.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }

        //
        // POST: /Material/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            //Check if model is valid, then asynchronously delete the Material
            Material material = db.Materials.Find(id);
            db.Materials.Remove(material);
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