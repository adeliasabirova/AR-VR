using System;
using System.Collections.Generic;
using System.Text;

namespace GuessTheNumberClass
{
    public interface IView
    {
        string Number { get; }
        string CheckGoal { set; }
    }
}
