using EmployeeDepartmentData;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace EmployeeBook.WebEntry
{
    /// <summary>
    /// Сводное описание для EmployeebookService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class EmployeebookService : System.Web.Services.WebService
    {
        private string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["EmployeeBookConnectionString"].ConnectionString;

        //[WebMethod]
        //public string HelloWorld()
        //{
        //    return "Привет всем!";
        //}

        [WebMethod]
        public List<Employee> Load()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string sqlExpression = $@"SELECT * FROM Employees";
                var command = new SqlCommand(sqlExpression, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var employee = new Employee(reader.GetInt32(0), reader["FirstName"].ToString(), reader["LastName"].ToString(), (DepartmentCategory)reader.GetInt32(4), reader["Job"].ToString());
                            employees.Add(employee);
                        }
                    }
                    return employees;
                }
            }
        }

        [WebMethod]
        public int Update(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string sqlExpression = $@"UPDATE Employees 
                    SET FirstName = '{employee.FirstName}', 
                    LastName = '{employee.LastName}', 
                    Job = '{employee.Job}', 
                    DepartamentID = {(int)employee.Department}
                    WHERE EmployeeID = {employee.EmployeeID}";
                var command = new SqlCommand(sqlExpression, connection);
                return command.ExecuteNonQuery();
            }
        }

        //удаление данных всей базы
        public void DeleteAll()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string sqlExpression = $@"DELETE FROM Employees";
                var command = new SqlCommand(sqlExpression, connection);
                var res = command.ExecuteNonQuery();
            }
        }

        [WebMethod]
        public int Delete(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string sqlExpression = $@"DELETE FROM Employees WHERE EmployeeID = {employee.EmployeeID}";
                var command = new SqlCommand(sqlExpression, connection);
                return command.ExecuteNonQuery();
            }
        }

        [WebMethod]
        public int Add(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string sqlExpression = $@"INSERT INTO Employees (EmployeeID, FirstName, LastName, Job, DepartamentID)
                    VALUES ({employee.EmployeeID}, '{employee.FirstName}', '{employee.LastName}', '{employee.Job}', {(int)employee.Department})";
                var command = new SqlCommand(sqlExpression, connection);
                return command.ExecuteNonQuery();
                
            }
        }
    }
}
