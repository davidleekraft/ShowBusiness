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
    public class GarmentController : Controller
    {
        private ShowBusinessDb db = new ShowBusinessDb();

        //Create lists to hold values that need to populate the view dropdown lists.
        private static List<string> costumes = new List<string>();
        private static List<string> categories = new List<string>();
        private static List<string> materials = new List<string>();
        private static List<string> patterns = new List<string>();
        private static List<string> storageLocations = new List<string>();

        //
        // GET: /Garment/

        public ActionResult Index()
        {
            return View(db.Garments.ToList());
        }

        //
        // GET: /Garment/Create

        public ActionResult Create()
        {
            //Clear out previously stored items in the lists
            costumes.Clear();
            categories.Clear();
            materials.Clear();
            patterns.Clear();
            storageLocations.Clear();

            //Populate a ViewBag array which renders a dropdown list within the view
            foreach (var c in db.Costumes)
            {
                var name = c.name;

                costumes.Add(name);
            }
            ViewBag.CostumeList = costumes;

            //Populate a ViewBag array which renders a dropdown list within the view
            foreach (var c in db.Categories)
            {
                var title = c.category_title;

                categories.Add(title);
            }
            ViewBag.CategoryList = categories;

            //Populate a ViewBag array which renders a dropdown list within the view
            foreach (var m in db.Materials)
            {
                var desc = m.description;

                materials.Add(desc);
            }
            ViewBag.MaterialList = materials;

            //Populate a ViewBag array which renders a dropdown list within the view
            foreach (var p in db.Patterns)
            {
                var desc = p.description;

                patterns.Add(desc);
            }
            ViewBag.PatternList = patterns;

            //Populate a ViewBag array which renders a dropdown list within the view
            foreach (var s in db.Storage)
            {
                var desc = s.location_desc;

                storageLocations.Add(desc);
            }
            ViewBag.StorageLocationList = storageLocations;

            return View();
        }

        //
        // POST: /Garment/Create

        [HttpPost]
        public ActionResult Create(Garment garment)
        {
            //Check if model is valid, then add Garment to table and save changes to Database
            if (ModelState.IsValid)
            {
                db.Garments.Add(garment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(garment);
        }

        //
        // GET: /Garment/Edit/5

        public ActionResult Edit(int id = 0)
        {
            //Clear out previously stored items in the lists
            costumes.Clear();
            categories.Clear();
            materials.Clear();
            patterns.Clear();
            storageLocations.Clear();

            //Populate a ViewBag array which renders a dropdown list within the view
            foreach (var c in db.Costumes)
            {
                var name = c.name;

                costumes.Add(name);
            }
            ViewBag.CostumeList = costumes;

            //Populate a ViewBag array which renders a dropdown list within the view
            foreach (var c in db.Categories)
            {
                var title = c.category_title;

                categories.Add(title);
            }
            ViewBag.CategoryList = categories;

            //Populate a ViewBag array which renders a dropdown list within the view
            foreach (var m in db.Materials)
            {
                var desc = m.description;

                materials.Add(desc);
            }
            ViewBag.MaterialList = materials;

            //Populate a ViewBag array which renders a dropdown list within the view
            foreach (var p in db.Patterns)
            {
                var desc = p.description;

                patterns.Add(desc);
            }
            ViewBag.PatternList = patterns;

            //Populate a ViewBag array which renders a dropdown list within the view
            foreach (var s in db.Storage)
            {
                var desc = s.location_desc;

                storageLocations.Add(desc);
            }
            ViewBag.StorageLocationList = storageLocations;

            //Populate a ViewBag array which renders a dropdown list within the view
            Garment garment = db.Garments.Find(id);
            if (garment == null)
            {
                return HttpNotFound();
            }
            return View(garment);
        }

        //
        // POST: /Garment/Edit/5

        [HttpPost]
        public ActionResult Edit(Garment garment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(garment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(garment);
        }

        //
        // GET: /Garment/Delete/5

        public ActionResult Delete(int id = 0)
        {
            //Check if model is valid, then edit the data in the table and save changes to Database
            Garment garment = db.Garments.Find(id);
            if (garment == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }

        //
        // POST: /Garment/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            //Check if model is valid, then asynchronously delete the Garment
            Garment garment = db.Garments.Find(id);
            db.Garments.Remove(garment);
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