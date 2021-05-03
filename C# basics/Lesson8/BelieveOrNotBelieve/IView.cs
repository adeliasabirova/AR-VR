using System;
using System.Collections.Generic;
using System.Text;

namespace BelieveOrNotBelieve
{
    //интерфейс логики
    public interface IView
    {
        //связь с textBox
        string Question { get; set; }
        // связь с numericUpDown
        int Number { get; set; }
        // связь с numericUpDown
        int Max { get; set; }
        // связь с numericUpDown
        int Min { set; }
        // связь с checkBox
        bool Check { get; set; }
    }
}
