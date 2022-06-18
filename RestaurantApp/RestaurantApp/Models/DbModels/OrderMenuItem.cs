using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantApp.Models.DbModels
{
    /// <summary>
    /// Model for class connecting order and menu item classes
    /// </summary>
    public class OrderMenuItem
    {
        /// <summary>
        /// properties (table columns)
        /// </summary>
        [Key]
        public int OrderMenuItemId { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        [ForeignKey("MenuItem")]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int MenuItemId { get; set; }

        public virtual MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }
     
        public virtual List<Order> Orders { get; set; }
        public virtual List<MenuItem> MenuItems { get; set; }
        /// <summary>
        /// constructors
        /// </summary>
        public OrderMenuItem()
        {
            Orders = new List<Order>();
            MenuItems = new List<MenuItem>();
           
        }
      

        public OrderMenuItem(int orderId,  int menuItemId, int quantity)
        {
            
            OrderId = orderId;
            MenuItemId = menuItemId;
            Quantity = quantity;
            Orders = new List<Order>();
            MenuItems = new List<MenuItem>();
        }
    }
}