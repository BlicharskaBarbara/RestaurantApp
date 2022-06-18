using RestaurantApp.Models;
using RestaurantApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantApp.Controllers
{
    /// <summary>
    /// Controller for order details view model
    /// </summary>
    public class OrderDetailsController : Controller
    {
        // GET: OrderDetails
        public ActionResult Index()
        {
            DatabaseContext orderdb = new DatabaseContext(); //dbcontect class

            List<CustomerWaiterOrderVM> CustomerVMlist = new List<CustomerWaiterOrderVM>(); // to hold list of Customer and order details

            var customerlist = (from Ord in orderdb.Orders join Cust in orderdb.Customers on Ord.CustomerId equals Cust.CustomerId join Wait in orderdb.Waiters on Ord.WaiterId equals Wait.WaiterId select new {Cust.FirstName, Cust.Surname, Wait.LastName, Ord.TableSeatingId, Ord.OrderId, Ord.Paid, Ord.Comments}).ToList();

            //query getting data from database from joining two tables and storing data in customerlist

            foreach (var item in customerlist)

            {

                CustomerWaiterOrderVM objcvm = new CustomerWaiterOrderVM(); // ViewModel

                objcvm.FirstName = item.FirstName;

                objcvm.Surname = item.Surname;
                
                objcvm.LastName = item.LastName;

                objcvm.TableSeatingID = item.TableSeatingId;

                objcvm.OrderId = item.OrderId;
                objcvm.Paid = item.Paid;
                objcvm.Comments = item.Comments;

                CustomerVMlist.Add(objcvm);

            }

            //Using foreach loop fill data from custmerlist to List<CustomerVM>.

            return View(CustomerVMlist); //List of CustomerVM (ViewModel)
        }
    }
}