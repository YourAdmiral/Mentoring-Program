using System;

namespace JsonSerialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string employeeName = "Dave";

            const string departmentName = "Development department";

            const string jsonFile = "Department.json";

            var employee = new Employee();

            var department = new Department();

            employee.Name = employeeName;

            department.Name = departmentName;

            department.Employees.Add(employee);

            var serializerJson = new SerializerJson(jsonFile);

            serializerJson.Serialize(department);

            var deserializedDepartment = serializerJson.Deserialize();
        }
    }
}
