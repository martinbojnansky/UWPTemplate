using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPTemplate.Core.ViewModel;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System.Reflection;

namespace UWPTemplate.Core.Navigation
{
    public class NavigationPage : Page
    {
        private readonly SystemNavigationManager _systemNavigationManager;
        private readonly ViewModelBase _viewModel;

        public NavigationPage() : base()
        {
            _systemNavigationManager = SystemNavigationManager.GetForCurrentView();
            _viewModel = GetType()?.GetProperty(nameof(INavigationPage<ViewModelBase>.ViewModel))?.GetValue(this) as ViewModelBase;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _viewModel?.OnNavigatedTo(e);

            _systemNavigationManager.BackRequested += SystemNavigationManager_BackRequested;
            _systemNavigationManager.AppViewBackButtonVisibility =
                (Frame != null && Frame.CanGoBack) ?
                AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;

            base.OnNavigatedTo(e);

        }

        private void SystemNavigationManager_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack && e.Handled == false)
            {
                e.Handled = true;
                Frame.GoBack();
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _viewModel?.OnNavigatedFrom(e);

            base.OnNavigatedFrom(e);
        }
    }
}
