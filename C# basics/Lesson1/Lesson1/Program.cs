using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    class Program
    {

        static double Task1Addition()
        {
            double x, y;
            Console.Write("Enter the first number: ");
            x = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the second number: ");
            y = Convert.ToDouble(Console.ReadLine());
            double z = x + y;
            Console.WriteLine("The sum of two numbers is " + z);
            return z;
        }

        static double Task2SquareEquation()
        {
            double a = 1, b = 1, c = 1, x;
            Console.Write("Enter x: ");
            x = Convert.ToDouble(Console.ReadLine());
            double f = a * Math.Pow(x, 2) + b * x + c;
            Console.WriteLine("f(x) = {0}x^2 + {1}x+{2}, at x = {3}, f={4}", a, b, c, x, f);
            return f;
        }

        static (int, int) Swap(int a, int b)
        {
            int t = a;
            a = b;
            b = t;
            return (a, b);
        }

        static void Task3Swap()
        {
            Console.Write("Enter a for swap: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter b for swap: ");
            int b = Convert.ToInt32(Console.ReadLine());
            (int a, int b) t = Swap(a, b);
            Console.WriteLine($"After the swap a = {t.a}, b = {t.b}");
        }

        static bool Odd(int n)
        {
            return n % 2 == 0;
        }

        static void Task4Odd()
        {
            Console.Write("Enter n for odd check: ");
            int n = Convert.ToInt32(Console.ReadLine());
            if(Odd(n))
                Console.WriteLine($"{n} is Odd number");
            else
                Console.WriteLine($"{n} is not odd number");
        }

        static void Print(string msg, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(msg);
        }

        static void Print(string msg, ConsoleColor foregroundcolor)
        {
            Console.ForegroundColor = foregroundcolor;
            Console.WriteLine(msg);
        }
        static void Print(string msg, int x, int y, ConsoleColor foregroundcolor)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = foregroundcolor;
            Console.WriteLine(msg);
        }

        static void Task5Overload()
        {
            Print("Hello!\n", 70, 70);
            Print("Hello!\n", ConsoleColor.Blue);
            Print("Hello!\n", 70, 70, ConsoleColor.Green);
        }
        
        static bool IsTriangle(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }

        static double SquareTriangle(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        static void Task6SquareTriangle()
        {
            Console.Write("Enter a: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter b: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter c: ");
            double c = Convert.ToDouble(Console.ReadLine());
            if (IsTriangle(a, b, c))
                Console.WriteLine("The square of tringle with the entered numbers: " + SquareTriangle(a, b, c));
            else
                Console.WriteLine("The entered numbers cannot form a triangle");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Task 1: Addition");
            double z = Task1Addition();
            Console.WriteLine("\nTask 2: Square Equation");
            double f = Task2SquareEquation();
            Console.WriteLine("\nTask 3: Swap");
            Task3Swap();
            Console.WriteLine("\nTask 4: Check on odd number");
            Task4Odd();
            Console.WriteLine("\nTask 5: Overload");
            Task5Overload();
            Console.WriteLine("\nTask 6: Square of triangle");
            Task6SquareTriangle();
            Console.ReadKey();
        }
    }
}
