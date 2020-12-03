using EmployeeArea.Models;
using EmployeeArea.Services;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace EmploeeArea.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IDataService _dataService;

        public MainWindowViewModel(IDataService dataService)
        {
            _dataService = dataService;
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
    }
}
