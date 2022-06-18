using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantApp.Models.DbModels
{
    /// <summary>
    /// Model for customer class
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// properties (table columns)
        /// </summary>
        [Key]
        public int CustomerId { get; set; }
        [Display(Name ="First name")]
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public virtual List<Order> Orders { get; set; }
        /// <summary>
        /// constructors
        /// </summary>
        public Customer()
        {

        }

        public Customer( string firstName, string surname)
        {
           
            FirstName = firstName;
            Surname = surname;
            Orders = new List<Order>();
        }

        [NotMapped]
        public string FullName
        {
            get
            {
                return FirstName + " " + Surname;
            }
        }
    }
}