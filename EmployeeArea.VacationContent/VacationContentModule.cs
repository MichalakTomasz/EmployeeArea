using EmployeeArea.VacationContent.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace EmployeeArea.VacationContent
{
    public class VacationContentModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("VacationContent", typeof(ViewVacationContent));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}