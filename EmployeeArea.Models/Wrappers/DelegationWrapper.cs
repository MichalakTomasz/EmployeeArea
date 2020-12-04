using Prism.Mvvm;
using System;

namespace EmployeeArea.Models
{
    public class DelegationWrapper : BindableBase
    {
        public DelegationWrapper(Delegation delegation)
        {
            Model = delegation;
            Employee = delegation.Employee;
        }

        public Delegation Model { get; set; }
        private Guid _id;
        public Guid ID
        {
            get => Model.Id;
            set { SetProperty(ref _id, value, () => Model.Id = value); }
        }
        private DateTime _from;
        public DateTime From
        {
            get => Model.From;
            set { SetProperty(ref _from, value, () => Model.From = value); }
        }
        private DateTime _to;
        public DateTime To
        {
            get => Model.To;
            set { SetProperty(ref _to, value, () => Model.To = value); }
        }
        private string _place;
        public string Place
        {
            get => Model.Place;
            set { SetProperty(ref _place, value, Model.Place = value); }
        }
        private string _description;
        public string Description
        {
            get => Model.Description;
            set { SetProperty(ref _description, value, () => Model.Description = value); }
        }
        public Employee Employee { get; set; }
    }
}
