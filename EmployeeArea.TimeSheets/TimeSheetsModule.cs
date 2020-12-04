using EmployeeArea.TimeSheets.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace EmployeeArea.TimeSheets
{
    public class TimeSheetsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("TimeSheetsContent", typeof(Views.ViewTimeSheets));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}