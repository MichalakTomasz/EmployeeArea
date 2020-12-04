using EmployeesContext.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace EmployeesContext
{
    public class EmployeesContentModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("EmployeesContent", typeof(ViewEmployees));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}