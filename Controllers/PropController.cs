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
    public class PropController : Controller
    {
        private ShowBusinessDb db = new ShowBusinessDb();

        //Create lists of strings to be passed to the ViewBag to be used in Drop-Down selections in Views
        private static List<string> category = new List<string>();
        private static List<string> material = new List<string>();
        private static List<string> storageLocations = new List<string>();

        //
        // GET: /Prop/

        public ActionResult Index()
        {
            return View(db.Props.ToList());
        }


        //
        // GET: /Prop/Create

        public ActionResult Create()
        {
            //Clear out the Lists
            category.Clear();
            material.Clear();
            storageLocations.Clear();

            //Add the titles of categories to the category list
            foreach(var c in db.Categories)
            {
               var name = c.category_title;

               category.Add(name);
            }

           ViewBag.CategoryList = category;

           //Add the description of Materials to the Materials list
            foreach(var m in db.Materials)
            {
                var name = m.description;

                material.Add(name);
            }

            ViewBag.MaterialList = material;

            //Add the description of storage locations to the storage list
            foreach (var s in db.Storage)
            {
                var desc = s.location_desc;

                storageLocations.Add(desc);
            }
            ViewBag.StorageLocationList = storageLocations;

            return View();
        }
        

        //
        // POST: /Prop/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Prop prop)
        {
            //Check if model is valid, then add Prop to table and save changes to Database
            if (ModelState.IsValid)
            {
                db.Props.Add(prop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prop);
        }

        //
        // GET: /Prop/Edit/5

        public ActionResult Edit(int id = 0)
        {


            //Clear out the Lists
            category.Clear();
            material.Clear();
            storageLocations.Clear();

            //Add the titles of categories to the category list
            foreach (var c in db.Categories)
            {
                var name = c.category_title;

                category.Add(name);
            }

            ViewBag.CategoryList = category;

            //Add description of Materials to materials list
            foreach (var m in db.Materials)
            {
                var name = m.description;

                material.Add(name);
            }

            ViewBag.MaterialList = material;

            //Add description of Storage locations to Storage list
            foreach (var s in db.Storage)
            {
                var desc = s.location_desc;

                storageLocations.Add(desc);
            }
            ViewBag.StorageLocationList = storageLocations;

            Prop prop = db.Props.Find(id);
            if (prop == null)
            {
                return HttpNotFound();
            }
            return View(prop);
        }

        //
        // POST: /Prop/Edit/5

        [HttpPost]
        public ActionResult Edit(Prop prop)
        {
            //Check if model is valid, then edit Prop to table and save changes to Database
            if (ModelState.IsValid)
            {
                db.Entry(prop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prop);
        }

        //
        // GET: /Prop/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Prop prop = db.Props.Find(id);
            if (prop == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }

        //
        // POST: /Prop/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            //Check if model is valid, then asynchronously delete the Prop
            Prop prop = db.Props.Find(id);
            db.Props.Remove(prop);
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