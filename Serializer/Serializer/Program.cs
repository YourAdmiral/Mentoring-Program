using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BinarySerialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string employeeName = "Dave";

            string departmentName = "Development department";

            string binaryFile = "Department.save";

            Employee employee = new Employee();

            employee.Name = employeeName;

            Department department = new Department();

            department.Name = departmentName;

            department.Employees.Add(employee);

            SerializerBinary serializerBinary = new SerializerBinary(binaryFile);

            serializerBinary.Serialize(department);

            Department deserializedDepartment = serializerBinary.Deserialize();
        }
    }
}
