//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestaurantApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orders()
        {
            this.OrderMenuItems = new HashSet<OrderMenuItems>();
        }
    
        public int OrderId { get; set; }
        public int Payment { get; set; }
        public bool Paid { get; set; }
        public string Comments { get; set; }
        public int CustomerId { get; set; }
        public int WaiterId { get; set; }
        public int TableSeatingId { get; set; }
        public Nullable<int> OrderMenuItem_OrderMenuItemId { get; set; }
    
        public virtual Customers Customers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderMenuItems> OrderMenuItems { get; set; }
        public virtual OrderMenuItems OrderMenuItems1 { get; set; }
        public virtual TableSeatings TableSeatings { get; set; }
        public virtual Waiters Waiters { get; set; }
    }
}
