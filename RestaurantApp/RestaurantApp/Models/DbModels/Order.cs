using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantApp.Models.DbModels
{
    /// <summary>
    /// enum for payment type
    /// </summary>
    public enum PaymentType { card,cash,blik}
    /// <summary>
    /// Model for order class
    /// </summary>
    public class Order
    {
        /// <summary>
        /// properties (table columns)
        /// </summary>
        [Key]
        public int OrderId { get; set; }
        public PaymentType Payment { get; set; }
        public bool Paid { get; set; }
        public string Comments { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        [ForeignKey("Waiter")]
        public int WaiterId { get; set; }
        public virtual Waiter Waiter {get;set;}
        [ForeignKey("TableSeating")]
        public int TableSeatingId { get; set; }
        public virtual TableSeating TableSeating { get; set; }

        public List<OrderMenuItem> OrderMenuItems { get; set; } = new List<OrderMenuItem>();
        /// <summary>
        /// constructors
        /// </summary>
        public Order()
        {

        }

        public Order(PaymentType payment, bool paid, string comments, int customerId,int waiterId,int tableSeatingId)
        {
          
            Payment = payment;
            Paid = paid;
            Comments = comments;
            CustomerId = customerId;
            WaiterId = waiterId;
            TableSeatingId = tableSeatingId;
            OrderMenuItems = new List<OrderMenuItem>();
        }
    }
}