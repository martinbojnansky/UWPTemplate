using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPTemplate.Core.IoC;
using UWPTemplate.Core.Localization;
using UWPTemplate.Core.Navigation;
using UWPTemplate.Core.Storage;
using UWPTemplate.App.ViewModels;
using UWPTemplate.Core.ViewManagement;

namespace UWPTemplate.App.IoC
{
    public class IoCContainer : IoCContainerBase
    {
        public override void OnBuildContainer()
        {
            Register<INavigationService, NavigationService>();
            Register<ILocalizedResources, LocalizedResources>();
            Register<ILocalObjectStorage, LocalObjectStorage>();
            Register<IRoamingObjectStorage, RoamingObjectStorage>();
            Register<IJsonSerializer, JsonSerializer>();
            Register<IXmlSerializer, XmlSerializer>();
            Register<IAppBar, AppBar>();

            AutoRegister<ViewModelBase>();
        }
    }
}
