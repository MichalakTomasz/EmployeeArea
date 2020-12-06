using EmployeeArea.Services;
using EmployeeArea.Views;
using EmployeeArea.DataContext;
using Microsoft.EntityFrameworkCore;
using Prism.Ioc;
using System.Windows;
using Prism.Modularity;
using EmployeeArea.TimeSheets;
using EmployeesContext;
using System.Windows.Navigation;
using System.Linq;
using EmployeeArea.Models;
using System.Collections.Generic;
using EmployeeArea.VacationContent;
using EmployeArea.DelegationContent;

namespace EmployeeArea
{
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var contextOptions = GetDbcontextOptions();
            containerRegistry.RegisterInstance(new EmployeeAreaDbContext(contextOptions));
            containerRegistry.Register<IDataService, DataService>();
        }

        private DbContextOptions<EmployeeAreaDbContext> GetDbcontextOptions()
        {
            var connectionString = @"Data Source=D:\Repos\EmployeeArea\EmployeeAreaDb.db";
            var dbContextBuilder = new DbContextOptionsBuilder<EmployeeAreaDbContext>();
            dbContextBuilder.UseSqlite(connectionString);
            dbContextBuilder.EnableSensitiveDataLogging(true);
            return dbContextBuilder.Options;
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<TimeSheetsModule>();
            moduleCatalog.AddModule<EmployeesContentModule>();
            moduleCatalog.AddModule<VacationContentModule>();
            moduleCatalog.AddModule<DelegationContentModule>();
        }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            var context = Container.Resolve<EmployeeAreaDbContext>();
            if (!context.AbsenceTypes.Any())
            {
                var absenceTypes = new List<AbsenceType>
                {
                    new AbsenceType { Name = "Nieobecność" },
                    new AbsenceType {Name = "Urlop"}
                };
                context.AddRange(absenceTypes);
                context.SaveChanges();
            }
        }
    }
}
