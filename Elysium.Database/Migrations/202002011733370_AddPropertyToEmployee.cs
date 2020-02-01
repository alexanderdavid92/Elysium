namespace Elysium.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertyToEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "PhoneNumber");
        }
    }
}
