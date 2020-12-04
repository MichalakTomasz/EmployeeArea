using Prism.Mvvm;
using System;

namespace EmployeeArea.Models
{
    public class AbsenceTypeWrapper : BindableBase
    {
        public AbsenceTypeWrapper(AbsenceType absenceType)
        {
            Model = absenceType;
        }

        public AbsenceType Model { get; set; }

        private Guid _id;
        public Guid ID
        {
            get => Model.Id;
            set { SetProperty(ref _id, value, () => Model.Id = value); }
        }
        private string _name;
        public string Name
        {
            get => Model.Name;
            set { SetProperty(ref _name, value, () => Model.Name = value); }
        }
    }
}
