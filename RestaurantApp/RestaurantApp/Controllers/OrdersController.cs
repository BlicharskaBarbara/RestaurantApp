using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DocuSign.eSign.Model;
using RestaurantApp.Models;
using RestaurantApp.Models.DbModels;

namespace RestaurantApp.Controllers
{
    /// <summary>
    /// Controller for order model
    /// </summary>
    public class OrdersController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Orders
        /// <summary>
        /// Index for order
        /// </summary>
        /// <returns>View(orders.ToList())</returns>
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Customer).Include(o => o.TableSeating).Include(o => o.Waiter);
            return View(orders.ToList());
        }
        /// <summary>
        /// Details method for order model
        /// </summary>
        /// <param name="id"> id from order, which we want to get details about</param>
        /// <returns>View(order)</returns>
        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        /// <summary>
        /// Create method (HttpGet type) for order model
        /// </summary>
        /// <returns>View()</returns>
        public ActionResult Create()
        {
            
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "FullName");
            ViewBag.TableSeatingId = new SelectList(db.TableSeatings, "TableSeatingId", "TableSeatingId");
            ViewBag.WaiterId = new SelectList(db.Waiters, "WaiterId", "FullName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create method (HttpPost type) for order  model
        /// </summary>
        /// <param name="order">order, which we want to create</param>
        /// <returns>View(order)</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,Payment,Paid,Comments,CustomerId,WaiterId,TableSeatingId")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "FullName", order.CustomerId);
            ViewBag.TableSeatingId = new SelectList(db.TableSeatings, "TableSeatingId", "TableSeatingId", order.TableSeatingId);
            ViewBag.WaiterId = new SelectList(db.Waiters, "WaiterId", "FullName", order.WaiterId);
            return View(order);
        }

        // GET: Orders/Edit/5
        /// Edit method (HttpGet type) for order model
        /// </summary>
        /// <param name="id">id from order, which we want to edit</param>
        /// <returns>View(order)</returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerId", order.CustomerId);
            ViewBag.TableSeatingId = new SelectList(db.TableSeatings, "TableSeatingId", "TableSeatingId", order.TableSeatingId);
            ViewBag.WaiterId = new SelectList(db.Waiters, "WaiterId", "FirstName", order.WaiterId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edit method (HttpPost type) for order model
        /// </summary>
        /// <param name="order">cutomer, which we want to edit</param>
        /// <returns>View(order)</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,Payment,Paid,Comments,CustomerId,WaiterId,TableSeatingId")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerId", order.CustomerId);
            ViewBag.TableSeatingId = new SelectList(db.TableSeatings, "TableSeatingId", "TableSeatingId", order.TableSeatingId);
            ViewBag.WaiterId = new SelectList(db.Waiters, "WaiterId", "FirstName", order.WaiterId);
            return View(order);
        }

        // GET: Orders/Delete/5
        /// <summary>
        /// Delete method (HttpGet type) for order model
        /// </summary>
        /// <param name="id">id from order, which we want to delete</param>
        /// <returns>View(order)</returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        /// <summary>
        /// Delete method (HttpPost type)  for order model 
        /// </summary>
        /// <param name="id">id from order, which we delete</param>
        /// <returns>RedirectToAction("Index")</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
        /// ViewAll method for order model
        /// </summary>
        /// <returns>View(orders)</returns>
        [HttpGet]
        public ActionResult ViewAll()
        {

            List<Order> orders;
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Configuration.LazyLoadingEnabled = false;
                orders = db.Orders.ToList();
               
            }
            return View(orders);

        }
    }
}
