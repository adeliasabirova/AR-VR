using CalcClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson
{
    public partial class Calc : Form, IView
    {
        Presenter presenter;
        public Calc()
        {
            InitializeComponent();
            presenter = new Presenter(this);
        }

        public string Numb1 => textBoxA.Text; 

        public string Numb2 => textBoxB.Text; 

        public string Result { set => buttonResult.Text = value; }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            presenter.Sum();
        }
    }
}
