namespace Elysium.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationUpdates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "SSN", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "SSN");
        }
    }
}
