using PowerClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework
{
    public partial class Power : Form, IView 
    {
        Presenter presenter;

        /// <summary>
        /// Аделя Сабирова
        /// Домашнее задание 1
        /// а) Добавить в программу «Удвоитель» подсчёт количества отданных команд удвоителю.
        ///б) Добавить меню и команду «Играть». 
        ///При нажатии появляется сообщение, какое число должен получить игрок.
        ///Игрок должен получить это число за минимальное количество ходов.
        ///в) *Добавить кнопку «Отменить», которая отменяет последние ходы.Используйте обобщенный класс Stack.
        /// </summary>
        public Power()
        {
            InitializeComponent();
            presenter = new Presenter(this);
        }

        public string Number { get => labelNumber.Text; set => labelNumber.Text = value; }
        public string Count { set => labelCount.Text = value; }
        public string Goal { set => labelGoal.Text = value; }

        /// <summary>
        /// функция сложения числа с единицей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bttnPlus1_Click(object sender, EventArgs e)
        {
            presenter.Plus1();
            presenter.ShowCount();
        }
        /// <summary>
        /// функция умножения число на 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bttnX2_Click(object sender, EventArgs e)
        {
            presenter.X2();
            presenter.ShowCount();
        }
        /// <summary>
        /// функция сброса ходов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bttnReset_Click(object sender, EventArgs e)
        {
            presenter.Reset();
            presenter.ShowCount();
        }

        /// <summary>
        /// Добавить меню и команду «Играть». 
        /// При нажатии появляется сообщение, какое число должен получить игрок.
        /// Игрок должен получить это число за минимальное количество ходов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bttnPlay_Click(object sender, EventArgs e)
        {
            presenter.ShowGoal();
        }

        /// <summary>
        /// в) *Добавить кнопку «Отменить», которая отменяет последние ходы.Используйте обобщенный класс Stack.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bttnCancel_Click(object sender, EventArgs e)
        {
            presenter.Cancel();
            presenter.ShowCount();
        }
    }
}
