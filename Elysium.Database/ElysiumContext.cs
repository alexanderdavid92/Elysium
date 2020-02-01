namespace Elysium.Database
{
    using Elysium.Entities;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class ElysiumContext : DbContext
    {
        public ElysiumContext() : base("ElysiumContext")
        {

        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeHistory> EmployeeHistory { get; set; }
        public DbSet<EmployeeSettings> EmployeeSettings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
