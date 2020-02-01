namespace Elysium.Manager.Interfaces
{
    using Elysium.Manager.Dto;
    using System;
    using System.Collections.Generic;

    public interface IEmployeeManager
    {
        void Add(EmployeeDto employee);
        void Edit(EmployeeDto employee);
        void Delete(Guid Id);
        EmployeeDto GetById(Guid Id);
        IList<EmployeeDto> GetAll();
    }
}
