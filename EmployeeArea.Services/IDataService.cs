using EmployeeArea.Models;
using System.Collections.Generic;

namespace EmployeeArea.Services
{
    public interface IDataService
    {
        void AddAbsences(Absence absence);
        void AddAbsenceType(AbsenceType absenceType);
        void AddDelegation(Delegation delegation);
        void AddEmploee(Employee emploee);
        void AddJobRegistration(JobRegistration jobRegistration);
        IEnumerable<Absence> GetAbsences();
        IEnumerable<AbsenceType> GetAbsenceTypes();
        IEnumerable<Delegation> GetDelegations();
        IEnumerable<Employee> GetEmployees();
        IEnumerable<JobRegistration> GetJobRegistrations();
    }
}