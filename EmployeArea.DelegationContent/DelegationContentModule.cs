using EmployeArea.DelegationContent.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace EmployeArea.DelegationContent
{
    public class DelegationContentModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("DelegationContent", typeof(ViewDelegationContent));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}