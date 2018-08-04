using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace UWPTemplate.Core.Storage
{
    public interface ILocalObjectStorage : IObjectStorageBase { }

    public class LocalObjectStorage : ObjectStorageBase, ILocalObjectStorage
    {
        public override ApplicationDataContainer ApplicationDataContainer => ApplicationData.Current.LocalSettings;

        public override StorageFolder StorageFolder => ApplicationData.Current.LocalFolder;
    }
}
