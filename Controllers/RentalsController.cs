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

    public class RentalsController : Controller
    {
        //Initialize DB and set lists for dropdowns
        private ShowBusinessDb db = new ShowBusinessDb();
        private static List<string> renters = new List<string>();
        private static List<string> props = new List<string>();
        private static List<string> garments = new List<string>();

        //
        // GET: /Rentals/

        public ActionResult Index()
        {
            return View(db.Rentals.ToList());
        }

        //
        // GET: /Rentals/Create

        public ActionResult Create()
        {
            //Clear out lists to prevent duplicates
            renters.Clear();
            props.Clear();
            garments.Clear();

            //Fill lists for dropdowns
            foreach(var r in db.Renters)
           {
               var name = r.first_name + " " + r.last_name;

               renters.Add(name);
           }

           ViewBag.RenterList = renters;

            foreach(var p in db.Props)
            {
                var name = p.prop_ID + " " + p.name;

                props.Add(name);
            }

            ViewBag.PropList = props;

            foreach(var g in db.Garments)
            {
                var name = g.garment_ID + " " + g.name;

                garments.Add(name);
            }

            ViewBag.GarmentList = garments;

            return View();
        }

        //
        // POST: /Rentals/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Rental rentals)
        {
            if (ModelState.IsValid)
            {
                db.Rentals.Add(rentals);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rentals);
        }

        //
        // GET: /Rentals/Edit/5

        public ActionResult Edit(int id = 0)
        {
            //Clear out lists to prevent duplicates
            renters.Clear();
            props.Clear();
            garments.Clear();

            //Fill lists for dropdowns
            foreach (var r in db.Renters)
            {
                var name = r.first_name + " " + r.last_name;

                renters.Add(name);
            }

            
            ViewBag.RenterList = renters;

            foreach (var p in db.Props)
            {
                var name = p.prop_ID + " " + p.name;

                props.Add(name);
            }

            
            ViewBag.PropList = props;

            foreach (var g in db.Garments)
            {
                var name = g.garment_ID + " " + g.name;

                garments.Add(name);
            }

            ViewBag.GarmentList = garments;
            
            Rental rentals = db.Rentals.Find(id);
            if (rentals == null)
            {
                return HttpNotFound();
            }
            return View(rentals);
        }

        //
        // POST: /Rentals/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Rental rentals)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentals).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rentals);
        }

        //
        // GET: /Rentals/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Rental rentals = db.Rentals.Find(id);
            if (rentals == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }

        //
        // POST: /Rentals/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Rental rentals = db.Rentals.Find(id);
            db.Rentals.Remove(rentals);
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