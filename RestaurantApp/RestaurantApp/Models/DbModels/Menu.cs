using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantApp.Models.DbModels
{
    /// <summary>
    /// Model for menu class
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// properties (table columns)
        /// </summary>
        [Key]
        public int MenuId { get; set; }
        [Display(Name ="Menu description")]
        public string MenuDescription { get; set; }
        [Display(Name ="Menu items")]
        public virtual List<MenuItem> MenuItems { get; set; }
        /// <summary>
        /// constructors
        /// </summary>
        public Menu()
        {
            MenuItems = new List<MenuItem>();
        }

        public Menu(string menuDescription)
        {
            MenuDescription = menuDescription;
            MenuItems = new List<MenuItem>();
        }

     
    }
}