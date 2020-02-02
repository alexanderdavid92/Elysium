namespace Elysium.Data.Members
{
    using Elysium.Data.Interfaces;
    using Elysium.Database;
    using Elysium.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class EmployeeData : IEmployeeData
    {

        public EmployeeData()
        {

        }
        public void Add(Employee employee)
        {
            using (var context = new ElysiumContext())
            {
                context.Employee.Add(employee);

                context.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            using (var context = new ElysiumContext())
            {
                var employee = new Employee()
                {
                    Id = id
                };

                var settings = new EmployeeSettings { Id = id };
                context.Entry(settings).State = EntityState.Deleted;
                context.SaveChanges();

                context.Employee.Attach(employee);
                context.Entry(employee).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Edit(Employee employee)
        {
            using (var context = new ElysiumContext())
            {
                var dbEmployee = context.Employee.Find(employee.Id);
                context.Entry(dbEmployee).CurrentValues.SetValues(employee);
                context.SaveChanges();
            }
        }

        public List<Employee> GetAll()
        {
            using (var context = new ElysiumContext())
            {
                context.Configuration.LazyLoadingEnabled = false;
                return context.Employee.ToList();
            }
        }

        public Employee GetById(Guid Id)
        {
            using (var context = new ElysiumContext())
            {
                context.Configuration.LazyLoadingEnabled = false;
                return context.Employee.First(x => x.Id == Id);
            }            
        }
    }
}
