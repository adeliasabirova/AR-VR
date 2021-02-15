using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lesson1
{
    class Program
    {
        static void GeneralConstructions()
        {
            string s = "string";
            string str = s[0].ToString() + s[1] + s[2];  // str="str"

            Char.IsDigit(s[3]);                          // проверка, является ли символ числом

            bool b;                                      // объявили переменную b типа bool
            b = false;                                   // переменной b присвоили значение false
            b = 2 * 2 == 4;                              // переменной b присвоили значение true

            var a = 10;                                  // компилятор объявит переменную типом int

            double a = 3.14;
            int b = (int)a;                              // Так можно, но с потерей дробной части
            string s = "3.14";
            int c = Int32.Parse(s);

            Console.Write("Не переходим на следующую строку.");
            Console.WriteLine("Переходим на следующую строку");

            Console.WriteLine("{0:D7}", 12345);

            double x;
            string str2 = Console.ReadLine();
            x = Convert.ToDouble(str2);
        }

        static int Sqr(int x)
        {
            return x * x;
        }

        static void Square()
        {
            int value = 8;
            Console.WriteLine("Квадрат числа " + value + " = " + Sqr(value));
        }

        static void Pause()                    // Создали метод
        {
            Console.ReadKey();
        }
        static void Pause(string msg)   // Перегрузили метод
        {
            Console.WriteLine(msg);
            Console.ReadKey();
        }

        static void Overload()
        {
            Pause();
            Pause("Перегруженный метод");
        }

        static double Addition()
        {
            double x, y;
            Console.Write("Enter the first number: ");
            x = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the second number: ");
            y = Convert.ToDouble(Console.ReadLine());
            double z = x + y;
            Console.WriteLine(x + "+" + y + "=" + z);
            return z;
        }

        static double SquareRootEq()
        {
            double a = 1, b = 1, c = 1, x;
            Console.Write("Enter the x: ");
            x = Convert.ToDouble(Console.ReadLine());
            double f = a * Math.Pow(x, 2) + b * x + c;
            Console.WriteLine("f = {0}*x^2+{1}*x+{2}, at x={3}, f = {4}", a, b, c, x, f);
            return f;
        }

        static (int, int) ChangeTwoItems(int a, int b)
        {
            int t = a;
            a = b;
            b = t;
            return (a, b);
        }

        static bool Odd(int n)
        {
            return n % 2 == 0;
        }

        static void Print(string msg, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(msg);
        }

        static void Print(string msg, ConsoleColor color)
        { 
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
        }

        static void Print(string msg, int x, int y, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
        }

        static bool IsTriangle(double a, double b, double c)
        {
            return a + b > c && a + c > b && c + b > a;
        }

        static double S(double a, double b, double c)
        {
            if(IsTriangle(a, b, c))
            {
                double p = (a + b + c) / 2;
                return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
            else
                return -1;
        } 

        static void SquareTriangle()
        {
            Console.Write("Enter a: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Enter b: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Enter c: ");
            double c = double.Parse(Console.ReadLine());
            double squareTriangle = S(a, b, c);
            if(squareTriangle == -1)
                Console.WriteLine("There is no triangle with such values");
            else
                Console.WriteLine("The square of triangle: " + squareTriangle);
        }

        static void Main(string[] args)
        {
            GeneralConstructions();
            Square();
            Overload();

        }
    }
}
