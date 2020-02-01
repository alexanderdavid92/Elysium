namespace Elysium.Manager.Dto
{
    using System;

    public class EmployeeSettingsDto
    {
        public Guid Id { get; set; }

        public bool ReceiveNotifications { get; set; }

        public virtual EmployeeDto Employee { get; set; }
    }
}
