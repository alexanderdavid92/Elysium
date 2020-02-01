namespace Elysium.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    public class EmployeeSettings
    {
        [ForeignKey("Employee")]
        public Guid Id { get; set; }

        public bool ReceiveNotifications { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
