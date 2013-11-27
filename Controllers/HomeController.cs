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
    public class HomeController : Controller
    {
        private static User t = new User();
        private ShowBusinessDb db = new ShowBusinessDb();
        private static List<User> users = new List<User>();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            //Use this check to return user to login page if not logged in
            bool check = users.Exists(User => (User.userName == t.userName) && (User.userPass == t.userPass));
            if (check == false)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public ActionResult AdvSearch()
        {
            //Use this check to return user to login page if not logged in
            bool check = users.Exists(User => (User.userName == t.userName) && (User.userPass == t.userPass));
            if (check == false)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpPost]
        public ActionResult AdvSearch(FormCollection formData)
        {
            //Logic for form processing and item creation

            return View();
        }

        public ActionResult Create()
        {
            //Use this check to return user to login page if not logged in
            bool check = users.Exists(User => (User.userName == t.userName) && (User.userPass == t.userPass));
            if (check == false)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection formData)
        {
            //Logic for form processing and item creation

            return View();
        }

        public ActionResult Dash(FormCollection formData)
        {
            bool check = users.Exists(User => (User.userName == t.userName) && (User.userPass == t.userPass));
            if (check == false)
            {
                return RedirectToAction("Login");
            }

            //Logic for sending stuff from the db to the View to use to display data

            return View();
        }

        public ActionResult Browse()
        {
            //Use this check to return user to login page if not logged in
            bool check = users.Exists(User => (User.userName == t.userName) && (User.userPass == t.userPass));
            if (check == false)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public ActionResult Login()
        {
            bool check = users.Exists(User => (User.userName == t.userName) && (User.userPass == t.userPass));
            if (check)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection formData)
        {
            users.Clear();

            foreach (var u in db.Users)
            {
                users.Add(u);
            }
            
            t.userName = formData["userName"];
            t.userPass = formData["userPass"];
            bool check = users.Exists(User => (User.userName == t.userName) && (User.userPass == t.userPass));
            if (check)
            {
                return RedirectToAction("Index");
            }
            return View("LoginError");
        }

        public ActionResult Logout()
        {
            bool check = users.Exists(User => (User.userName == t.userName) && (User.userPass == t.userPass));
            if (check == false)
            {
                return RedirectToAction("Login");
            }
            t.userName = "";
            t.userPass = "";
            return View();
        }

        //Create New User

        public ActionResult newUser()
        {
            return View();
        }

        //Terms of Service

        public ActionResult terms()
        {
            return View();
        }

        //Terms of Service

        public ActionResult privacy()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}