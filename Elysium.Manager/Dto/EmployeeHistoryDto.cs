namespace Elysium.Manager.Dto
{
    using Elysium.Entities;
    using System;

    public class EmployeeHistoryDto
    {
        public Guid Id { get; set; }
        public EventType Event { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid EmployeeId { get; set; }
        public EmployeeDto Employee { get; set; }
    }
}
