using Prism.Mvvm;
using System;

namespace EmployeeArea.Models
{
    public class JobRegistrationWrapper : BindableBase
    {
        public JobRegistrationWrapper(JobRegistration jobRegistration)
        {
            Model = jobRegistration;
            Employee = jobRegistration.Emploee;
        }
        public JobRegistration Model { get; set; }

        private Guid _id;
        public Guid Id
        {
            get => Model.Id;
            set { SetProperty(ref _id, value, () => Model.Id = value); }
        }
        private DateTime _jobStart;
        public DateTime JobStart
        {
            get => Model.JobStart;
            set { SetProperty(ref _jobStart, value, () => Model.JobStart = value); }
        }
        private DateTime _jobEnd;
        public DateTime JobEnd
        {
            get => Model.JobEnd;
            set { SetProperty(ref _jobEnd, value, () => Model.JobEnd = value); }
        }
        public Employee Employee { get; set; }
    }
}
