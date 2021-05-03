using System;

namespace Lesson
{

    class Program
    {
        static void YouTubeTask()
        {
            Complex z1 = new Complex(2, 3);
            Complex z2 = new Complex(-4, -8);

            Console.WriteLine($"z1 = {z1.Print()}");
            Console.WriteLine($"z2 = {z2.Print()}");

            Complex r = Complex.Sum(z1, z2);
            Console.WriteLine($"r = z1 + z2 = {r.Print()}");

            Complex res = z1.Sum(z2);
            Console.WriteLine($"r = z1 + z2 = {res.Print()}");

            Complex result = z1 + z2;
            Console.WriteLine($"r = z1 + z2 = {result.Print()}");
        }

        static void Swap(ref int a, ref int b)
        {
            a += b;
            b = a - b;
            a -= b;
        }
        static void Task1()
        {
            int a = 5, b = 10;
            Console.WriteLine($"Before swap: a = {a}, b= {b}");
            Swap(ref a, ref b);
            Console.WriteLine($"After swap: a = {a}, b= {b}");
        }


        static int value;
        static string console_message = "Введите число:";

        static int GetValue(string message)
        {
            int x;
            string s;
            bool flag;
            do
            {
                Console.WriteLine(message);
                s = Console.ReadLine();
                flag = int.TryParse(s, out x);
            } while (!flag);
            return x;
        }

        static void ShowValue(string description)
        {
            Console.WriteLine(description + value);
        }

        static int ReturnValue()
        {
            ShowValue("ReturnValue (до): ");
            int tmp = 10;
            ShowValue("ReturnValue (после): ");
            return tmp;
        }

        static void OutParameter(out int tmp)
        {
            ShowValue("OutParameter (до): ");
            tmp = 10;
            ShowValue("OutParameter (после): ");
        }


        static void Task2()
        {
            value = GetValue(console_message);
            Console.WriteLine("Return ...");
            value = ReturnValue();
            ShowValue("value после ReturnValue(): ");

            value = GetValue(console_message);
            Console.WriteLine("Out parameter ...");
            OutParameter(out value);
            ShowValue("value после OutParameter(): ");
        }

        static void Main(string[] args)
        {
            Task2();
            Console.ReadKey();
        }
    }
}
