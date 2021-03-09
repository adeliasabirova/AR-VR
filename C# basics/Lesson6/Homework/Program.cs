using System;
using Tasks;
namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Решение задачи 1");
            Tasks.Task1.Execution();
            Console.WriteLine("\nРешение задачи 2");
            Tasks.Task2.Execution();
            Console.WriteLine("\nРешение задачи 3");
            Tasks.Task3.Execution();
        }
    }
}
