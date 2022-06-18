using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApp.ViewModels
{
    /// <summary>
    /// view model, which connect order with waiter model and  customer model
    /// </summary>
    public class CustomerWaiterOrderVM
    {
        public string FirstName; //Customer
        public string Surname; //Customer
        public string LastName; //Waiter
        public int TableSeatingID; //Order
        public int OrderId; //Order
        public bool Paid; //Order
        public string Comments; //Order

    }
}