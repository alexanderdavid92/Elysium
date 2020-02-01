namespace Elysium.Entities
{
    using System;
    public class EmployeeHistory
    {
        public Guid Id { get; set; }
        public EventType Event { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
