using System;

namespace JsonSerialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string employeeName = "Dave";

            string departmentName = "Development department";

            string jsonFile = "Department.json";

            Employee employee = new Employee();

            employee.Name = employeeName;

            Department department = new Department();

            department.Name = departmentName;

            department.Employees.Add(employee);

            SerializerJson serializerJson = new SerializerJson(jsonFile);

            serializerJson.Serialize(department);

            Department deserializedDepartment = serializerJson.Deserialize();
        }
    }
}
