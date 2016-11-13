using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Madds.Models;

namespace Madds.Controllers
{
    public class Registers1Controller : Controller
    {
        private UserEntities1 db = new UserEntities1();

        // GET: Registers1
        public ActionResult Index()
        {
            return View(db.Registers.ToList());
        }

        // GET: Registers1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Register register = db.Registers.Find(id);
            if (register == null)
            {
                return HttpNotFound();
            }
            return View(register);
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return PartialView();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(UserLogin u)
        {
            if (ModelState.IsValid)
            {
                if (checkIfUserExists(u))
                {
                  Register ut = IsAuthenticated(u);
                    if (ut != null)
                    {
                        Session.Add("IsAuthenticated", true);
                        Session.Add("UserName", ut.UserName);
                        //Session.Add("Roles", ut.RoleId);
                        //return PartialView(new UserLogin());
                        return RedirectToAction("Search", "Searches");
                    }
                    else
                    {
                        Session.Add("IsAuthenticated", false);
                    }
                }
                return PartialView(u);
            }
            else
            {
                return PartialView(u);
            }
        }
        private bool checkIfUserExists(UserLogin u)
        {
           UserEntities1 db = new UserEntities1();
            Register tmp = db.Registers.Where(p => p.UserName == u.UserName).First();
            if (tmp != null)
            {
                return true;
            }
            else
                return false;
        }
        private Register IsAuthenticated(UserLogin u)
        {
         UserEntities1 db = new UserEntities1();
            Register tmp = db.Registers.Where(p => p.UserName == u.UserName).First();
            if (u.Password == tmp.Password)
            {
                tmp.Password = "";
                return tmp;
            }
            else
                return null;

        }
        

        // GET: Registers1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registers1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Company,Contact,Password,ConfirmPassword")] Register register)
        {
            if (ModelState.IsValid)
            {
                db.Registers.Add(register);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            return View(register);
        }

        // GET: Registers1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Register register = db.Registers.Find(id);
            if (register == null)
            {
                return HttpNotFound();
            }
            return View(register);
        }

        // POST: Registers1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Company,Contact,Password,ConfirmPassword")] Register register)
        {
            if (ModelState.IsValid)
            {
                db.Entry(register).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(register);
        }

        // GET: Registers1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Register register = db.Registers.Find(id);
            if (register == null)
            {
                return HttpNotFound();
            }
            return View(register);
        }

        // POST: Registers1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Register register = db.Registers.Find(id);
            db.Registers.Remove(register);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
