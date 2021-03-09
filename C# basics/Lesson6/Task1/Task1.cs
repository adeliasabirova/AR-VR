using System;

namespace Task1
{
    public delegate double Function(double x, double a);
    public static class Task
    {
        private static void Table(Function F, double x, double a, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x,a));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }

        private static double Power(double x, double a)
        {
            return a * Math.Pow(x, 2);
        }

        private static double Sin(double x, double a)
        {
            return a * Math.Sin(x);
        }

        public static void Execution()
        {
            double a = 2.5;
            double x = -4;
            double b = 4;
            Console.WriteLine($"Function: a*x^2, a = {a}, x = (-4, 4)");
            Table(Power, x, a, b);
            Console.WriteLine($"\nFunction: a*sin(x),  a = {a}, x = (-4, 4)");
            Table(Sin, x, a, b);
        }

    }
}
