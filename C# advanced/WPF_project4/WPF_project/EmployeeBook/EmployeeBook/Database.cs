using EmployeeBook.Communication.EmployeeBookService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBook
{
    public class Database
    {
        private EmployeebookServiceSoapClient employeebookServiceSoapClient = new EmployeebookServiceSoapClient();
        //public const string ConnectionString = "Data Source=localhost;Initial Catalog=EmployeeBook;User ID=EmployeeDatabaseRoot;Password=12345";
        //private static string[] DEPARTMENT_NAMES = { "Department1", "Department2", "Department3", "Department4", "Department5" };
        private static string[] JOB_TITLES = { "Junior Manager", "Middle Manager", "Senior Manager", "Head of Department" };
        private static int CHAR_BOUND_LOW = 65;
        private static int CHAR_BOUND_HIGH = 90;

        private Random random = new Random();

        //инициализация базы данных
        public Database()
        {
            Employees = new ObservableCollection<Employee>();
            //DeleteAll();
            LoadDatabase();
            //GenerateEmployees(40);
            //SyncToDatabase();


            //Departments = new List<Department>();
            //RegenerateDepartments();

        }

        //public void SyncToDatabase()
        //{
        //    //using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    //{
        //    //    connection.Open();
        //    //}

        //    foreach (var employee in Employees)
        //        Add(employee);
        //}

        //загрузка базы
        public void LoadDatabase()
        {
            foreach (var employee in employeebookServiceSoapClient.Load())
                Employees.Add(employee);

            //using (SqlConnection connection = new SqlConnection(ConnectionString))
            //{
            //    connection.Open();
            //    string sqlExpression = $@"SELECT * FROM Employees";
            //    var command = new SqlCommand(sqlExpression, connection);
            //    using(SqlDataReader reader = command.ExecuteReader())
            //    {
            //        if (reader.HasRows)
            //        {
            //            while (reader.Read())
            //            {
            //                var employee = new Employee(reader.GetInt32(0), reader["FirstName"].ToString(), reader["LastName"].ToString(), (DepartmentCategory)reader.GetInt32(4), reader["Job"].ToString());
            //                Employees.Add(employee);
            //            }
            //        }
            //    }
            //}
        }

        //обновление элемента базы
        public int Update(Employee employee)
        {
            return employeebookServiceSoapClient.Update(employee);
            //using (SqlConnection connection = new SqlConnection(ConnectionString))
            //{
            //    connection.Open();
            //    string sqlExpression = $@"UPDATE Employees 
            //        SET FirstName = '{employee.FirstName}', 
            //        LastName = '{employee.LastName}', 
            //        Job = '{employee.Job}', 
            //        DepartamentID = {(int)employee.Department}
            //        WHERE EmployeeID = {employee.EmployeeID}";
            //    var command = new SqlCommand(sqlExpression, connection);
            //    return command.ExecuteNonQuery();
            //}
        }

        ////удаление данных всей базы
        //public void DeleteAll()
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        connection.Open();
        //        string sqlExpression = $@"DELETE FROM Employees";
        //        var command = new SqlCommand(sqlExpression, connection);
        //        var res = command.ExecuteNonQuery();
        //    }
        //}

        //удаление элемента из базы
        public int Delete(Employee employee)
        {
            var res = employeebookServiceSoapClient.Delete(employee);
            if (res > 0)
                Employees.Remove(employee);
            return res;

            //using (SqlConnection connection = new SqlConnection(ConnectionString))
            //{
            //    connection.Open();
            //    string sqlExpression = $@"DELETE FROM Employees WHERE EmployeeID = {employee.EmployeeID}";
            //    var command = new SqlCommand(sqlExpression, connection);
            //    var res = command.ExecuteNonQuery();
            //    if (res > 0)
            //    {
            //        Employees.Remove(employee);
            //    }
            //    return res;
            //}
        }

        //добавление элемента в базу
        public int Add(Employee employee)
        {
            var res = employeebookServiceSoapClient.Add(employee);
            if (res > 0)
            {
                Employees.Add(employee);
            }
            return res;

            //using (SqlConnection connection = new SqlConnection(ConnectionString))
            //{
            //    connection.Open();
            //    string sqlExpression = $@"INSERT INTO Employees (EmployeeID, FirstName, LastName, Job, DepartamentID)
            //        VALUES ({employee.EmployeeID}, '{employee.FirstName}', '{employee.LastName}', '{employee.Job}', {(int)employee.Department})";
            //    var command = new SqlCommand(sqlExpression, connection);
            //    var res = command.ExecuteNonQuery();
            //    if (res > 0)
            //    {
            //        Employees.Add(employee);
            //    }
            //    return res;
            //}
        }

        //список карточек сотрудников
        public ObservableCollection<Employee> Employees { get; set; }

        //тот же самый список сотрудников только по департаментам
        //public List<Department> Departments { get; set; }

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
                if (Employees.Where(e => e.Job == "Head of Department" && e.Department == department).ToList().Count > 0)
                    job = JOB_TITLES[random.Next(0, 3)];

                Employees.Add(new Employee(i, firstName, lastName, department, job));
            }
        }

        // перевод сотрудников из списка Employess в список по департиментам
        //public void RegenerateDepartments()
        //{
        //    Departments.Clear();
        //    for (int i=0; i < Enum.GetValues(typeof(DepartmentCategory)).Length; i++)
        //    {
        //        var employees = Employees.Where(x => x.Department == Enum.GetValues(typeof(DepartmentCategory)).Cast<DepartmentCategory>().ToList()[i]).ToList();
        //        List<EmployeeName> employeeNames = new List<EmployeeName>();
        //        foreach (var employee in employees)
        //            employeeNames.Add(employee.Name);
        //        Departments.Add(new Department(Enum.GetValues(typeof(DepartmentCategory)).Cast<DepartmentCategory>().ToList()[i], employeeNames));
        //    }
        //}

    }
}
