using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestaurantApp.Models;
using RestaurantApp.Models.DbModels;

namespace RestaurantApp.Controllers
{
    /// <summary>
    /// Controller for customer model
    /// </summary>
    public class CustomersController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Customers

        /// <summary>
        /// Index for customer 
        /// </summary>
        /// <returns>View(db.Customers.ToList())</returns>
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        /// <summary>
        /// Details method for customer model
        /// </summary>
        /// <param name="id"> id from customer, which we want to get details about</param>
        /// <returns>View(customer)</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        /// <summary>
        /// Create method (HttpGet type) for customer model
        /// </summary>
        /// <returns>View()</returns>
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create method (HttpPost type) for customer  model
        /// </summary>
        /// <param name="customer">customer, which we want to create</param>
        /// <returns>View(customer)</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId, FirstName, Surname")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        /// <summary>
        /// Edit method (HttpGet type) for customer model
        /// </summary>
        /// <param name="id">id from customer, which we want to edit</param>
        /// <returns>View(customer)</returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edit method (HttpPost type) for customer model
        /// </summary>
        /// <param name="customer">cutomer, which we want to edit</param>
        /// <returns>View(customer)</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }
        /// <summary>
        /// Delete method (HttpGet type) for customer model
        /// </summary>
        /// <param name="id">id from customer, which we want to delete</param>
        /// <returns>View(customer)</returns>
        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        /// <summary>
        /// Delete method (HttpPost type)  for customer model 
        /// </summary>
        /// <param name="id">id from customer, which we delete</param>
        /// <returns>RedirectToAction("Index")</returns>
        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
        /// <summary>
        /// ViewAll method for customer model
        /// </summary>
        /// <returns>View(customers)</returns>
        [HttpGet]
        public ActionResult ViewAll()
        {
            List<Customer> customers;
            using (DatabaseContext db = new DatabaseContext())
                customers = db.Customers.ToList();
            return View(customers);
        }
       
    }
}
