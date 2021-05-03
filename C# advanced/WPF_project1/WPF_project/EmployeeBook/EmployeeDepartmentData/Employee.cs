using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDepartmentData
{
    //сущность сотрудников: имя, фамилия, отдел, должность
    public struct EmployeeName
    {
        private string firstName;
        private string lastName;

        public EmployeeName(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string FirstName => firstName;
        public string LastName => lastName;

        public override string ToString()
        {
            return $"{firstName} {lastName}";
        }
    }

    public class Employee
    {
        public Employee(string firstName, string lastName, DepartmentCategory department, string jobName)
        {
            Name = new EmployeeName(firstName, lastName);
            Department = department;
            Job = jobName;
        }

        public EmployeeName Name { get; set; }
        public DepartmentCategory Department { get; set; }
        public string Job { get; set; }

        public override string ToString()
        {
            return $"name: {Name.ToString()}, department: {Department}, job title: {Job}";
        }
    }
}
