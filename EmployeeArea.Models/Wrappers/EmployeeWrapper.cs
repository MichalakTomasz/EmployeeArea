using Prism.Mvvm;
using System;

namespace EmployeeArea.Models
{
    public class EmployeeWrapper : BindableBase
    {
        public EmployeeWrapper(Employee employee)
        {
            Model = employee;
        }
        public Employee Model { get; set; }
        private Guid _id;
        public Guid Id
        {
            get => Model.Id;
            set { SetProperty(ref _id, value, () => Model.Id = value); }
        }
        private string _firstName;
        public string FirstName
        {
            get => Model.FirstName;
            set { SetProperty(ref _firstName, value, () => Model.FirstName = value); }
        }
        private string _lastName;
        public string LastName
        {
            get => Model.LastName;
            set { SetProperty(ref _lastName, value, () => Model.LastName = value); }
        }
    }
}
