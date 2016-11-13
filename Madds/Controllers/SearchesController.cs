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
    public class SearchesController : Controller
    {
        private Python_linkEntities db1 = new Python_linkEntities();
        private UserEntities1 db = new UserEntities1();

        // GET: Searches
        public ActionResult Index()
        {
            return View(db.Searches.ToList());
        }


        // GET: Searches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Search search = db.Searches.Find(id);
            if (search == null)
            {
                return HttpNotFound();
            }
            return View(search);
        }

        // GET: Searches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Searches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Searchname")] Search search)
        {
            if (ModelState.IsValid)
            {
                db.Searches.Add(search);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(search);
        }

        // GET: Searches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Search search = db.Searches.Find(id);
            if (search == null)
            {
                return HttpNotFound();
            }
            return View(search);
        }

        // POST: Searches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Searchname")] Search search)
        {
            if (ModelState.IsValid)
            {
                db.Entry(search).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(search);
        }
        public ActionResult Result()
        {
            return View(db1.Links.ToList());
        }
        public ActionResult Saroj()
        {
            var a = false;
            var query1 = from ord in db1.Links where ord.Id == true select ord;
            // Query the database for the row to be updated.
            var query =
                from ord in db1.Links
                where ord.Id == true
                select ord;

            // Execute the query, and change the column values
            // you want to change.
            foreach (Link ord in query1)
            {
                ord.location = "not found";
                ord.Searchname = "saroj";
                ord.Start = true;
                // Insert any additional changes to column values.
            }

            // Submit the changes to the database.
            try
            {
                db1.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Provide for exceptions.
            }
            return View();
        }
        public ActionResult Sudin()
        {
            var a = false;
            var query1 = from ord in db1.Links where ord.Id == true select ord;
            // Query the database for the row to be updated.
            var query =
                from ord in db1.Links
                where ord.Id == true
                select ord;

            // Execute the query, and change the column values
            // you want to change.
            foreach (Link ord in query1)
            {
                ord.location = "not found";
                ord.Searchname = "sudin";
                ord.Start = true;
                // Insert any additional changes to column values.
            }

            // Submit the changes to the database.
            try
            {
                db1.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Provide for exceptions.
            }
            return View();
        }
        public ActionResult GYANENDRA()
        {
            var a = false;
            var query1 = from ord in db1.Links where ord.Id == true select ord;
            // Query the database for the row to be updated.
            var query =
                from ord in db1.Links
                where ord.Id == true
                select ord;

            // Execute the query, and change the column values
            // you want to change.
            foreach (Link ord in query1)
            {
                ord.location = "not found";
                ord.Searchname = "gyanendra";
                ord.Start = true;
                // Insert any additional changes to column values.
            }

            // Submit the changes to the database.
            try
            {
                db1.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Provide for exceptions.
            }
            return View();
        }
       
        public ActionResult SANJAYA()
        {
            var a = false;
            var query1 = from ord in db1.Links where ord.Id == true select ord;
            // Query the database for the row to be updated.
            var query =
                from ord in db1.Links
                where ord.Id == true
                select ord;

            // Execute the query, and change the column values
            // you want to change.
            foreach (Link ord in query1)
            {
                ord.location = "not found";
                ord.Searchname = "sanjay";
                ord.Start = true;
                // Insert any additional changes to column values.
            }

            // Submit the changes to the database.
            try
            {
                db1.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Provide for exceptions.
            }
            return View();
        }
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(string searchString)
        {
            var sea = from Searchname in db.Searches select Searchname;
            if (!String.IsNullOrEmpty(searchString))
            {

                sea = sea.Where(s => s.Searchname.Contains(searchString));
                string a = "SAROJ";
                string b = searchString.ToUpper();
                if (string.Compare(a, b) == 0)
                {
                    return RedirectToAction("Saroj");
                }
                string c = "SUDIN";
                if (string.Compare(c, b) == 0)
                {
                    return RedirectToAction("Sudin");
                }
                string d = "GYANENDRA";
                if (string.Compare(d, b) == 0)
                {
                    return RedirectToAction("GYANENDRA");
                }
                string e = "SANJAYA";
                if (string.Compare(e, b) == 0)
                {
                    return RedirectToAction("SANJAYA");
                }
            }
            return View(sea.ToList());
        }

        // GET: Searches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Search search = db.Searches.Find(id);
            if (search == null)
            {
                return HttpNotFound();
            }
            return View(search);
        }

        // POST: Searches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Search search = db.Searches.Find(id);
            db.Searches.Remove(search);
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
