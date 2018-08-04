using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using UWPTemplate.Core.IoC;

namespace UWPTemplate.Core.Storage
{
    public interface IJsonSerializer
    {
        T FromJson<T>(string json);
        string ToJson<T>(T obj);
    }

    public class JsonSerializer : IJsonSerializer
    {
        protected virtual DataContractJsonSerializerSettings GetSerializerSettings()
        {
            return new DataContractJsonSerializerSettings
            {
                DateTimeFormat = new DateTimeFormat("yyyy-MM-ddTHH:mm:ss.FFFFFFF", CultureInfo.InvariantCulture)
            };
        }

        protected virtual DataContractJsonSerializer GetSerializer<T>()
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T), GetSerializerSettings());

            return serializer;
        }

        public virtual T FromJson<T>(string json)
        {
            var serializer = GetSerializer<T>();

            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                return (T)serializer.ReadObject(stream);
            }
        }

        public virtual string ToJson<T>(T obj)
        {
            var serializer = GetSerializer<T>();

            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, obj);
                var jsonArray = ms.ToArray();
                return Encoding.UTF8.GetString(jsonArray, 0, jsonArray.Length);
            }
        }
    }
}
