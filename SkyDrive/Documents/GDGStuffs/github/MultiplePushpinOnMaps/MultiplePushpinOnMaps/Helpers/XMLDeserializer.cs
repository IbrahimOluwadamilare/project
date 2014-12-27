using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using System.Xml.Serialization;



namespace MultiplePushpinOnMaps.Model.Helpers
{
    public static class XMLDeserializer
    {
        public static T Deserialize<T>(string xml)
        {
            try
            {
                using (var stream = new MemoryStream(Encoding.Unicode.GetBytes(xml)))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    XDocument document = XDocument.Parse(xml);
                    T theObject = (T)serializer.Deserialize(document.CreateReader());
                    return theObject;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
