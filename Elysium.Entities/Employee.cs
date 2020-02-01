namespace Elysium.Entities
{
    using System;
    using System.Collections.Generic;

    public class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime EmploymentDate { get; set; }
        public Department Department { get; set; }
        public virtual EmployeeSettings Settings { get; set; }
        public virtual ICollection<EmployeeHistory> History { get; set; }
    }
}
