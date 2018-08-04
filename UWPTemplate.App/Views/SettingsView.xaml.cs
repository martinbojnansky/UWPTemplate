using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UWPTemplate.Core.Navigation;
using UWPTemplate.App.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace UWPTemplate.App.Views
{
    public sealed partial class SettingsView : NavigationPage, INavigationPage<SettingsViewModel>
    {
        public SettingsViewModel ViewModel { get; set; } = ((App)Application.Current).MvvmLocator.ResolveViewModel<SettingsViewModel>();

        public SettingsView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }
    }
}
