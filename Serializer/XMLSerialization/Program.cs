using System;
using System.IO;
using System.Xml.Serialization;

namespace XMLSerialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string employeeName = "Dave";

            string departmentName = "Development department";

            string xmlFile = "Department.xml";

            Employee employee = new Employee();

            employee.Name = employeeName;

            Department department = new Department();
            
            department.Name = departmentName;

            department.Employees.Add(employee);

            SerializerXML serializerXML = new SerializerXML(xmlFile);

            serializerXML.Serialize(department);

            Department deserializedDepartment = serializerXML.Deserialize();
        }
    }
}
