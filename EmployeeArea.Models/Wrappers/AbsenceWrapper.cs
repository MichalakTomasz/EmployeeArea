using Prism.Mvvm;
using System;

namespace EmployeeArea.Models
{
    public class AbsenceWrapper :  BindableBase
    {
        public AbsenceWrapper(Absence absence)
        {
            if (absence == null)
                throw new ArgumentNullException();

            Model = absence;
            Employee = absence.Employee;
            AbsenceType = absence.AbsenceType;            
        }

        public Absence Model { get; set; }

        private Guid _id;
        public Guid Id
        {
            get => Model.Id;
            set
            {
                SetProperty(ref _id, value, () => Model.Id = value);
            }
        }

        private DateTime _from;
        public DateTime From
        {
            get => Model.From;
            set 
            { 
                SetProperty(ref _from, value, () => Model.From = value); 
            }
        }
        private DateTime _to;
        public DateTime To
        {
            get => Model.To;
            set 
            { 
                SetProperty(ref _to, value, () => Model.To = value); 
            }
        }
        private string _description;
        public string Description
        {
            get => Model.Description;
            set 
            { 
                SetProperty(ref _description, value, () => Model.Description = value); 
            }
        }

        public Employee Employee { get; set; }
        public AbsenceType AbsenceType { get; set; }
    }
}
