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
    /// Controller for tableseatings model
    /// </summary>
    public class TableSeatingsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: TableSeatings
        /// <summary>
        /// Index for tableseatings
        /// </summary>
        /// <returns>View(db.TableSeatings.ToList())</returns>
        public ActionResult Index()
        {
            return View(db.TableSeatings.ToList());
        }

        // GET: TableSeatings/Details/5
        /// <summary>
        /// Details method for tableseatings model
        /// </summary>
        /// <param name="id"> id from table, which we want to get details about</param>
        /// <returns>View(tableSeating)</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableSeating tableSeating = db.TableSeatings.Find(id);
            if (tableSeating == null)
            {
                return HttpNotFound();
            }
            return View(tableSeating);
        }

        // GET: TableSeatings/Create
        /// <summary>
        /// Create method (HttpGet type) for tableseatings model
        /// </summary>
        /// <returns>View()</returns>
        public ActionResult Create()
        {
            return View();
        }

        // POST: TableSeatings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create method (HttpPost type) for tableseatings  model
        /// </summary>
        /// <param name="tableSeating">table, which we want to create</param>
        /// <returns>View(tableSeating)</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TableSeatingId,Seats")] TableSeating tableSeating)
        {
            if (ModelState.IsValid)
            {
                db.TableSeatings.Add(tableSeating);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tableSeating);
        }

        // GET: TableSeatings/Edit/5
        /// <summary>
        /// Edit method (HttpGet type) for tableseatings model
        /// </summary>
        /// <param name="id">id from table, which we want to edit</param>
        /// <returns>View(tableSeating)</returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableSeating tableSeating = db.TableSeatings.Find(id);
            if (tableSeating == null)
            {
                return HttpNotFound();
            }
            return View(tableSeating);
        }

        // POST: TableSeatings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edit method (HttpPost type) for tableseating model
        /// </summary>
        /// <param name="tableSeating">table, which we want to edit</param>
        /// <returns>View(tableSeating)</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TableSeatingId,Seats")] TableSeating tableSeating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tableSeating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tableSeating);
        }

        // GET: TableSeatings/Delete/5
        /// <summary>
        /// Delete method (HttpGet type) for tableseatings model
        /// </summary>
        /// <param name="id">id from table, which we want to delete</param>
        /// <returns>View(tableSeating)</returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableSeating tableSeating = db.TableSeatings.Find(id);
            if (tableSeating == null)
            {
                return HttpNotFound();
            }
            return View(tableSeating);
        }

        // POST: TableSeatings/Delete/5
        /// <summary>
        /// Delete method (HttpPost type)  for tableseatings model 
        /// </summary>
        /// <param name="id">id from table, which we delete</param>
        /// <returns>RedirectToAction("Index")</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TableSeating tableSeating = db.TableSeatings.Find(id);
            db.TableSeatings.Remove(tableSeating);
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
        /// ViewAll method for tableseatings model
        /// </summary>
        /// <returns>View(tableSeatings)</returns>
        [HttpGet]
        public ActionResult ViewAll()
        {
            List<TableSeating> tableSeatings;
            using (DatabaseContext db = new DatabaseContext())
                tableSeatings = db.TableSeatings.ToList();
            return View(tableSeatings);
        }
    }
}
