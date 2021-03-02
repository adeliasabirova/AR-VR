 using System;

namespace Lesson
{
    class Program
    {

        static void Task1()
        {
            MyArray array = new MyArray(10, 0, 100);
            Console.WriteLine(array.ToString());
            Console.WriteLine(array.Max);
            Console.WriteLine(array.Min);
            Console.WriteLine(array.CountPositiv);
        }

        static void Main(string[] args)
        {
            Task1();
            Console.ReadKey();
        }
    }
}
