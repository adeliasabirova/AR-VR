using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    /// <summary>
    /// Решение задачи 2
    /// </summary>
    public static class Task2
    {
        /// <summary>
        /// Функция нахождения минимума
        /// </summary>
        /// <param name="x">координат нахождения функции</param>
        /// <param name="a">коэффициент</param>
        /// <returns>возвращение значения минимума</returns>
        private static double Min(double a, double b)
        {
            return a < b ? a : b;
        }

        /// <summary>
        /// Функция квадра 
        /// </summary>
        /// <param name="x">координат нахождения функции</param>
        /// <param name="a">коэффициент</param>
        /// <returns>возвращение значения квадрата</returns>
        private static double Power(double x, double a)
        {
            return a * Math.Pow(x, 2);
        }

        /// <summary>
        /// Функция синуса
        /// </summary>
        /// <param name="x">координат нахождения функции</param>
        /// <param name="a">коэффициент</param>
        /// <returns>возвращение значения синуса</returns>
        private static double Sin(double x, double a)
        {
            return a * Math.Sin(x);
        }

        /// <summary>
        /// Функция косинуса
        /// </summary>
        /// <param name="x">координат нахождения функции</param>
        /// <param name="a">коэффициент</param>
        /// <returns>возвращение значения косинуса</returns>
        private static double Cos(double x, double a)
        {
            return a * Math.Cos(x);
        }

        /// <summary>
        /// Функция тангенса
        /// </summary>
        /// <param name="x">координат нахождения функции</param>
        /// <param name="a">коэффициент</param>
        /// <returns>возвращение значения тангенса</returns>
        private static double Tan(double x, double a)
        {
            return a * Math.Tan(x);
        }

        /// <summary>
        /// Функция квадратного корня
        /// </summary>
        /// <param name="x">координат нахождения функции</param>
        /// <param name="a">коэффициент</param>
        /// <returns>возвращение значения квадратного корня</returns>
        private static double Sqrt(double x, double a)
        {
            return a * Math.Sqrt(x);
        }

        /// <summary>
        /// Функция записи массива в файл
        /// </summary>
        /// <param name="fileName">имя файла</param>
        /// <param name="a">начала интервала</param>
        /// <param name="b">клнец интервала</param>
        /// <param name="h">шаг</param>
        /// <param name="F">делегат функци</param>
        public static void SaveFunc(string fileName, double a, double b, double h, Function F)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(F(x,1));
                x += h;
            }
            bw.Close();
            fs.Close();
        }

        /// <summary>
        /// Функция чтения файла и нахождения минимума массива, записанный в файле
        /// </summary>
        /// <param name="fileName">имя файла</param>
        /// <param name="F">делегат функции</param>
        /// <param name="min">передача минимума через out</param>
        /// <returns>возращает массив</returns>
        public static double[] Load(string fileName,  Function F, out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            min = double.MaxValue;
            double d;
            double[] array = new double[fs.Length / sizeof(double)];
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                
                d = bw.ReadDouble();
                array[i] = d;
                min = F(d,min);
            }
            bw.Close();
            fs.Close();
            return array;
        }

        /// <summary>
        /// Модифицировать программу нахождения минимума функции так, 
        /// чтобы можно было передавать функцию в виде делегата. 
        ///а) Сделать меню с различными функциями и представить пользователю выбор, 
        ///для какой функции и на каком отрезке находить минимум.
        ///Использовать массив(или список) делегатов, в котором хранятся различные функции.
        ///б) *Переделать функцию Load, чтобы она возвращала массив считанных значений.
        ///Пусть она возвращает минимум через параметр (с использованием модификатора out). 
        /// </summary>
        public static void Execution()
        {
            Function[] functions = new Function[5]
            {
                Power,
                Sin,
                Cos,
                Tan,
                Sqrt
            };
            Console.WriteLine(@"Choose function:
0 - x^2
1 - sin(x)
2 - cos(x)
3 - tan(x)
4 - sqrt(x)");
            int index = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the interval for minimum finding, enter the start position:");
            int interval1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter ending position:");
            int interval2 = int.Parse(Console.ReadLine());
            SaveFunc("task2.bin", interval1, interval2, 0.5, functions[index]);
            double min;
            double[] array = Load("task2.bin", Min, out min);
            Console.WriteLine("Array:");
            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i].ToString() + ' ');
            Console.WriteLine($"\nMin: {min}");
        }
    }
}
