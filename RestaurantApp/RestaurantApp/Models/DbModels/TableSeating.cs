using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantApp.Models.DbModels
{
    /// <summary>
    /// Model for table seating class
    /// </summary>
    public class TableSeating
    {
        /// <summary>
        /// properties (table columns)
        /// </summary>
        [Key]
        public int TableSeatingId { get; set; }
        public int Seats { get; set; }
        public virtual List<Order> Orders { get; set; }
        /// <summary>
        /// constructors
        /// </summary>
        public TableSeating()
        {
            Orders = new List<Order>();
        }

        public TableSeating(int seats)
        {
            Seats = seats;
            Orders = new List<Order>();
        }
    }
}