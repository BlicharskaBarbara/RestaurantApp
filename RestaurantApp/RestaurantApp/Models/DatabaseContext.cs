using RestaurantApp.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
namespace RestaurantApp.Models
{
    /// <summary>
    /// class which contains context for database 
    /// </summary>
    public class DatabaseContext: DbContext
    {
      /// <summary>
      /// contructor for DatabaseContext class
      /// </summary>
        public DatabaseContext() : base("RestaurantAppConnectionString") 
        {
            
        }
        /// <summary>
        /// DbSets
        /// </summary>
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderMenuItem> OrderMenuItems { get; set; }
        public DbSet<TableSeating> TableSeatings { get; set; }
        public DbSet<Waiter> Waiters { get; set; }
        /// <summary>
        /// overriding for OnModelCreating method 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<OrderMenuItem>().HasKey(x => new { x.OrderId, x.MenuItemId });
            modelBuilder.Entity<OrderMenuItem>().HasKey(x => new { x.OrderMenuItemId});
            modelBuilder.Entity<OrderMenuItem>()
                .HasRequired(pc => pc.Order)
                .WithMany(p => p.OrderMenuItems)
                .HasForeignKey(pc => pc.OrderId);
            modelBuilder.Entity<OrderMenuItem>()
                .HasRequired(pc => pc.MenuItem)
                .WithMany(p => p.OrderMenuItems)
                .HasForeignKey(pc => pc.MenuItemId);
        }
       
        

    }
   

    
}