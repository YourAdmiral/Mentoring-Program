using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BinarySerialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string employeeName = "Dave";

            const string departmentName = "Development department";

            const string binaryFile = "Department.save";

            var employee = new Employee();

            var department = new Department();

            employee.Name = employeeName;

            department.Name = departmentName;

            department.Employees.Add(employee);

            var serializerBinary = new SerializerBinary(binaryFile);

            serializerBinary.Serialize(department);

            var deserializedDepartment = serializerBinary.Deserialize();
        }
    }
}
