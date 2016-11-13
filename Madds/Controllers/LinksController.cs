using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Madds.Models;

namespace Madds.Controllers
{
    public class LinksController : Controller
    {
        private Python_linkEntities db = new Python_linkEntities();
        
        public ActionResult App1()
        {

            var a= false;
            var query1 = from ord in db.Links where ord.Id == true select ord;
            // Query the database for the row to be updated.
          

            while (a != true)
            {
                foreach (Link ord in query1)
                {
                    if (ord.Updated == true)
                    {
                        a = true;
                    }
                }
            }
                return RedirectToAction("Result", "Searches");
    }
        public ActionResult App2()
        {
            var a = false;
            var query1 = from ord in db.Links where ord.Id == true select ord;
            var query = from ord in db.Links where ord.Id == false select ord;
            foreach (Link ord in query)
            {
                ord.Searchname = "Sanjaya";
                //a = ord.Updated;
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            while (a != true)
            {
                foreach (Link ord in query1)
                {
                    if (ord.Updated == true)
                    {
                      a=true;
                    }
                    if(ord.Updated==false)
                    {
                        return RedirectToAction("Index", "Links");
                    }
                }
            }
            return RedirectToAction("Result", "Searches");
        }
        public ActionResult App3()
        {
            var a = false;
            var query1 = from ord in db.Links where ord.Id == true select ord;
            var query = from ord in db.Links where ord.Id == false select ord;
            foreach (Link ord in query)
            {
                ord.Searchname = "Saroj";
               // a = ord.Updated;
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            while (a != true)
            {
                foreach (Link ord in query1)
                {
                    if (ord.Updated == true)
                    {
                        a = true;
                    }
                }
            }
            return RedirectToAction("Result", "Searches");
        }
        public ActionResult App4()
        {
            var a = true;
            var query1 = from ord in db.Links where ord.Id == true select ord;
            var query = from ord in db.Links where ord.Id == false select ord;
            foreach (Link ord in query)
            {
                ord.Searchname = "Sudin";
               // a = ord.Updated;
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            while (a != true)
            {
                foreach (Link ord in query1)
                {
                 if(ord.Updated==true)
                    {
                        a = true;
                    }   
                   // a = ord.Updated;
                }
            }
            return RedirectToAction("Result", "Searches");
        }
        private UserEntities1 db2 = new UserEntities1();
        // GET: Links
        public ActionResult Index()
        {
            return View(db.Links.ToList());
        }

        // GET: Links/Details/5
        public ActionResult Details(bool? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Link link = db.Links.Find(id);
            if (link == null)
            {
                return HttpNotFound();
            }
            return View(link);
        }

        // GET: Links/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Links/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Searchname,location,Updated")] Link link)
        {
            if (ModelState.IsValid)
            {
                db.Links.Add(link);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(link);
        }

        // GET: Links/Edit/5
        public ActionResult Edit(bool? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Link link = db.Links.Find(id);
            if (link == null)
            {
                return HttpNotFound();
            }
            return View(link);
        }

        // POST: Links/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Searchname,location,Updated")] Link link)
        {
            if (ModelState.IsValid)
            {
                db.Entry(link).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(link);
        }

        // GET: Links/Delete/5
        public ActionResult Delete(bool? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Link link = db.Links.Find(id);
            if (link == null)
            {
                return HttpNotFound();
            }
            return View(link);
        }

        // POST: Links/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(bool id)
        {
            Link link = db.Links.Find(id);
            db.Links.Remove(link);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Re()
        {

            var query1 = from ord in db.Links where ord.Id == true select ord;
            // Query the database for the row to be updated.
            var query =
                from ord in db.Links
                where ord.Id == true
                select ord;

            // Execute the query, and change the column values
            // you want to change.
            foreach (Link ord in query1)
            {
                ord.Updated = false;
                ord.Start = false;
               
                // Insert any additional changes to column values.
            }

            // Submit the changes to the database.
            try
            {
                db.SaveChanges();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Provide for exceptions.
            }
            return RedirectToAction("Search", "Searches");
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
