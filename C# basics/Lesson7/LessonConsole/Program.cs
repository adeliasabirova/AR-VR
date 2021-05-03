using CalcClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonConsole
{
    class ViewConsole : IView
    {
        public string Numb1
        {
            get
            {
                Console.WriteLine("Enter the first number");
                return Console.ReadLine();
            }
        }

        public string Numb2
        {
            get
            {
                Console.WriteLine("Enter the second number");
                return Console.ReadLine();
            }
        }

        public string Result { set => Console.WriteLine(value); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Presenter presenter = new Presenter(new ViewConsole());
            presenter.Sum();
            Console.ReadKey();
        }
    }
}
