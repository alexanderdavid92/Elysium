namespace Elysium.Manager.Interfaces
{
    using Elysium.Manager.Dto;
    using System;
    using System.Collections.Generic;

    public interface IEmployeeHistoryManager
    {
        void Add(EmployeeHistoryDto employeeHistory);
        void Edit(EmployeeHistoryDto employeeHistory);
        void Delete(Guid Id);
        EmployeeHistoryDto GetById(Guid Id);
        IList<EmployeeHistoryDto> GetAll();
    }
}
