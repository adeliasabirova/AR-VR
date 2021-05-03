using EmployeeDepartmentData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBook
{
    public class Database
    {
        //private static string[] DEPARTMENT_NAMES = { "Department1", "Department2", "Department3", "Department4", "Department5" };
        private static string[] JOB_TITLES = { "Junior Manager", "Middle Manager", "Senior Manager", "Head of Department" };
        private static int CHAR_BOUND_LOW = 65;
        private static int CHAR_BOUND_HIGH = 90;

        private Random random = new Random();

        //инициализация базы данных
        public Database()
        {
            Employees = new List<Employee>();
            GenerateEmployees(35);
            Departments = new List<Department>();
            RegenerateDepartments();
        }

        //список карточек сотрудников
        public List<Employee> Employees { get; set; }
        //тот же самый список сотрудников только по департаментам
        public List<Department> Departments { get; set; }

        //метод создания символов для имен и фамилий
        private string GenerateSymbols(int amount)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for(int i=0; i<amount; i++)
            {
                stringBuilder.Append((char)(CHAR_BOUND_LOW + random.Next(CHAR_BOUND_HIGH - CHAR_BOUND_LOW)));
            }
            return stringBuilder.ToString();
        }

        //создание сотрудников
        private void GenerateEmployees(int employeesCount)
        {
            Employees.Clear();
            for (int i = 0; i < employeesCount; i++)
            {
                string firstName = GenerateSymbols(random.Next(6) + 5);
                string lastName = GenerateSymbols(random.Next(6) + 5);
                var department = (DepartmentCategory)random.Next(0, 5);
                string job = JOB_TITLES[random.Next(0, 4)];
                //если руквдитель отдела уже есть в отделе, то создать сотрудика с другой должностью (странно если руководителей в одном отделе будет несколько)
                if (Employees.FindAll(e => e.Job == "Head of Department" && e.Department == department).Count > 0)
                    job = JOB_TITLES[random.Next(0, 3)];

                Employees.Add(new Employee(firstName, lastName, department, job));
            }
        }

        // перевод сотрудников из списка Employess в список по департиментам
        public void RegenerateDepartments()
        {
            Departments.Clear();
            for (int i=0; i < Enum.GetValues(typeof(DepartmentCategory)).Length; i++)
            {
                var employees = Employees.Where(x => x.Department == Enum.GetValues(typeof(DepartmentCategory)).Cast<DepartmentCategory>().ToList()[i]).ToList();
                List<EmployeeName> employeeNames = new List<EmployeeName>();
                foreach (var employee in employees)
                    employeeNames.Add(employee.Name);
                Departments.Add(new Department(Enum.GetValues(typeof(DepartmentCategory)).Cast<DepartmentCategory>().ToList()[i], employeeNames));
            }
        }

    }
}
