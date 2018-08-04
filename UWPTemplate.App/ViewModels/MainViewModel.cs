using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPTemplate.App.Views;

namespace UWPTemplate.App.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public void NavigateToSettingsPage()
        {
            Navigation.GoTo(typeof(SettingsView), "This is navigation parameter");
        }
    }
}
