using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLSerialization
{
    [Serializable]
    public class Employee
    {
        [XmlElement("EmployeeName")]
        public string Name { get; set; }
    }
}
