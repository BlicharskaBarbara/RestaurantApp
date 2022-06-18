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
    /// Controller for cmenu items model
    /// </summary>
    public class MenuItemsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        /// <summary>
        /// Index for menu item
        /// </summary>
        /// <returns>View(menuItems.ToList())</returns>
        // GET: MenuItems
        public ActionResult Index()
        {
            var menuItems = db.MenuItems.Include(m => m.Menu);
            return View(menuItems.ToList());
        }

        // GET: MenuItems/Details/5
        /// <summary>
        /// Details method for menu item model
        /// </summary>
        /// <param name="id"> id from menu item, which we want to get details about</param>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuItem menuItem = db.MenuItems.Find(id);
            if (menuItem == null)
            {
                return HttpNotFound();
            }
            return View(menuItem);
        }

        // GET: MenuItems/Create
        /// <summary>
        /// Create method (HttpGet type) for menu item model
        /// </summary>
        /// <returns>View()</returns>
        public ActionResult Create()
        {
            ViewBag.MenuId = new SelectList(db.Menus, "MenuId", "MenuDescription");
            return View();
        }

        // POST: MenuItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create methot (HttpPost type) for menu item model
        /// </summary>
        /// <param name="menuItem">menu item, which we want to create</param>
        /// <returns>View(menuItem)</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MenuItemId,MenuItemName,Calories,MenuId,Price")] MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                db.MenuItems.Add(menuItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MenuId = new SelectList(db.Menus, "MenuId", "MenuDescription", menuItem.MenuId);
            return View(menuItem);
        }

        // GET: MenuItems/Edit/5
        /// <summary>
        /// Edit method (HttpGet type) for menu item model
        /// </summary>
        /// <param name="id">id from mennu item, which we want to edit</param>
        /// <returns>View(menuItem)</returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuItem menuItem = db.MenuItems.Find(id);
            if (menuItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.MenuId = new SelectList(db.Menus, "MenuId", "MenuDescription", menuItem.MenuId);
            return View(menuItem);
        }

        // POST: MenuItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edit method (HttpPost type) for menu item model
        /// </summary>
        /// <param name="menuItem">menu item, which we want to edit</param>
        /// <returns>View(menuItem)</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MenuItemId,MenuItemName,Calories,MenuId,Price")] MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menuItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MenuId = new SelectList(db.Menus, "MenuId", "MenuDescription", menuItem.MenuId);
            return View(menuItem);
        }

        // GET: MenuItems/Delete/5
        /// <summary>
        /// Delete method (HttpGet type) for menu item model
        /// </summary>
        /// <param name="id">id from menu item, which we want to delete</param>
        /// <returns>View(menuItem)</returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuItem menuItem = db.MenuItems.Find(id);
            if (menuItem == null)
            {
                return HttpNotFound();
            }
            return View(menuItem);
        }
        /// <summary>
        /// Delete method (HttpPost type)  for menu item model 
        /// </summary>
        /// <param name="id">id from menu item, which we delete</param>
        /// <returns>RedirectToAction("Index")</returns>
        // POST: MenuItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MenuItem menuItem = db.MenuItems.Find(id);
            db.MenuItems.Remove(menuItem);
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
        /// ViewAll method for menu item model
        /// </summary>
        /// <returns>View(menuitems.ToList())</returns>
        [HttpGet]
        public ActionResult ViewAll()
        {
            List<MenuItem> menuitems;
            using (DatabaseContext db = new DatabaseContext())
                menuitems = db.MenuItems.ToList();
            return View(menuitems.ToList());
        }
    }
}
