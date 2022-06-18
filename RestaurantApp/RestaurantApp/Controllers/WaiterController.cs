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
    /// Controller for waiter model
    /// </summary>
    public class WaiterController : Controller
    {
        /// <summary>
        /// Index for waiter
        /// </summary>
        /// <returns>View()</returns>

        // GET: Waiter
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult View(int id)
        {
            Waiter waiter;
            using (DatabaseContext db = new DatabaseContext())
                waiter = db.Waiters.FirstOrDefault(x => x.WaiterId == id);

            return View(waiter);
        }
        /// <summary>
        /// Create method (HttpGet type) for waiter model
        /// </summary>
        /// <returns>return View(new Waiter())</returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Waiter());
        }
        /// <summary>
        /// Create method (HttpPost type) for waiter model
        /// </summary>
        /// <param name="waiter">waiter, which we want to create</param>
        /// <returns>RedirectToAction("Index")</returns>
        [HttpPost]
        public ActionResult Create(Waiter waiter)
        {
            if (!ModelState.IsValid)
            {
                return View(new Waiter());
            }
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Waiters.Add(waiter);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Edit method (HttpGet type) for waiter model
        /// </summary>
        /// <param name="id">id from waiter, which we want to edit</param>
        /// <returns>View(waiter)</returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Waiter waiter;
            using (DatabaseContext db = new DatabaseContext())
                waiter = db.Waiters.FirstOrDefault(x => x.WaiterId == id);
            return View(waiter);
        }

        /// <summary>
        /// Edit method (HttpPost type) for waiter model
        /// </summary>
        /// <param name="waiter">waiter, which we want to edit</param>
        /// <returns>return RedirectToAction("ViewAll")</returns>
        [HttpPost]
        public ActionResult Edit(Waiter waiter)
        {
            if (!ModelState.IsValid)
                return View(waiter);

            using (DatabaseContext db = new DatabaseContext())
            {
                db.Entry(waiter).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("ViewAll");
        }
        /// <summary>
        /// Delete method (HttpGet type) for waiter model
        /// </summary>
        /// <param name="id">id from waiter, which we want to delete</param>
        /// <returns>View(waiter)</returns>

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Waiter waiter;
            using (DatabaseContext db = new DatabaseContext())
            {
                waiter = db.Waiters.FirstOrDefault(x => x.WaiterId == id);
            }
            return View(waiter);
        }
        /// <summary>
        /// Delete method (HttpPost type)  for waiter model 
        /// </summary>
        /// <param name="id">id from waiter, which we want to delete</param>
        /// <returns>RedirectToAction("Index")</returns>

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
            Waiter waiter;
            using (DatabaseContext db = new DatabaseContext())
            {
                waiter = db.Waiters.FirstOrDefault(x => x.WaiterId == id);
                db.Waiters.Remove(waiter);
                db.SaveChanges();
            }

            return RedirectToAction("ViewAll");
        }
        /// <summary>
        /// Details method for waiter model
        /// </summary>
        /// <param name="id"> id from waiter, which we want to get details about</param>
        /// <returns>View(waiter)</returns>
        [HttpGet]
        public ActionResult Details(int id)
        {
            Waiter waiter;
            using (DatabaseContext db = new DatabaseContext())
            {
                waiter = db.Waiters.FirstOrDefault(x => x.WaiterId == id);
            }
            return View(waiter);
        }
        /// <summary>
        /// ViewAll method for waiter model
        /// </summary>
        /// <returns>View(waiters)</returns>
        [HttpGet]
        public ActionResult ViewAll()
        {
            List<Waiter> waiters;
            using (DatabaseContext db = new DatabaseContext())
                waiters = db.Waiters.ToList();
            return View(waiters);
        }
    }
}