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
    public class AlterationsController : Controller
    {
        
        //Set database and lists to populate forms
        private ShowBusinessDb db = new ShowBusinessDb();
        private static List<string> props = new List<string>();
        private static List<string> garments = new List<string>();


        //Default Alterations Index View
        public ActionResult Index()
        {
            return View(db.Alterations.ToList());
        }

        //Create Alteration
        public ActionResult Create()
        {
            //Clear out lists to prevent duplicates
            props.Clear();
            garments.Clear();

            //Fill lists for dropdown menus
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

        //Process Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Alteration alterations)
        {
            if (ModelState.IsValid)
            {
                db.Alterations.Add(alterations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alterations);
        }

        //Edit Alteration
        public ActionResult Edit(int id = 0)
        {
            //Clear out lists to prevent duplicates
            props.Clear();
            garments.Clear();

            //Fill lists for dropdown menus
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
            
            Alteration alterations = db.Alterations.Find(id);
            if (alterations == null)
            {
                return HttpNotFound();
            }
            return View(alterations);
        }


        //Process Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Alteration alterations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alterations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alterations);
        }

        //Delete method
        public ActionResult Delete(int id = 0)
        {
            Alteration alterations = db.Alterations.Find(id);
            if (alterations == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }

        //Delete process
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Alteration alterations = db.Alterations.Find(id);
            db.Alterations.Remove(alterations);
            db.SaveChanges();
            return JavaScript("$(this).parent().parent().parent().remove();");
        }

        //Dispose method
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}