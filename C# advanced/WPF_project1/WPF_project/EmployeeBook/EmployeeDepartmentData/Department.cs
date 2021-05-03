using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDepartmentData
{
    //сущность отделов: название отдела и список сотрудников
    public class Department
    {
        public Department(DepartmentCategory departmentName, List<EmployeeName> employeeList)
        {
            DepartmentName = departmentName;
            EmployeeList = employeeList;
        }

        public DepartmentCategory DepartmentName { get; set; }
        public List<EmployeeName> EmployeeList { get; set; }

        public override string ToString()
        {
            return $"{DepartmentName}";
        }
    }
}
