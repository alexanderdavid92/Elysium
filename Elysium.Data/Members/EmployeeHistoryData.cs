namespace Elysium.Data.Members
{
    using Elysium.Data.Interfaces;
    using Elysium.Database;
    using Elysium.Entities;
    using System;
    using System.Linq;

    public class EmployeeHistoryData : IEmployeeHistoryData
    {
        public void Add(EmployeeHistory employeeHistory)
        {
            using (var context = new ElysiumContext())
            {
                context.EmployeeHistory.Add(employeeHistory);

                context.SaveChanges();
            }
        }

        public void Delete(Guid Id)
        {
            using (var context = new ElysiumContext())
            {
                var employeeHistory = new EmployeeHistory()
                {
                    Id = Id
                };
                context.EmployeeHistory.Remove(employeeHistory);

                context.SaveChanges();
            }
        }

        public void Edit(EmployeeHistory employeeHistory)
        {
            using (var context = new ElysiumContext())
            {
                var dbEmployeeHistory = context.EmployeeHistory.Find(employeeHistory.Id);
                context.Entry(dbEmployeeHistory).CurrentValues.SetValues(employeeHistory);
                context.SaveChanges();
            }
        }

        public IQueryable<EmployeeHistory> GetAll()
        {
            using (var context = new ElysiumContext())
            {
                return context.EmployeeHistory.AsQueryable();
            }
        }

        public EmployeeHistory GetById(Guid Id)
        {
            using (var context = new ElysiumContext())
            {
                return context.EmployeeHistory.First(x => x.Id == Id);
            }
        }
    }
}
