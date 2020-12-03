using EmployeeArea.Models;
using EmployeeArea.Services;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace EmployeeArea.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IDataService _dataService;

        public MainWindowViewModel(IDataService dataService)
        {
            _dataService = dataService;
            Employees = new ObservableCollection<Employee>(_dataService.GetEmployees());
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
        private ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Employees
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

            _dataService.AddEmploee(employee);
            Employees = new ObservableCollection<Employee>(_dataService.GetEmployees());

        }

        bool CanExecuteAddEmployeeCommand()
            => !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName);
    }
}
