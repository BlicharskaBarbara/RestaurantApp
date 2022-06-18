namespace RestaurantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yyy : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MenuItems", new[] { "OrderMenuItem_OrderId", "OrderMenuItem_MenuItemId" }, "dbo.OrderMenuItems");
            DropForeignKey("dbo.Orders", new[] { "OrderMenuItem_OrderId", "OrderMenuItem_MenuItemId" }, "dbo.OrderMenuItems");
            DropIndex("dbo.Orders", new[] { "OrderMenuItem_OrderId", "OrderMenuItem_MenuItemId" });
            DropIndex("dbo.MenuItems", new[] { "OrderMenuItem_OrderId", "OrderMenuItem_MenuItemId" });
            RenameColumn(table: "dbo.MenuItems", name: "OrderMenuItem_OrderId", newName: "OrderMenuItem_OrderMenuItemId");
            RenameColumn(table: "dbo.Orders", name: "OrderMenuItem_OrderId", newName: "OrderMenuItem_OrderMenuItemId");
            DropPrimaryKey("dbo.OrderMenuItems");
            AlterColumn("dbo.OrderMenuItems", "OrderMenuItemId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.OrderMenuItems", "OrderMenuItemId");
            CreateIndex("dbo.Orders", "OrderMenuItem_OrderMenuItemId");
            CreateIndex("dbo.MenuItems", "OrderMenuItem_OrderMenuItemId");
            AddForeignKey("dbo.MenuItems", "OrderMenuItem_OrderMenuItemId", "dbo.OrderMenuItems", "OrderMenuItemId");
            AddForeignKey("dbo.Orders", "OrderMenuItem_OrderMenuItemId", "dbo.OrderMenuItems", "OrderMenuItemId");
            DropColumn("dbo.Orders", "OrderMenuItem_MenuItemId");
            DropColumn("dbo.MenuItems", "OrderMenuItem_MenuItemId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MenuItems", "OrderMenuItem_MenuItemId", c => c.Int());
            AddColumn("dbo.Orders", "OrderMenuItem_MenuItemId", c => c.Int());
            DropForeignKey("dbo.Orders", "OrderMenuItem_OrderMenuItemId", "dbo.OrderMenuItems");
            DropForeignKey("dbo.MenuItems", "OrderMenuItem_OrderMenuItemId", "dbo.OrderMenuItems");
            DropIndex("dbo.MenuItems", new[] { "OrderMenuItem_OrderMenuItemId" });
            DropIndex("dbo.Orders", new[] { "OrderMenuItem_OrderMenuItemId" });
            DropPrimaryKey("dbo.OrderMenuItems");
            AlterColumn("dbo.OrderMenuItems", "OrderMenuItemId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.OrderMenuItems", new[] { "OrderId", "MenuItemId" });
            RenameColumn(table: "dbo.Orders", name: "OrderMenuItem_OrderMenuItemId", newName: "OrderMenuItem_OrderId");
            RenameColumn(table: "dbo.MenuItems", name: "OrderMenuItem_OrderMenuItemId", newName: "OrderMenuItem_OrderId");
            CreateIndex("dbo.MenuItems", new[] { "OrderMenuItem_OrderId", "OrderMenuItem_MenuItemId" });
            CreateIndex("dbo.Orders", new[] { "OrderMenuItem_OrderId", "OrderMenuItem_MenuItemId" });
            AddForeignKey("dbo.Orders", new[] { "OrderMenuItem_OrderId", "OrderMenuItem_MenuItemId" }, "dbo.OrderMenuItems", new[] { "OrderId", "MenuItemId" });
            AddForeignKey("dbo.MenuItems", new[] { "OrderMenuItem_OrderId", "OrderMenuItem_MenuItemId" }, "dbo.OrderMenuItems", new[] { "OrderId", "MenuItemId" });
        }
    }
}
