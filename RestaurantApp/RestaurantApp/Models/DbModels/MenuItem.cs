using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantApp.Models.DbModels
{
    /// <summary>
    /// Model for menu item class
    /// </summary>
    public class MenuItem
    {
        /// <summary>
        /// properties (table columns)
        /// </summary>
        [Key]
        public int MenuItemId { get; set; }
        [Display(Name ="Name")]
        public string MenuItemName { get; set; }
        public int Calories { get; set; }
        public int Price { get; set; }
        [ForeignKey("Menu")]
        public int MenuId { get; set; }
        public List<OrderMenuItem> OrderMenuItems { get; set; } = new List<OrderMenuItem>();
        /// <summary>
        /// constructors
        /// </summary>
        public MenuItem()
        {
            
        }

        public MenuItem(string menuItemName, int calories, int price, int menuId)
        {
            
            MenuItemName = menuItemName;
            Calories = calories;
            Price = price;
            MenuId = menuId;
            OrderMenuItems = new List<OrderMenuItem>();
        }

        public virtual Menu Menu { get; set; }

    }
}