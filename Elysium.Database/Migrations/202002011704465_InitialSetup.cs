namespace Elysium.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        EmploymentDate = c.DateTime(nullable: false),
                        Department = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeHistory",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Event = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        EmployeeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.EmployeeSettings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ReceiveNotifications = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeSettings", "Id", "dbo.Employee");
            DropForeignKey("dbo.EmployeeHistory", "EmployeeId", "dbo.Employee");
            DropIndex("dbo.EmployeeSettings", new[] { "Id" });
            DropIndex("dbo.EmployeeHistory", new[] { "EmployeeId" });
            DropTable("dbo.EmployeeSettings");
            DropTable("dbo.EmployeeHistory");
            DropTable("dbo.Employee");
        }
    }
}
