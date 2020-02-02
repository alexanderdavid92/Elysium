namespace Elysium.Data.Interfaces
{
    using Elysium.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IEmployeeData
    {
        void Add(Employee employee);
        void Edit(Employee employee);
        void Delete(Guid Id);
        Employee GetById(Guid Id);
        List<Employee> GetAll();
    }
}
