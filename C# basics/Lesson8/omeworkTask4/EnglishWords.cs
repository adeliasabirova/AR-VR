using EnglishWordsClass;
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

namespace omeworkTask4
{
    public partial class EnglishWords : Form, IView
    {
        Start start;
        /// <summary>
        /// *Используя полученные знания и класс TrueFalse в качестве шаблона, 
        /// разработать собственную утилиту хранения данных Английские слова.
        /// в библиотеке EnglishWordClass реализована логика программы, немного изменила вид формы, 
        /// поэтому класс TrueFalse изменила под форму и от этого создала новую библиотеку
        /// </summary>
        public EnglishWords()
        {
            InitializeComponent();
            start = new Start(this);
        }

        public string Word => txtBoxWord.Text;

        public List<string> Glossary { set => rtxtBoxALL.Lines = value.ToArray(); }

        public int Index {
            get {
                int value;
                bool b = int.TryParse(txtBoxIndex.Text, out value);
                return value;
            }
        }

        //private void rtxtBoxALL_TextChanged(object sender, EventArgs e)
        //{
        //    start.ViewGlossary();
        //}

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                start.New(sfd.FileName);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                start.Open(ofd.FileName);
                start.ViewGlossary();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = start.Save();
            if (str != "OK")
                MessageBox.Show(str, "Message");
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string str = start.SaveAs(sfd.FileName);
                if (str != "OK")
                    MessageBox.Show(str, "Message");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bttnAdd_Click(object sender, EventArgs e)
        {
            string str = start.Add();
            if (str != "OK")
                MessageBox.Show(str, "Message");
            else
                start.ViewGlossary();
        }

        private void bttnDelete_Click(object sender, EventArgs e)
        {
            start.Delete();
            start.ViewGlossary();
        }

    }
}
