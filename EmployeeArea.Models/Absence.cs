using System;

namespace EmployeeArea.Models
{
    public class Absence
    {
        public Guid Id { get; set; }
        public Employee Employee { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public AbsenceType AbsenceType { get; set; }
        public string Description { get; set; }
    }
}
