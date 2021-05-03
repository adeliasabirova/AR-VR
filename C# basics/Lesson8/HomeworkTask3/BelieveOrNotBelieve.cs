using BelieveOrNotBelieve;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Аделя Сабирова


namespace HomeworkTask3
{
    public partial class BelieveOrNotBelieve : Form, IView
    {
        /// <summary>
        /// в библиотеке BelieveOrNotBeleive реализована логика программы
        /// </summary>
        Start start;
        public string Question { get => throw new NotImplementedException(); set => txtBoxQuestion.Text = value; }
        public int Number { get => (int)nudNumber.Value; set => nudNumber.Value = value; }
        public bool Check { get => throw new NotImplementedException(); set => cbTruth.Checked = value; }
        public int Max { get => (int)nudNumber.Maximum;  set => nudNumber.Maximum = value; }
        public int Min { set => nudNumber.Minimum = value; }

        /// <summary>
        /// а) Создать приложение, показанное на уроке, добавив в него защиту от возможных ошибок 
        /// (не создана база данных, обращение к несуществующему вопросу, открытие слишком большого файла и т.д.).
        ///б) Изменить интерфейс программы, увеличив шрифт, поменяв цвет элементов и добавив другие «косметические» улучшения на свое усмотрение.
        ///в) Добавить в приложение меню «О программе» с информацией о программе(автор, версия, авторские права и др.).
        ///г)* Добавить пункт меню Save As, в котором можно выбрать имя для сохранения базы данных(элемент SaveFileDialog).
        /// </summary>
        public BelieveOrNotBelieve()
        {
            InitializeComponent();
            start = new Start(this);
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void miNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                start.New(sfd.FileName);
            }
        }

        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            start.ViewQuestion();
        }

        private void bttnAdd_Click(object sender, EventArgs e)
        {
            string str = start.Add();
            if (str != "OK")
                MessageBox.Show(str, "Message");
        }

        private void bttnDel_Click(object sender, EventArgs e)
        {
            start.Delete();
        }

        private void bttnSave_Click(object sender, EventArgs e)
        {
            start.SaveQuestion();
        }

        private void miOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                start.Open(ofd.FileName);
            }

        }
        private void miSave_Click(object sender, EventArgs e)
        {
            string str = start.Save();
            if (str != "OK")
                MessageBox.Show(str, "Message");
        }

        private void miSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string str = start.SaveAs(sfd.FileName);
                if (str != "OK")
                    MessageBox.Show(str, "Message");
            }

        }

        private void miAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Adelia Sabirova
version 1.0
copyright: all rights reserved", "About");
        }

    }
}
