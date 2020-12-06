using EmployeeArea.Models;
using EmployeeArea.DataContext;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
            => _context.Employees.ToList();

        public void AddEmploee(Employee employee)
        {
            _context.Add(employee);
            _context.SaveChanges();
        }
        public IEnumerable<JobRegistration> GetJobRegistrations()
            => _context.JobRegistrations.Include(j => j.Emploee).ToList();

        public void AddJobRegistration(JobRegistration jobRegistration)
        {
            _context.Attach(jobRegistration);
            _context.SaveChanges();
        }

        public IEnumerable<Delegation> GetDelegations()
            => _context.Delegations.Include(d => d.Employee).ToList();

        public void AddDelegation(Delegation delegation)
        {
            _context.Attach(delegation);
            _context.SaveChanges();
        }

        public IEnumerable<AbsenceType> GetAbsenceTypes()
            => _context.AbsenceTypes.ToList();

        public void AddAbsenceType(AbsenceType absenceType)
        {
            _context.Add(absenceType);
            _context.SaveChanges();
        }

        public IEnumerable<Absence> GetAbsences()
            => _context.Absences.Include(a => a.Employee)
            .Include(a => a.AbsenceType).ToList();

        public void AddAbsences(Absence absence)
        {
            _context.Attach(absence);
            _context.SaveChanges();
        }
    }
}
