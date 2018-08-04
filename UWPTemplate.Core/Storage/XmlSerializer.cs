using System.IO;
using System.Text;
using System.Xml.Serialization;
using UWPTemplate.Core.IoC;

namespace UWPTemplate.Core.Storage
{
    public interface IXmlSerializer
    {
        T FromXml<T>(string json);
        string ToXml<T>(T obj);
    }

    public class XmlSerializer : IXmlSerializer
    {
        protected virtual System.Xml.Serialization.XmlSerializer GetSerializer<T>()
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

            return serializer;
        }

        public virtual T FromXml<T>(string json)
        {
            var serializer = GetSerializer<T>();

            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                return (T)serializer.Deserialize(stream);
            }
        }

        public virtual string ToXml<T>(T obj)
        {
            var serializer = GetSerializer<T>();

            using (MemoryStream ms = new MemoryStream())
            {
                serializer.Serialize(ms, obj);
                var jsonArray = ms.ToArray();
                return Encoding.UTF8.GetString(jsonArray, 0, jsonArray.Length);
            }
        }
    }
}
