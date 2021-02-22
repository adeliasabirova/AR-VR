using System;

namespace Practice
{
    class Program
    {
        static int NOD(int a, int b)
        {
            while (a != b)
                if (a > b) a -= b;
                else b -= a;
            return a;
        }
        static void Task1()
        {
            Console.WriteLine("Task 1: NOD");
            int a = 22222;
            int b = 4444;
            Console.WriteLine($"The nod of {a} and {b} is {(NOD(a, b))}");
        }

        static bool Check(int a)
        {
            return (a % 10 + a / 10 % 10) == 10;
        }

        static void Task2()
        {
            Console.WriteLine("Task 2: Check if sym two last integers equals to 10");
            for (int i = 10; i <= 100; i++)
                if (Check(i))
                    Console.Write($"{i} ");
            Console.WriteLine();
        }

        static void Task3()
        {
            Console.Write("Введите возраст до 50 лет: ");
            int x = Convert.ToInt32(Console.ReadLine());
            string str = "Вам " + x;
            if (x % 10 == 1 && x != 11)
                str += " год";
            else if (x % 10 >= 2 && x % 10 <= 4 && x != 12 && x != 13 && x != 14)
                str += " года";
            else str += " лет";
            Console.WriteLine(str);
        }

        static void Task4()
        {
            Console.Write("Enter the integer: ");
            int x = int.Parse(Console.ReadLine());
            int count = 0, sum = 0;
            while (x != 0)
            {
                if (count == 1000)
                {
                    Console.WriteLine("Too much inputed integers");
                    break;
                }
                else if (Math.Abs(sum) >= 30000)
                {
                    Console.WriteLine("The absoulute value of integer is greater 30000");
                    break;
                }
                else
                {
                    if (x % 8 == 0)
                    {
                        count++;
                        sum += x;
                    }
                }
                x = int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"The mean of inputed integers is {((double)sum / count)}");
        }

        static bool isSimple(int i)
        {
            for (int j = 2; j < i / 2; j++)
                if (i % j == 0) return false;
            return true;
        }

        static void Task5()
        {
            DateTime start = DateTime.Now;
            int count = 0;
            for (int i=2; i<1000000; i++)
            {
                if (isSimple(i))
                {
                    count++;
                    //Console.Write($"{i} ");
                }
            }
            Console.WriteLine($"\nOverall quantity of prima numbers is {count}");
            Console.WriteLine($"Time spent on evaluation is {(DateTime.Now - start)}");
        }

        static uint FactorialLoop(uint n)
        {
            if (n == 0)
                return 1;
            else return n * FactorialLoop(n - 1);
        }

        static uint Factorial(uint n)
        {
            uint res = 1;
            for (uint i = 0; i <= n; i++)
                if (i == 0)
                    res = 1;
                else
                    res *= i;
            return res;
        }

        static void Task6()
        {
            Console.WriteLine("Enter the integer: ");
            uint n = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine($"{n}! = {Factorial(n)}");
            Console.WriteLine($"{n}! = {FactorialLoop(n)} with recursion");
        }


        static uint Fib(uint n)
        {
            uint a0 = 0;
            uint a1 = 1;
            for (int i = 2; i<=n; i++)
            {
                a1 = a0 + a1;
                a0 = a1 - a0;
            }
            return a1;
        }

        static uint FibLoop(uint n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return FibLoop(n - 1) + FibLoop(n - 2);
        }

        static void Task7()
        {
            Console.WriteLine("Enter the integer: ");
            uint n = Convert.ToUInt32(Console.ReadLine()); 
            Console.WriteLine($"The Fibonahi number for {n} is {Fib(n)}"); 
            Console.WriteLine($"The Fibonahi number for {n} is {FibLoop(n)} with recursion");
        }

        static void Move(int number, int from, int to, int free)
        {
            if (number > 0)
            {
                Move(number - 1, from, free, to);
                Console.WriteLine("{0} => {1}", from, to);
                Move(number - 1, free, to, from);
            }
        }
            
        static void Task8()
        {
            Move(4, 1, 2, 3);
        }

        static void Main(string[] args)
        {
            //Task1();
            //Task2();
            //Task3();
            //Task4();
            //Task5();
            //Task6();
            //Task7();
            Task8();
            Console.ReadKey();

        }
    }
}
