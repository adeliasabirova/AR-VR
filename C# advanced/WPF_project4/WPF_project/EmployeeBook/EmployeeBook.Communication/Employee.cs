using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBook.Communication.EmployeeBookService
{
    public partial class Employee : ICloneable
    {
        public Employee() { }

        public Employee(int employeeID, string firstName, string lastName, DepartmentCategory department, string jobName)
        {
            EmployeeID = employeeID;
            FirstName = firstName;
            LastName = lastName;
            Department = department;
            Job = jobName;
        }
        
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
