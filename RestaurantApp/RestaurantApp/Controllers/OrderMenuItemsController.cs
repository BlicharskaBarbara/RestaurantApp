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
    /// Controller for ordermenuitems model
    /// </summary>
    public class OrderMenuItemsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: OrderMenuItems
        /// <summary>
        /// Index for ordermenuitems model
        /// </summary>
        /// <returns>View(orderMenuItems.ToList())</returns>
        public ActionResult Index()
        {
            var orderMenuItems = db.OrderMenuItems.Include(o => o.MenuItem).Include(o => o.Order);
            return View(orderMenuItems.ToList());
        }

        // GET: OrderMenuItems/Details/5
        /// <summary>
        /// Details method for ordermenuitems model
        /// </summary>
        /// <param name="id"> id from odermenuitem, which we want to get details about</param>
        /// <returns>View(orderMenuItem)</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderMenuItem orderMenuItem = db.OrderMenuItems.Find(id);
            if (orderMenuItem == null)
            {
                return HttpNotFound();
            }
            return View(orderMenuItem);
        }

        // GET: OrderMenuItems/Create
        /// <summary>
        /// Create method (HttpGet type) for ordermenuitem model
        /// </summary>
        /// <returns>View()</returns>
        public ActionResult Create()
        {
            ViewBag.MenuItemId = new SelectList(db.MenuItems, "MenuItemId", "MenuItemId");
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderId");
            return View();
        }

        // POST: OrderMenuItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create method (HttpPost type) for ordermenuitem  model
        /// </summary>
        /// <param name="orderMenuItem">ordermenuitem, which we want to create</param>
        /// <returns>View(orderMenuItem)</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderMenuItemId,OrderId,MenuItemId,Quantity")] OrderMenuItem orderMenuItem)
        {
            if (ModelState.IsValid)
            {
                db.OrderMenuItems.Add(orderMenuItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MenuItemId = new SelectList(db.MenuItems, "MenuItemId", "MenuItemId", orderMenuItem.MenuItemId);
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderId", orderMenuItem.OrderId);
            return View(orderMenuItem);
        }

        // GET: OrderMenuItems/Edit/5
        /// <summary>
        /// Edit method (HttpGet type) for ordermenuitem model
        /// </summary>
        /// <param name="id">id from ordermenuitem, which we want to edit</param>
        /// <returns>View(orderMenuItem)</returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderMenuItem orderMenuItem = db.OrderMenuItems.Find(id);
            if (orderMenuItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.MenuItemId = new SelectList(db.MenuItems, "MenuItemId", "MenuItemName", orderMenuItem.MenuItemId);
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "Comments", orderMenuItem.OrderId);
            return View(orderMenuItem);
        }

        // POST: OrderMenuItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edit method (HttpPost type) for ordermenuitem model
        /// </summary>
        /// <param name="orderMenuItem">ordermenuitem, which we want to edit</param>
        /// <returns>View(orderMenuItem)</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,MenuItemId,OrderMenuItemId,Quantity,UnitPrice")] OrderMenuItem orderMenuItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderMenuItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MenuItemId = new SelectList(db.MenuItems, "MenuItemId", "MenuItemName", orderMenuItem.MenuItemId);
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "Comments", orderMenuItem.OrderId);
            return View(orderMenuItem);
        }

        // GET: OrderMenuItems/Delete/5
        /// <summary>
        /// Delete method (HttpGet type) for ordermenuitem model
        /// </summary>
        /// <param name="id">id from ordermenuitem, which we want to delete</param>
        /// <returns>View(orderMenuItem)</returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderMenuItem orderMenuItem = db.OrderMenuItems.Find(id);
            if (orderMenuItem == null)
            {
                return HttpNotFound();
            }
            return View(orderMenuItem);
        }
        /// <summary>
        /// Delete method (HttpPost type)  for ordermenuitem model 
        /// </summary>
        /// <param name="id">id from ordermenuitem, which we delete</param>
        /// <returns>RedirectToAction("Index")</returns>
        // POST: OrderMenuItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderMenuItem orderMenuItem = db.OrderMenuItems.Find(id);
            db.OrderMenuItems.Remove(orderMenuItem);
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
        /// ViewAll method for ordermenuitem model
        /// </summary>
        /// <returns>View(orderMenuItems)</returns>
        [HttpGet]
        public ActionResult ViewAll()
        {
           
            List<OrderMenuItem> orderMenuItems;
            using (DatabaseContext db = new DatabaseContext())
            {
                
                orderMenuItems = db.OrderMenuItems.ToList();
            }
            return View(orderMenuItems);
        }
    }
}
