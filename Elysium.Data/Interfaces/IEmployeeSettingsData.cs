namespace Elysium.Data.Interfaces
{
    using Elysium.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IEmployeeSettingsData
    {
        void Add(EmployeeSettings employeeSettings);
        void Edit(EmployeeSettings employeeSettings);
        void Delete(Guid Id);
        EmployeeSettings GetById(Guid Id);
        IQueryable<EmployeeSettings> GetAll();
    }
}
