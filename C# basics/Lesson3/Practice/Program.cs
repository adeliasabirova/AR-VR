using System;

namespace Practice
{
    class Program
    {

        static void Task1()
        {
            //На вход программе подаётся последовательность чисел, заканчивающаяся нулём. 
            //Найти максимальное число.
            int a = int.Parse(Console.ReadLine());
            int max = a;
            while (a != 0)
            {
                a = int.Parse(Console.ReadLine());
                if (max < a)
                    max = a;
            }
            Console.WriteLine(max);
        }

        static void Task2()
        {
            //Дано натуральное (целое неотрицательное) число а и целое положительное число d. 
            //Вычислить частное q и остаток r при делении а на d, не используя операций деления (/) и взятия остатка от деления (%).
            int a = 19, d = 3, r = a, q = 0;
            while (r >= d)
            {
                r -= d;
                q++;
            }
            if (r != 0)
                Console.WriteLine($"{a} = {q}*{d} + {r}");
            else Console.WriteLine($"{a} = {q}*{d}");
        }

        static double F(double x)
        {
            return 1 / x;
        }
        static void Task3()
        {
            //Написать программу табуляции произвольной функции в диапазоне от a до b. 
            //Функция задаётся программно. 
            double a = -5;
            double b = 5;
            double h = 0.5;
            Console.WriteLine("{0,10}{1,10}", "x", "F(x)");
            for (double x = a; x <= b; x = x + h)
            {
                Console.WriteLine("{0,10}{1,10:f3}", x, F(x));
            }
        }

        static void Task3_1()
        {
            Table table1 = new Table();
            table1.Show();
            Console.WriteLine("Для выполнения следующего расчета нажмите любую клавишу");
            Console.ReadKey();
            Table table2 = new Table(1, 2, 0.5);
            table2.Show();
            Console.ReadKey();
        }

        static void Task4()
        {
            int min = 1, max = 100, count = 0;
            int maxCount = (int)Math.Log(max - min + 1, 2);
            Random rnd = new Random();
            int guessNumber = rnd.Next(min, max);
            Console.WriteLine($"Computer chooses the number from {min} to {max}, you can guess with {maxCount} attempts");
            int n;
            do
            {
                count++;
                Console.Write($"{count} attempt. Enter the number: ");
                n = int.Parse(Console.ReadLine());
                if (guessNumber > n) Console.WriteLine("Greater!");
                else if (guessNumber < n) Console.WriteLine("Less!");
            } while (count < maxCount && n!=guessNumber);
            if (n == guessNumber) Console.WriteLine("Congratulations!");
            else Console.WriteLine("You were close!");
        }

        static void Main(string[] args)
        {
            //Task1();
            //Task2();
            //Task3();
            //Task3_1();
            Task4();
            Console.ReadKey();
        }
    }
}
