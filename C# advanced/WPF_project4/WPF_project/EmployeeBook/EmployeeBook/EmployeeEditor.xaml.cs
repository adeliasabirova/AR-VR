using EmployeeBook.Communication.EmployeeBookService;
using EmployeeControls;
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
using System.Windows.Shapes;

namespace EmployeeBook
{
    /// <summary>
    /// Логика взаимодействия для EmployeeEditor.xaml
    /// </summary>
    public partial class EmployeeEditor : Window
    {
        private EditorType editorType;
        public EmployeeEditor()
        {
            InitializeComponent();
            editorType = EditorType.Add;
            EmployeeControl.Employee = Employee;
        }

        private void PrepareUI()
        {
            switch (editorType)
            {
                case EditorType.Add:
                    this.Title = $"{this.Title} [Добавление]";
                    break;
                case EditorType.Edit:
                    this.Title = $"{this.Title} [Правка]";
                    break;
            }
            EmployeeControl.PrepareUI(editorType);
        }

        public Employee Employee { get; set; } = new Employee();

        private void bttnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bttnOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
