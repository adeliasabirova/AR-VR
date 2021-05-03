using EmployeeDepartmentData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<Employee> EmployeesList { get; set; } = new ObservableCollection<Employee>();
        public Employee SelectedEmployee { get; set; }

        public ObservableCollection<DepartmentCategory> CategoryList { get; set; } = new ObservableCollection<DepartmentCategory>();

        //инициализация окна
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            CategoryList.Add(DepartmentCategory.Department1);
            CategoryList.Add(DepartmentCategory.Department2);
            CategoryList.Add(DepartmentCategory.Department3);
            CategoryList.Add(DepartmentCategory.Department4);
            CategoryList.Add(DepartmentCategory.Department5);
        }

        //вспомогательная функция для отображения списка работников по департаменту
        private void UpdateListView()
        {
            EmployeesList.Clear();
            var employeesList = database.Employees.Where(d => d.Department == (DepartmentCategory)departmentCB.SelectedItem).ToList();
            foreach (var employee in employeesList)
                EmployeesList.Add(employee);
        }

        //при выборе отдела в листвью выводится список сотрудников, работающих в этом отделе
        private void departmentCB_DropDownClosed(object sender, EventArgs e)
        {
            UpdateListView();
        }

        //при выборе сотрудника из отдела выходит карточка сотрудника с именем, фамилией, отделом и должностью
        private void departmentLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.AddedItems.Count > 0)
            {
                EmployeeControl.Employee = (Employee)SelectedEmployee.Clone();
            }
        }

        //внесение изменений в карточку сотрудника
        private void bttnAccept_Click(object sender, RoutedEventArgs e)
        {
            if (departmentLV.SelectedItems.Count < 1)
                return;

            database.Employees[database.Employees.IndexOf(SelectedEmployee)] = EmployeeControl.Employee;
            UpdateListView();
        }

        ////обновление листвью
        //private void UpdateBinding()
        //{
        //    departmentLV.ItemsSource = null;
        //    var index = database.Departments.FindIndex(d => d.DepartmentName == (DepartmentCategory)departmentCB.SelectedItem);
        //    departmentLV.ItemsSource = database.Departments[index].EmployeeList;
        //}

        //удаление сотрудника
        private void bttnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (departmentLV.SelectedItems.Count < 1)
                return;

            if (MessageBox.Show("Вы дйствительно хотите удалить сотрудника?", "Удаление сотрудника", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                database.Employees.Remove((Employee)departmentLV.SelectedItems[0]);
                UpdateListView();
            }
        }

        //добавление сотрудника
        private void bttnAdd_Click(object sender, RoutedEventArgs e)
        {
            database.Employees.Add(EmployeeControl.Employee);
            UpdateListView();
        }
    }
}
