using EmployeeArea.Models;
using EmployeeArea.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EmployeeArea.VacationContent.ViewModels
{
    public class ViewVacationContentViewModel : BindableBase
    {
        private readonly IDataService _dataService;

        public ViewVacationContentViewModel(IDataService dataService)
        {
            _dataService = dataService;
            var employees = _dataService.GetEmployees().Select(s => new EmployeeWrapper(s));
            Employees = new ObservableCollection<EmployeeWrapper>(employees);
            var vacations = _dataService.GetAbsences().Select(s => new AbsenceWrapper(s));
            Vacations = new ObservableCollection<AbsenceWrapper>(vacations);
            AbsenceTypes = _dataService.GetAbsenceTypes();
            From = DateTime.Today;
            To = DateTime.Today;
        }
        private ObservableCollection<EmployeeWrapper> _employees;
        public ObservableCollection<EmployeeWrapper> Employees
        {
            get { return _employees; }
            set { SetProperty(ref _employees, value); }
        }
        private ObservableCollection<AbsenceWrapper> _vacations;
        public ObservableCollection<AbsenceWrapper> Vacations
        {
            get { return _vacations; }
            set { SetProperty(ref _vacations, value); }
        }

        private EmployeeWrapper _employee;
        public EmployeeWrapper Employee
        {
            get { return _employee; }
            set { SetProperty(ref _employee, value); }
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
        public IEnumerable<AbsenceType> AbsenceTypes { get; set; }
        private AbsenceType _absenceType;
        public AbsenceType AbsenceType
        {
            get { return _absenceType; }
            set { SetProperty(ref _absenceType, value); }
        }
        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }
        private DelegateCommand _saveVacationCommnad;
        public DelegateCommand SaveVacationCommand =>
            _saveVacationCommnad ?? (_saveVacationCommnad = 
            new DelegateCommand(ExecuteSaveVacationCommand, CanExecuteSaveVacationCommand)
            .ObservesProperty(() => Employee)
            .ObservesProperty(() => Description));

        void ExecuteSaveVacationCommand()
        {
            var absence = new Absence
            {
                From = From,
                To = To,
                Employee = Employee.Model,
                Description = Description,
                AbsenceType = AbsenceType
            };
            var vacationWrapper = new AbsenceWrapper(absence);
            _dataService.AddAbsences(absence);
            Vacations.Add(vacationWrapper);
        }

        bool CanExecuteSaveVacationCommand()
            => Employee != null && !string.IsNullOrEmpty(Description);
    }
}
