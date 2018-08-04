using System;
using System.Collections.Generic;
using Windows.Foundation.Collections;
using Windows.Storage;

namespace UWPTemplate.Core.Storage
{
    public interface IObjectStorageBase
    {
        ApplicationDataContainer ApplicationDataContainer { get; }

        StorageFolder StorageFolder { get; }

        ApplicationDataContainer GetOrCreateContainer(string containerKey = "");

        void DeleteContainer(string containerKey);

        T GetValue<T>(string key, string containerKey = "");

        IPropertySet GetValues(string containerKey = "");

        void SetValue<T>(string key, T value, string containerKey = "");

        void RemoveKey(string key, string containerKey = "");
    }

    public abstract class ObjectStorageBase : IObjectStorageBase
    {
        public abstract ApplicationDataContainer ApplicationDataContainer { get; }

        public abstract StorageFolder StorageFolder { get; }

        public virtual ApplicationDataContainer GetOrCreateContainer(string containerKey = "")
        {
            if (!string.IsNullOrEmpty(containerKey))
            {
                return ApplicationDataContainer.CreateContainer(containerKey, ApplicationDataCreateDisposition.Always);
            }
            else
            {
                return ApplicationDataContainer;
            }
        }

        public virtual void DeleteContainer(string containerKey)
        {
            if (ApplicationDataContainer.Containers.ContainsKey(containerKey))
            {
                ApplicationDataContainer.DeleteContainer(containerKey);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public virtual T GetValue<T>(string key, string containerKey = "")
        {
            var applicationDataContainer = GetOrCreateContainer(containerKey);

            if (applicationDataContainer.Values.ContainsKey(key))
            {
                return (T)applicationDataContainer.Values[key];
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public virtual IPropertySet GetValues(string containerKey = "")
        {
            if (!string.IsNullOrEmpty(containerKey))
            {
                return ApplicationDataContainer.CreateContainer(containerKey, ApplicationDataCreateDisposition.Always).Values;
            }
            else
            {
                return ApplicationDataContainer.Values;
            }
        }

        public virtual void SetValue<T>(string key, T value, string containerKey = "")
        {
            var applicationDataContainer = GetOrCreateContainer(containerKey);

            if (applicationDataContainer.Values.ContainsKey(key))
            {
                applicationDataContainer.Values[key] = value;
            }
            else
            {
                applicationDataContainer.Values.Add(key, value);
            }
        }

        public virtual void RemoveKey(string key, string containerKey = "")
        {
            var applicationDataContainer = GetOrCreateContainer(containerKey);

            if (applicationDataContainer.Values.ContainsKey(key))
            {
                applicationDataContainer.Values.Remove(key);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
    }
}
