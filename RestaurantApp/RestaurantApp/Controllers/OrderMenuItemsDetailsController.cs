using RestaurantApp.Models;
using RestaurantApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantApp.Controllers
{
    public class OrderMenuItemsDetailsController : Controller
    {
        // GET: OrderMenuItemsDetails
        public ActionResult Index()
        {
            DatabaseContext orderdb = new DatabaseContext(); //dbcontect class

            List<OrderMenuItemVM> CustomerVMlist = new List<OrderMenuItemVM>(); // to hold list of Customer and order details

            var customerlist = (from MenuIt in orderdb.MenuItems join OrdIt in orderdb.OrderMenuItems on MenuIt.MenuItemId equals OrdIt.MenuItemId select new { OrdIt.OrderId,MenuIt.MenuItemName,OrdIt.Quantity }).ToList();

            //query getting data from database from joining two tables and storing data in customerlist

            foreach (var item in customerlist)

            {

                OrderMenuItemVM objcvm = new OrderMenuItemVM(); // ViewModel

                objcvm.OrderId = item.OrderId;

                objcvm.MenuItemName= item.MenuItemName;

                objcvm.Quantity = item.Quantity;

                

                CustomerVMlist.Add(objcvm);

            }

            //Using foreach loop fill data from custmerlist to List<CustomerVM>.

            return View(CustomerVMlist); //List of CustomerVM (ViewModel)
        }
    }
}