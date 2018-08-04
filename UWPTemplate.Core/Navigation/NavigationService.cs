using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWPTemplate.Core.Navigation
{
    public interface INavigationService
    {
        Frame Frame { get; }

        object[] Parameters { get; set; }

        void GoTo(Type sourcePageType, params object[] parameter);

        void GoBack();
    }

    public class NavigationService : INavigationService
    {
        public Frame Frame => (Frame)Window.Current.Content;

        public object[] Parameters { get; set; }

        public virtual void GoTo(Type sourcePageType, params object[] parameters)
        {
            Frame?.Navigate(sourcePageType, parameters);
        }

        public virtual void GoBack()
        {
            if (Frame?.CanGoBack == true)
            {
                Frame.GoBack();
            }
        }
    }
}
