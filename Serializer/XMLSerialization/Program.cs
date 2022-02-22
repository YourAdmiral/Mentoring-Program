using System;
using System.IO;
using System.Xml.Serialization;

namespace XMLSerialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string employeeName = "Dave";

            const string departmentName = "Development department";

            const string xmlFile = "Department.xml";

            var employee = new Employee();

            var department = new Department();

            employee.Name = employeeName;

            department.Name = departmentName;

            department.Employees.Add(employee);

            var serializerXML = new SerializerXML(xmlFile);

            serializerXML.Serialize(department);

            var deserializedDepartment = serializerXML.Deserialize();
        }
    }
}
