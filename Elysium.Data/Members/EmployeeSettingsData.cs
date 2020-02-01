namespace Elysium.Data.Members
{
    using Elysium.Data.Interfaces;
    using Elysium.Database;
    using Elysium.Entities;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class EmployeeSettingsData : IEmployeeSettingsData
    {
        public void Add(EmployeeSettings employeeSettings)
        {
            using (var context = new ElysiumContext())
            {
                context.EmployeeSettings.Add(employeeSettings);

                context.SaveChanges();
            }
        }

        public void Delete(Guid Id)
        {
            using (var context = new ElysiumContext())
            {
                var employeeSettings = new EmployeeSettings()
                {
                    Id = Id
                };
                context.EmployeeSettings.Remove(employeeSettings);

                context.SaveChanges();
            }
        }

        public void Edit(EmployeeSettings employeeSettings)
        {
            using (var context = new ElysiumContext())
            {
                var dbEmployeeSettings = context.EmployeeSettings.Find(employeeSettings.Id);
                context.Entry(dbEmployeeSettings).CurrentValues.SetValues(employeeSettings);
                context.SaveChanges();
            }
        }

        public IQueryable<EmployeeSettings> GetAll()
        {
            using (var context = new ElysiumContext())
            {
                return context.EmployeeSettings.AsQueryable();
            }
        }

        public EmployeeSettings GetById(Guid Id)
        {
            using (var context = new ElysiumContext())
            {
                return context.EmployeeSettings.First(x => x.Id == Id);
            }
        }
    }
}
