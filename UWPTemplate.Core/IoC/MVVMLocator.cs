using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UWPTemplate.Core.ViewModel;

namespace UWPTemplate.Core.IoC
{
    public class MVVMLocator
    {
        private readonly IContainer _container;

        public MVVMLocator(IoCContainerBase container)
        {
            _container = container.BuildContainer();
        }

        public T ResolveViewModel<T>() where T : ViewModelBase
        {
            return _container.Resolve<T>();
        }
    }
}
