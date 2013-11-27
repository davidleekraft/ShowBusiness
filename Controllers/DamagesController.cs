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
    public class DamagesController : Controller
    {
        
        //Initialize db and lists for dropdowns
        private ShowBusinessDb db = new ShowBusinessDb();
        private static List<string> props = new List<string>();
        private static List<string> garments = new List<string>();

        //Defult Index View
        public ActionResult Index()
        {
            return View(db.Damages.ToList());
        }

        //
        // GET: /Damages/Create

        public ActionResult Create()
        {
            //Clear out lists to prevent duplicates
            props.Clear();
            garments.Clear();

            //Fill lists for dropdowns
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

            return View();
        }

        //
        // POST: /Damages/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Damage damages)
        {
            if (ModelState.IsValid)
            {
                db.Damages.Add(damages);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(damages);
        }

        //
        // GET: /Damages/Edit/5

        public ActionResult Edit(int id = 0)
        {
            //Clear out lists to prevent duplicates
            props.Clear();
            garments.Clear();

            //Fill lists for dropdowns
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
            
            Damage damages = db.Damages.Find(id);
            if (damages == null)
            {
                return HttpNotFound();
            }
            return View(damages);
        }

        //
        // POST: /Damages/Edit/5

        [HttpPost]
        public ActionResult Edit(Damage damages)
        {
            if (ModelState.IsValid)
            {
                db.Entry(damages).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(damages);
        }

        //
        // GET: /Damages/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Damage damages = db.Damages.Find(id);
            if (damages == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }

        //
        // POST: /Damages/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Damage damages = db.Damages.Find(id);
            db.Damages.Remove(damages);
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