using System;

namespace Tasks
{
    /// <summary>
    /// Делегат функции
    /// </summary>
    /// <param name="x">координата нахождения функции</param>
    /// <param name="a">коэффициент</param>
    /// <returns>возвращение значения функции</returns>
    public delegate double Function(double x, double a);

    /// <summary>
    /// Решение задачи 1
    /// </summary>
    public static class Task1
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="F">Функция</param>
        /// <param name="x">координата нахождения функции</param>
        /// <param name="a">коэффициентparam>
        /// <param name="b">последняя точка интервала</param>
        private static void Table(Function F, double x, double a, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x, a));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }

        /// <summary>
        /// Функция возведения в квадрат
        /// </summary>
        /// <param name="x">координата нахождения функции</param>
        /// <param name="a">коэффициент</param>
        /// <returns>значение квадрата функции</returns>
        private static double Power(double x, double a)
        {
            return a * Math.Pow(x, 2);
        }

        /// <summary>
        /// Функция нахождения синуса
        /// </summary>
        /// <param name="x">координата нахождения функции</param>
        /// <param name="a">коэффициент</param>
        /// <returns>значение синуса</returns>
        private static double Sin(double x, double a)
        {
            return a * Math.Sin(x);
        }

        /// <summary>
        /// Изменить программу вывода таблицы функции так, 
        /// чтобы можно было передавать функции типа double (double, double). 
        /// Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
        /// </summary>

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
