using EmployeeBook.Communication.EmployeeBookService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class EmployeeControl : UserControl, INotifyPropertyChanged
    {
        //сущность контроллера сотрудника: 3 текстбокса и один комбобокс
        private Employee employee;

        public event PropertyChangedEventHandler PropertyChanged;

        public Employee Employee
        {
            get => employee;
            set
            {
                employee = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<DepartmentCategory> CategoryList { get; set; } = new ObservableCollection<DepartmentCategory>();

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = " ")
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public EmployeeControl()
        {
            InitializeComponent();

            this.DataContext = this;

            CategoryList.Add(DepartmentCategory.Department1);
            CategoryList.Add(DepartmentCategory.Department2);
            CategoryList.Add(DepartmentCategory.Department3);
            CategoryList.Add(DepartmentCategory.Department4);
            CategoryList.Add(DepartmentCategory.Department5);
        }

        public void PrepareUI(EditorType editorType)
        {
            switch (editorType)
            {
                case EditorType.Add:
                    //this.tbPhone.IsReadOnly = false;
                    //this.tbPhone.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFFFF")); /*#FFF1EFEF*/
                    break;
                case EditorType.Edit:
                    break;
            }
        }
        ////установка карточки сотрудника
        //public void SetEmployee(Employee employee)
        //{
        //    this.employee = employee;
        //    txtBoxName.Text = employee.Name.FirstName;
        //    txtBoxLast.Text = employee.Name.LastName;
        //    cbDepartment.SelectedItem = employee.Department;
        //    txtBoxJob.Text = employee.Job;
        //}

        ////обновление карточки сотрудника
        //public void UpdateEmployee()
        //{
        //    employee.Name = new EmployeeName(txtBoxName.Text, txtBoxLast.Text);
        //    employee.Department = (DepartmentCategory)cbDepartment.SelectedItem;
        //    employee.Job = txtBoxJob.Text;
        //}

        ////добавление сотрудника
        //public Employee AddEmployee()
        //{
        //    DepartmentCategory department = (DepartmentCategory)cbDepartment.SelectedItem;
        //    string job = txtBoxJob.Text;
        //    return new Employee(txtBoxName.Text, txtBoxLast.Text, department, job);
        //}
    }
}
