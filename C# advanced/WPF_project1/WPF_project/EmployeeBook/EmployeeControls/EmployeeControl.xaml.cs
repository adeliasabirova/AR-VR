using EmployeeDepartmentData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmployeeControls
{
    /// <summary>
    /// Логика взаимодействия для EmployeeControl.xaml
    /// </summary>
    public partial class EmployeeControl : UserControl
    {
        //сущность контроллера сотрудника: 3 текстбокса и один комбобокс
        private Employee employee;
        public EmployeeControl()
        {
            InitializeComponent();
            cbDepartment.ItemsSource = Enum.GetValues(typeof(DepartmentCategory)).Cast<DepartmentCategory>();
        }

        //установка карточки сотрудника
        public void SetEmployee(Employee employee)
        {
            this.employee = employee;
            txtBoxName.Text = employee.Name.FirstName;
            txtBoxLast.Text = employee.Name.LastName;
            cbDepartment.SelectedItem = employee.Department;
            txtBoxJob.Text = employee.Job;
        }

        //обновление карточки сотрудника
        public void UpdateEmployee()
        {
            employee.Name = new EmployeeName(txtBoxName.Text, txtBoxLast.Text);
            employee.Department = (DepartmentCategory)cbDepartment.SelectedItem;
            employee.Job = txtBoxJob.Text;
        }

        //добавление сотрудника
        public Employee AddEmployee()
        {
            DepartmentCategory department = (DepartmentCategory)cbDepartment.SelectedItem;
            string job = txtBoxJob.Text;
            return new Employee(txtBoxName.Text, txtBoxLast.Text, department, job);
        }
    }
}
