namespace Elysium.Manager.Interfaces
{
    using Elysium.Manager.Dto;
    using System;
    using System.Collections.Generic;

    public interface IEmployeeSettingsManager
    {
        void Add(EmployeeSettingsDto employeeHistory);
        void Edit(EmployeeSettingsDto employeeHistory);
        void Delete(Guid Id);
        EmployeeSettingsDto GetById(Guid Id);
        IList<EmployeeSettingsDto> GetAll();
    }
}
