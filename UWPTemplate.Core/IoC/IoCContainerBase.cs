using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UWPTemplate.Core.IoC
{
    public abstract class IoCContainerBase
    {
        private ContainerBuilder _builder;

        public IContainer BuildContainer()
        {
            _builder = new ContainerBuilder();

            OnBuildContainer();

            return _builder.Build();
        }

        public abstract void OnBuildContainer();

        public virtual void Register<T, TImpl>()
        {
            _builder.RegisterType<TImpl>().As<T>()
                .PropertiesAutowired();
        }

        public virtual void RegisterSingle<T, TImpl>()
        {
            _builder.RegisterType<TImpl>().As<T>()
                .SingleInstance()
                .PropertiesAutowired();
        }

        public virtual void AutoRegister<TBase>(Assembly assembly = null)
        {
            if(assembly == null)
            {
                assembly = typeof(TBase).GetTypeInfo().Assembly;
            }

            _builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.IsAssignableTo<TBase>())
                .PropertiesAutowired();
        }

        public virtual void AutoRegisterSingle<TBase>(Assembly assembly = null)
        {
            if (assembly == null)
            {
                assembly = typeof(TBase).GetTypeInfo().Assembly;
            }

            _builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.IsAssignableTo<TBase>())
                .SingleInstance()
                .PropertiesAutowired();
        }
    }
}
