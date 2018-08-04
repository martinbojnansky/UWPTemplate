using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace UWPTemplate.Core.Storage
{
    public interface IRoamingObjectStorage : IObjectStorageBase { }

    public class RoamingObjectStorage : ObjectStorageBase, IRoamingObjectStorage
    {
        public override ApplicationDataContainer ApplicationDataContainer => ApplicationData.Current.RoamingSettings;

        public override StorageFolder StorageFolder => ApplicationData.Current.RoamingFolder;
    }
}
