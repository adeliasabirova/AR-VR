using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson
{
    class Program
    {

        static Int32 MaxTwoInt()
        {
            int a, b;
            Console.Write("Enter the first number: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the second number: ");
            b = Convert.ToInt32(Console.ReadLine());
            if ( a > b)
            {
                Console.WriteLine($"The maximum number is {a}");
                return a;
            }
            else
            {
                Console.WriteLine($"The maximum number is {b}");
                return b;
            }
        }

        static Int32 MaxTwoIntTernar()
        {
            int a, b;
            Console.Write("Enter the first number: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the second number: ");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"The maximum number is {(a > b ? a : b)}");
            return a > b ? a : b;
        }

        static void OddNumberTernar()
        {
            Console.Write("Enter the integer: ");
            int x = Convert.ToInt32(Console.ReadLine());
            string str = x % 2 == 0 ? "even number" : "odd number";
            Console.WriteLine($"{x} is {str}");
        }

        static void SeasonMonth()
        {
            Console.Write("Write the value of desired month: ");
            int month = Convert.ToInt32(Console.ReadLine());
            string season;
            switch (month)
            {
                case 1:
                case 2:
                case 12: season = "Winter";
                    break;

                case 3:
                case 4:
                case 5: season = "Spring";
                    break;

                case 6:
                case 7:
                case 8: season = "Summer";
                    break;

                case 9:
                case 10:
                case 11: season = "Autumn";
                    break;

                default:
                    season = "Nothing";
                    break;
            }
            Console.WriteLine($"The month is in {season}");
        }

        enum Months { None, January, February, March, April, May, June, July, August, September, October, November, December };
        enum Seasons { None, Winter, Spring, Summer, Autumn };

        static void SeasonMonthEnum()
        {
            Console.Write("Write the value of desired month: ");
            int m = Convert.ToInt32(Console.ReadLine());
            Months month = (Months)m;
            Seasons season;
            switch (month)
            {
                case (Months)1:
                case (Months)2:
                case (Months)12:
                    season = Seasons.Winter;
                    break;

                case (Months)3:
                case (Months)4:
                case (Months)5:
                    season = Seasons.Spring;
                    break;

                case (Months)6:
                case (Months)7:
                case (Months)8:
                    season = Seasons.Summer;
                    break;

                case (Months)9:
                case (Months)10:
                case (Months)11:
                    season = Seasons.Autumn;
                    break;

                default:
                    season = Seasons.None;
                    break;
            }
            Console.WriteLine($"The month is in {season}");
        }

        static void IntegerCount()
        {
            Console.Write("Enter integer: ");
            int x = Convert.ToInt32(Console.ReadLine());
            int y = x;
            int count = 0;
            while(x > 0)
            {
                x /= 10;
                count++;
            }
            Console.WriteLine($"{y} has {count} numbers");
        }

        static void ConstraintInput()
        {
            int a = 0, count = 0;
            do
            {
                Console.Write("Enter integer: ");
                a = Convert.ToInt32(Console.ReadLine());
                count++;
            } while (a < 1 || a > 99);
            Console.WriteLine($"You inputed {count} times");
        }

        static void FiveTimesHello()
        {
            for (int i = 0; i < 5; i++)
                Console.WriteLine("Hello!");
        }

        static void EnumerationFromAToB()
        {
            Console.Write("Enter the first integer, it should be less than second integer: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the second integer: ");
            int b = Convert.ToInt32(Console.ReadLine());
            int count = 0, sum = 0;
            for(int i = b; i>=a; i--)
            {
                Console.Write($"{i} ");
                count++;
                sum += i;
            }
            Console.WriteLine($"The amount numbers between {a} and {b} is {count}, the sum is {sum}");
        }

        static void EnumerationFromAToBLoop(int a, int b)
        {
            Console.Write($"{a} ");
            if (a < b) EnumerationFromAToBLoop(a + 1, b);
        }

        static void EnumerationFromAToBRecursion()
        {
            Console.Write("Enter the first integer, it should be less than second integer: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the second integer: ");
            int b = Convert.ToInt32(Console.ReadLine());

            EnumerationFromAToBLoop(a, b);
        }

        static void ForeachHello()
        {
            string str = "Hello! Foreach cycle";
            int count = 0;
            foreach(char c in str)
            {
                Console.Write($"{c} ");
                count++;
            }
            Console.WriteLine($"String has {count} chars.");
        }

        static void CycleOfCycle()
        {
            for (int i=0; i<100; i++)
            {
                for(int j=0; j<100; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write("*");
                    System.Threading.Thread.Sleep(20);
                    Console.Title = "i=" + i + " j=" + j;
                }
            }
        }

        static long Sum(long a)
        {
            long sum = 0;
            while(a > 0)
            {
                sum += a % 10;
                a /= 10;
            }
            return sum;
        }

        static long SumLoop(long a)
        {
            if (a == 0)
                return 0;
            else return SumLoop(a / 10) + a % 10;
        }

        static void FindSumA()
        {
            Console.Write("Enter integer: ");
            long a = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine($"The sum of {a} is {(Sum(a))}");
            Console.WriteLine($"The sum of {a} is {(SumLoop(a))} with recursion");
        }

        static bool isOdd(int a)
        {
            return a % 2 == 0;
        }


        static void ProcedureProgramming()
        {
            for (int i=1; i<100; i++)
            {
                if (isOdd(i))
                {
                    long sum = Sum(i);
                    Console.WriteLine($"The integer {i} has sum of its numbers equaled {sum}");
                }
            }
        }

        static void Main(string[] args)
        {
            int max = MaxTwoInt();
            int maxTernar = MaxTwoIntTernar();
            OddNumberTernar();
            SeasonMonth();
            SeasonMonthEnum();
            IntegerCount();
            ConstraintInput();
            FiveTimesHello();
            EnumerationFromAToB();
            EnumerationFromAToBRecursion();
            ForeachHello();
            CycleOfCycle();
            FindSumA();
            ProcedureProgramming();
            Console.ReadKey();
        }
    }
}
