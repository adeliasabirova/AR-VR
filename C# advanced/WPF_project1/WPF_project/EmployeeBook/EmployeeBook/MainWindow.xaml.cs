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

namespace EmployeeBook
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //инициализация баззы данных
        private Database database = new Database();

        //инициализация окна
        public MainWindow()
        {
            InitializeComponent();
            foreach (var department in database.Departments)
                departmentCB.Items.Add(department.DepartmentName);
        }

        //при выборе отдела в листвью выводится список сотрудников, работающих в этом отделе
        private void departmentCB_DropDownClosed(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            var index = database.Departments.FindIndex(d => d.DepartmentName == (DepartmentCategory)comboBox.SelectedItem);
            departmentLV.ItemsSource = database.Departments[index].EmployeeList;
        }

        //при выборе сотрудника из отдела выходит карточка сотрудника с именем, фамилией, отделом и должностью
        private void departmentLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.AddedItems.Count > 0)
            {
                EmployeeName employeeName = (EmployeeName)e.AddedItems[0];
                Employee employee = database.Employees.Find(x => x.Name.FirstName == employeeName.FirstName && x.Name.LastName == employeeName.LastName);
                EmployeeControl.SetEmployee(employee);
            }
        }

        //внесение изменений в карточку сотрудника
        private void bttnAccept_Click(object sender, RoutedEventArgs e)
        {
            if (departmentLV.SelectedItems.Count < 1)
                return;

            EmployeeControl.UpdateEmployee();
            database.RegenerateDepartments();
            UpdateBinding();
        }

        //обновление листвью
        private void UpdateBinding()
        {
            departmentLV.ItemsSource = null;
            var index = database.Departments.FindIndex(d => d.DepartmentName == (DepartmentCategory)departmentCB.SelectedItem);
            departmentLV.ItemsSource = database.Departments[index].EmployeeList;
        }

        //удаление сотрудника
        private void bttnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (departmentLV.SelectedItems.Count < 1)
                return;

            if (MessageBox.Show("Вы дйствительно хотите удалить сотрудника?", "Удаление сотрудника", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Employee employee = database.Employees.Find(x => x.Name.FirstName == ((EmployeeName)departmentLV.SelectedItems[0]).FirstName && x.Name.LastName == ((EmployeeName)departmentLV.SelectedItems[0]).LastName);
                database.Employees.Remove(employee);
                database.RegenerateDepartments();
                UpdateBinding();
            }
        }

        //добавление сотрудника
        private void bttnAdd_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = EmployeeControl.AddEmployee();
            database.Employees.Add(employee);
            database.RegenerateDepartments();
            UpdateBinding();
        }
    }
}
