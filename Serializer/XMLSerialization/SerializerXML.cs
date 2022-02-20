using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLSerialization
{
    public class SerializerXML
    {
        private string _xmlFile;

        public SerializerXML(string fileName)
        {
            _xmlFile = fileName;
        }

        public void Serialize(Department department)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Department));

            using (FileStream fs = new FileStream(_xmlFile, FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, department);
            }
        }

        public Department Deserialize()
        {
            XmlSerializer xml = new XmlSerializer(typeof(Department));

            using (FileStream fs = new FileStream(_xmlFile, FileMode.OpenOrCreate))
            {
                return (Department) xml.Deserialize(fs);
            }
        }
    }
}
