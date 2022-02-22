using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace DeepCloningSerialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string employeeName = "Nate";

            const string departmentName = "Development department";

            var employee = new Employee();

            var department = new Department();

            employee.Name = employeeName;

            department.Name = departmentName;

            department.Employees.Add(employee);

            var clone = department.DeepClone();
        }
    }
}
