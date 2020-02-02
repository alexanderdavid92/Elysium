namespace Elysium.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertiesToEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "Position", c => c.String());
            AddColumn("dbo.Employee", "Office", c => c.String());
            AddColumn("dbo.Employee", "Salary", c => c.Long(nullable: false));
            AddColumn("dbo.Employee", "Currency", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "Currency");
            DropColumn("dbo.Employee", "Salary");
            DropColumn("dbo.Employee", "Office");
            DropColumn("dbo.Employee", "Position");
        }
    }
}
