using EmployeeArea.Models;
using EmployeeArea.Services;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Linq;

namespace EmployeesContext.ViewModels
{
    public class ViewEmployeesViewModel : BindableBase
    {
        private readonly IDataService _dataService;

        public ViewEmployeesViewModel(IDataService dataService)
        {
            _dataService = dataService;
            var employees = _dataService.GetEmployees().Select(s => new EmployeeWrapper(s));
            Employees = new ObservableCollection<EmployeeWrapper>(employees);
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }
        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }
        private ObservableCollection<EmployeeWrapper> _employees;
        public ObservableCollection<EmployeeWrapper> Employees
        {
            get { return _employees; }
            set { SetProperty(ref _employees, value); }
        }

        private DelegateCommand _addEmployeCommand;
        public DelegateCommand AddEmployeeCommand =>
            _addEmployeCommand ?? (_addEmployeCommand =
            new DelegateCommand(ExecuteAddEmployeeCommand, CanExecuteAddEmployeeCommand)
            .ObservesProperty(() => FirstName)
            .ObservesProperty(() => LastName));

        void ExecuteAddEmployeeCommand()
        {
            var employee = new Employee
            {
                FirstName = FirstName,
                LastName = LastName
            };
            var employeeWrapper = new EmployeeWrapper(employee);
            Employees.Add(employeeWrapper);

            _dataService.AddEmploee(employeeWrapper.Model);
        }

        bool CanExecuteAddEmployeeCommand()
            => !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName);
    }
}
