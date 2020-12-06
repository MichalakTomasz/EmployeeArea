using EmployeeArea.Models;
using EmployeeArea.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace EmployeeArea.TimeSheets.ViewModels
{
    public class ViewTimeSheetsViewModel : BindableBase
    {
        private readonly IDataService _dataService;

        public ViewTimeSheetsViewModel(IDataService dataService)
        {
            _dataService = dataService;
            var timeSheets = _dataService.GetJobRegistrations().Select(s => new JobRegistrationWrapper(s)).ToList();
            TimeSheets = new ObservableCollection<JobRegistrationWrapper>(timeSheets);
            var employees = _dataService.GetEmployees().Select(s => new EmployeeWrapper(s)).ToList();
            Employees = new ObservableCollection<EmployeeWrapper>(employees);
        }
        private ObservableCollection<EmployeeWrapper> _employees;
        public ObservableCollection<EmployeeWrapper> Employees
        {
            get { return _employees; }
            set { SetProperty(ref _employees, value); }
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
        private JobRegistration _job;
        public JobRegistration Job
        {
            get { return _job; }
            set { SetProperty(ref _job, value); }
        }
        private EmployeeWrapper _employee;
        public EmployeeWrapper Employee
        {
            get { return _employee; }
            set { SetProperty(ref _employee, value); }
        }
        private string _timeSheet;
        public string TimeSheet
        {
            get { return _timeSheet; }
            set { SetProperty(ref _timeSheet, value); }
        }
        private ObservableCollection<JobRegistrationWrapper> _timeSheets;
        public ObservableCollection<JobRegistrationWrapper> TimeSheets
        {
            get { return _timeSheets; }
            set { SetProperty(ref _timeSheets, value); }
        }
        private DelegateCommand _fromCommand;
        public DelegateCommand FromCommand =>
            _fromCommand ?? (_fromCommand = 
            new DelegateCommand(ExecuteFromCommand, CanExecuteFromCommand)
            .ObservesProperty(() => Job)
            .ObservesProperty(() => Employee));

        void ExecuteFromCommand()
        {
            Job = new JobRegistration
            {
                Emploee = Employee.Model,
                JobStart = DateTime.Now
            };
            TimeSheet = $"{Job.Emploee.FirstName} - {Job.Emploee.LastName} od: {Job.JobStart}";
        }

        bool CanExecuteFromCommand()
            => Job == null && Employee != null;

        private DelegateCommand _toCommand;
        public DelegateCommand ToCommand =>
            _toCommand ?? (_toCommand = 
            new DelegateCommand(ExecuteToCommand, CanExecuteToCommand)
            .ObservesProperty(() => Job));

        void ExecuteToCommand()
        {
            Job.JobEnd = DateTime.Now;
            _dataService.AddJobRegistration(Job);
            var jobWrapper = new JobRegistrationWrapper(Job);
            TimeSheets.Add(jobWrapper);
            TimeSheet = $"{Job.Emploee.FirstName} - {Job.Emploee.LastName} od: {Job.JobStart} do: {Job.JobEnd}";
            Job = null;
        }

        bool CanExecuteToCommand()
            => Job != null;
    }
}
