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
            string employeeName = "Nate";

            string departmentName = "Development department";

            string jsonFile = "Department.myData";

            Employee employee = new Employee();

            employee.Name = employeeName;

            Department department = new Department();

            department.Name = departmentName;

            department.Employees.Add(employee);

            Department clone = department.DeepClone();
        }
    }
}
