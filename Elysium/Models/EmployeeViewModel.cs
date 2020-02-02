namespace Elysium.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class EmployeeViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }
        public string Position { get; set; }
        public string Office { get; set; }
        public string Salary { get; set; }
        public string Currency { get; set; }
        public string PhoneNumber { get; set; }
        public string SSN { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime EmploymentDate { get; set; }
        public DepartmentViewModel Department { get; set; }
    }
}