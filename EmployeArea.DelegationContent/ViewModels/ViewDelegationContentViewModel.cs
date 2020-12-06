using EmployeeArea.Models;
using EmployeeArea.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace EmployeArea.DelegationContent.ViewModels
{
    public class ViewDelegationContentViewModel : BindableBase
    {
        private readonly IDataService _dataService;

        public ViewDelegationContentViewModel(IDataService dataService)
        {
            _dataService = dataService;
            RefreshEmployees();
            var delegations = _dataService.GetDelegations().Select(s => new DelegationWrapper(s));
            Delegations = new ObservableCollection<DelegationWrapper>(delegations);
            From = DateTime.Today;
            To = DateTime.Today;
        }

        private void RefreshEmployees()
        {
            var employees = _dataService.GetEmployees().Select(s => new EmployeeWrapper(s));
            Employees = new ObservableCollection<EmployeeWrapper>(employees);
        }

        private ObservableCollection<EmployeeWrapper> _employees;
        public ObservableCollection<EmployeeWrapper> Employees
        {
            get { return _employees; }
            set { SetProperty(ref _employees, value); }
        }
        private ObservableCollection<DelegationWrapper> _delegations;
        public ObservableCollection<DelegationWrapper> Delegations
        {
            get { return _delegations; }
            set { SetProperty(ref _delegations, value); }
        }
        private EmployeeWrapper _empoyee;
        public EmployeeWrapper Employee
        {
            get { return _empoyee; }
            set { SetProperty(ref _empoyee, value); }
        }
        private DateTime _from;
        public DateTime From
        {
            get { return _from; }
            set { SetProperty(ref _from, value); }
        }
        private DateTime _to;
        public DateTime To
        {
            get { return _to; }
            set { SetProperty(ref _to, value); }
        }
        private string _place;  
        public string Place
        {
            get { return _place; }
            set { SetProperty(ref _place, value); }
        }
        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }
        private DelegateCommand _saveDelegationCommand;
        public DelegateCommand SaveDelegationCommand =>
            _saveDelegationCommand ?? (_saveDelegationCommand = 
            new DelegateCommand(ExecuteSaveDelegationCommand, CanExecuteSaveDelegationCommand)
            .ObservesProperty(() => Employee)
            .ObservesProperty(() => Place)
            .ObservesProperty(() => Description));

        void ExecuteSaveDelegationCommand()
        {
            var delegation = new Delegation
            {
                Employee = Employee.Model,
                From = From,
                To = To,
                Place = Place,
                Description = Description
            };
            _dataService.AddDelegation(delegation);
            var delegationWrapper = new DelegationWrapper(delegation);
            Delegations.Add(delegationWrapper);
        }

        bool CanExecuteSaveDelegationCommand()
            => Employee != null && 
            !string.IsNullOrEmpty(Place) && 
            !string.IsNullOrEmpty(Description);
    }
}
