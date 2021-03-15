using GuessTheNumberClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeworkTask2
{
    public partial class GuessTheNumber : Form, IView
    {
        Presenter presenter;
        /// <summary>
        /// Используя Windows Forms, разработать игру «Угадай число». 
        /// Компьютер загадывает число от 1 до 100, а человек пытается его угадать за минимальное число попыток. 
        /// Компьютер говорит, больше или меньше загаданное число введенного.  
        /// Для ввода данных от человека используется элемент TextBox;
        /// </summary>
        public GuessTheNumber()
        {
            InitializeComponent();
            presenter = new Presenter(this);
        }

        public string Number => txtBoxNumber.Text;
        public string CheckGoal { set => lblCheck.Text = value; }

        /// <summary>
        /// обработка сценария проверки числа к цели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bttnCheck_Click(object sender, EventArgs e)
        {
            presenter.Check();
        }

        /// <summary>
        /// обработка начала игры и создания цели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bttnPlay_Click(object sender, EventArgs e)
        {
            presenter.Play();
        }
    }
}
