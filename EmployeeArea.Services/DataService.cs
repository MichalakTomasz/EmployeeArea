using EmployeeArea.Models;
using EmployeeArea.DataContext;
using System.Collections.Generic;

namespace EmployeeArea.Services
{
    public class DataService : IDataService
    {
        private readonly EmployeeAreaDbContext _context;

        public DataService(EmployeeAreaDbContext emploeeAreaDbContext)
        {
            _context = emploeeAreaDbContext;
        }
        public IEnumerable<Employee> GetEmployees()
            => _context.Employees;

        public void AddEmploee(Employee employee)
        {
            _context.Add(employee);
            _context.SaveChanges();
        }
        public IEnumerable<JobRegistration> GetJobRegistrations()
            => _context.JobRegistrations;

        public void AddJobRegistration(JobRegistration jobRegistration)
        {
            _context.Add(jobRegistration);
            _context.SaveChanges();
        }

        public IEnumerable<Delegation> GetDelegations()
            => _context.Delegations;

        public void AddDelegation(Delegation delegation)
        {
            _context.Add(delegation);
            _context.SaveChanges();
        }

        public IEnumerable<AbsenceType> GetAbsenceTypes()
            => _context.AbsenceTypes;

        public void AddAbsenceType(AbsenceType absenceType)
        {
            _context.Add(absenceType);
            _context.SaveChanges();
        }

        public IEnumerable<Absence> GetAbsences()
            => _context.Absences;

        public void AddAbsences(Absence absence)
        {
            _context.Add(absence);
            _context.SaveChanges();
        }
    }
}
