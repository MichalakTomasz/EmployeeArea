using EmployeeArea.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System.Windows.Controls;

namespace EmployeeArea.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;

        public MainWindowViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        private DelegateCommand<SelectionChangedEventArgs> _tabChangedEvent;
        public DelegateCommand<SelectionChangedEventArgs> TabChangedEvent =>
            _tabChangedEvent ?? (_tabChangedEvent = new DelegateCommand<SelectionChangedEventArgs>(ExecuteTabChangedEvent));

        void ExecuteTabChangedEvent(SelectionChangedEventArgs e)
        {
            var tabControl = e.OriginalSource as TabControl;
            var tabName = (tabControl.SelectedItem as TabItem).Header.ToString();
            _eventAggregator.GetEvent<ChangeTabEvent>().Publish(tabName);
        }
            
    }
}
