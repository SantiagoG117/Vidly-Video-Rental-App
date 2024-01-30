namespace Vidly_Video_Rental_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSubscribedToNewsletterColumnToCustomer : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Customers");
            AddColumn("dbo.Customers", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Customers", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Customers", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Customers", "IsSubscribedToNewsletter");
            AddPrimaryKey("dbo.Customers", "Id");
        }
    }
}
