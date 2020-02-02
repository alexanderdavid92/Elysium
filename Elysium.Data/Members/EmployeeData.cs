namespace Elysium.Data.Members
{
    using Elysium.Data.Interfaces;
    using Elysium.Database;
    using Elysium.Entities;
    using System;
    using System.Collections.Generic;
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

        public void Delete(Guid Id)
        {
            using (var context = new ElysiumContext())
            {
                var employee = new Employee()
                {
                    Id = Id
                };
                context.Employee.Remove(employee);

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
                return context.Employee.First(x => x.Id == Id);
            }            
        }
    }
}
