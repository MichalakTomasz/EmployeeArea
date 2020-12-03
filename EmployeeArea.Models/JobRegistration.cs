using System;

namespace EmployeeArea.Models
{
    public class JobRegistration
    {
        public Guid Id { get; set; }
        public Employee Emploee { get; set; }
        public DateTime JobStart { get; set; }
        public DateTime JobEnd { get; set; }
    }
}
