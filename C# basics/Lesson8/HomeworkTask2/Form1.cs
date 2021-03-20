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
namespace HomeworkTask2
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Создайте простую форму на котором свяжите свойство Text элемента TextBox со свойством Value элемента NumericUpDown
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Связь textBox с numericUpDown
        /// </summary>
        private void TextChange()
        {
            decimal value;
            bool f = decimal.TryParse(txtBox.Text, out value);
            if(f)
                nmrcUpDown.Value = value;
            else
                MessageBox.Show("Error");
        }
        /// <summary>
        /// Связь textBox с numericUpDown c рефлексией
        /// решила попробвать на виндовс форме сделать с рефлексией, обычно проще, но сделала для практики больше для себя
        /// </summary>
        private void TextChangeReflection()
        {
            decimal value;
            bool f = decimal.TryParse(txtBox.GetType().GetProperty("Text").GetValue(txtBox).ToString(), out value);
            if (f)
                nmrcUpDown.GetType().GetProperty("Value").SetValue(nmrcUpDown, value);
            else
                MessageBox.Show("Error");
        }
        
        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            //TextChangeReflection();
            TextChange();
        }
        /// <summary>
        /// Связь numericUpDown c textBox
        /// </summary>
        private void ValueChange()
        {
            txtBox.Text = nmrcUpDown.Value.ToString();
        }
        /// <summary>
        /// Связь numericUpDown c textBox с рефлексией
        /// </summary>
        private void ValueChangeReflection()
        {
            var value = nmrcUpDown.GetType().GetProperty("Value").GetValue(nmrcUpDown);
            txtBox.GetType().GetProperty("Text").SetValue(txtBox, value.ToString());
        }
        private void nmrcUpDown_ValueChanged(object sender, EventArgs e)
        {
            //ValueChangeReflection();
            ValueChange();
        }
    }
}
