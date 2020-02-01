namespace Elysium.Data.Interfaces
{
    using Elysium.Entities;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IEmployeeHistoryData
    {
        void Add(EmployeeHistory employeeHistory);
        void Edit(EmployeeHistory employeeHistory);
        void Delete(Guid Id);
        EmployeeHistory GetById(Guid Id);
        IQueryable<EmployeeHistory> GetAll();
    }
}
