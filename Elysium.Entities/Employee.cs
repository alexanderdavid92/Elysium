namespace Elysium.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string SSN { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime EmploymentDate { get; set; }
        public Department Department { get; set; }
        public string Position { get; set; }
        public string Office { get; set; }
        public long Salary { get; set; }
        public string Currency { get; set; }
        public virtual EmployeeSettings Settings { get; set; }
        public virtual ICollection<EmployeeHistory> History { get; set; }
    }
}
