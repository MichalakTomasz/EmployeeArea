using EmployeeArea.Services;
using EmployeeArea.Views;
using EmployeeArea.DataContext;
using Microsoft.EntityFrameworkCore;
using Prism.Ioc;
using System.Windows;

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
    }
}
