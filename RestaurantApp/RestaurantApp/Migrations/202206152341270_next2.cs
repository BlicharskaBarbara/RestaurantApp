namespace RestaurantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class next2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OrderMenuItems", "UnitPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderMenuItems", "UnitPrice", c => c.Double(nullable: false));
        }
    }
}
