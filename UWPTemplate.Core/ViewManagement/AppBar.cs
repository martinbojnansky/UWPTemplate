using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;
using Windows.UI.ViewManagement;

namespace UWPTemplate.Core.ViewManagement
{
    public interface IAppBar
    {
        void CustomizeDesktopAppBar(Action<ApplicationViewTitleBar> func);

        void CustomizeMobileAppBar(Action<StatusBar> func);
    }

    public class AppBar : IAppBar
    {
        #region Desktop & Tablet

        public void CustomizeDesktopAppBar(Action<ApplicationViewTitleBar> func)
        {
            if (ApiInformation.IsTypePresent(typeof(ApplicationView).FullName))
            {
                var titleBar = ApplicationView.GetForCurrentView()?.TitleBar;

                if(titleBar != null)
                {
                    func(titleBar);
                }
            }
        }

        #endregion

        #region Mobile 

        public void CustomizeMobileAppBar(Action<StatusBar> func)
        {
            if (ApiInformation.IsTypePresent(typeof(StatusBar).FullName))
            {
                var statusBar = StatusBar.GetForCurrentView();
                
                if(statusBar != null)
                {
                    func(statusBar);
                }
            }
        }

        public async Task ShowMobileAppBarAsync()
        {
            if (ApiInformation.IsTypePresent(typeof(StatusBar).FullName))
            {
                var statusBar = StatusBar.GetForCurrentView();
                await statusBar?.ShowAsync();
            }
        }

        public async Task HideMobileAppBarAsync()
        {
            if (ApiInformation.IsTypePresent(typeof(StatusBar).FullName))
            {
                var statusBar = StatusBar.GetForCurrentView();
                await statusBar?.HideAsync();
            }
        }

        public async Task ShowMobileProgressIndicatorAsync(string text = "")
        {
            if (ApiInformation.IsTypePresent(typeof(StatusBar).FullName))
            {
                var statusBar = StatusBar.GetForCurrentView();

                if (statusBar != null)
                {
                    StatusBarProgressIndicator progressIndicator = statusBar.ProgressIndicator;

                    if (!String.IsNullOrEmpty(text))
                    {
                        progressIndicator.Text = text;
                    }

                    await progressIndicator.ShowAsync();
                }
            }
        }

        public async Task HideMobileProgressIndicatorAsync()
        {
            if (ApiInformation.IsTypePresent(typeof(StatusBar).FullName))
            {
                var statusBar = StatusBar.GetForCurrentView();
                await statusBar?.ProgressIndicator.HideAsync();
            }
        }

        #endregion
    }
}
