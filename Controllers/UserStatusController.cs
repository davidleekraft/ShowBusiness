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
    public class UserStatusController : Controller
    {
        private ShowBusinessDb db = new ShowBusinessDb();

        //
        // GET: /UserStatus/

        public ActionResult Index()
        {
            return View(db.User_Status.ToList());
        }

        //
        // GET: /UserStatus/Details/5

        public ActionResult Details(string id = null)
        {
            User_status user_status = db.User_Status.Find(id);
            if (user_status == null)
            {
                return HttpNotFound();
            }
            return View(user_status);
        }

        //
        // GET: /UserStatus/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /UserStatus/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User_status user_status)
        {
            if (ModelState.IsValid)
            {
                db.User_Status.Add(user_status);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user_status);
        }

        //
        // GET: /UserStatus/Edit/5

        public ActionResult Edit(string id = null)
        {
            User_status user_status = db.User_Status.Find(id);
            if (user_status == null)
            {
                return HttpNotFound();
            }
            return View(user_status);
        }

        //
        // POST: /UserStatus/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User_status user_status)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_status).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_status);
        }

        //
        // GET: /UserStatus/Delete/5

        public ActionResult Delete(string id = null)
        {
            User_status user_status = db.User_Status.Find(id);
            if (user_status == null)
            {
                return HttpNotFound();
            }
            return View(user_status);
        }

        //
        // POST: /UserStatus/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            User_status user_status = db.User_Status.Find(id);
            db.User_Status.Remove(user_status);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}