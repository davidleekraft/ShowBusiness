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
    public class SizeController : Controller
    {
        
        //Initialize database connection
        private ShowBusinessDb db = new ShowBusinessDb();
        //Initialize lists to be passed to viewbag for dropdown
        private static List<string> performers = new List<string>();
        private static List<string> props = new List<string>();
        private static List<string> garments = new List<string>();

        //
        // GET: /Size/

        public ActionResult Index()
        {
            return View(db.Sizes.ToList());
        }

        //
        // GET: /Size/Details/5

        public ActionResult Details(int id = 0)
        {
            Size size = db.Sizes.Find(id);
            if (size == null)
            {
                return HttpNotFound();
            }
            return View(size);
        }

        //
        // GET: /Size/Create

        public ActionResult Create()
        {
            //clear lists to prevent duplicates
            performers.Clear();
            props.Clear();
            garments.Clear();

            //pass needed information from performer table to viewbag
            foreach (var r in db.Performers)
            {
                var name = r.first_name + " " + r.last_name;

                performers.Add(name);
            }

            ViewBag.PerformerList = performers;

            //pass needed information from prop table to viewbag
            foreach (var p in db.Props)
            {
                var name = p.prop_ID + " " + p.name;

                props.Add(name);
            }

            ViewBag.PropList = props;

            //pass needed information from garment table to viewbag
            foreach (var g in db.Garments)
            {
                var name = g.garment_ID + " " + g.name;

                garments.Add(name);
            }

            ViewBag.GarmentList = garments;
            
            return View();
        }

        //
        // POST: /Size/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Size size)
        {
            if (ModelState.IsValid)
            {
                db.Sizes.Add(size);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(size);
        }

        //
        // GET: /Size/Edit/5

        public ActionResult Edit(int id = 0)
        {
            //clear lists to prevent duplicates
            performers.Clear();
            props.Clear();
            garments.Clear();

            //pass needed information from performer table to viewbag
            foreach (var r in db.Performers)
            {
                var name = r.first_name + " " + r.last_name;

                performers.Add(name);
            }

            ViewBag.PerformerList = performers;

            //pass needed information from prop table to viewbag
            foreach (var p in db.Props)
            {
                var name = p.prop_ID + " " + p.name;

                props.Add(name);
            }

            ViewBag.PropList = props;

            //pass needed information from performer table to viewbag
            foreach (var g in db.Garments)
            {
                var name = g.garment_ID + " " + g.name;

                garments.Add(name);
            }

            ViewBag.GarmentList = garments;
            
            Size size = db.Sizes.Find(id);
            if (size == null)
            {
                return HttpNotFound();
            }
            return View(size);
        }

        //
        // POST: /Size/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Size size)
        {
            if (ModelState.IsValid)
            {
                db.Entry(size).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(size);
        }

        //
        // GET: /Size/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Size size = db.Sizes.Find(id);
            if (size == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }

        //
        // POST: /Size/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Size size = db.Sizes.Find(id);
            db.Sizes.Remove(size);
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