using System;

namespace Homework
{
    partial class Program
    {
        static void Main(string[] args)
        {
            //Аделя Сабирова
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Решение задачи 1");
            Console.ForegroundColor = ConsoleColor.White;
            Task1.Task("C:/Users/adely/source/repos/AR-VR/C# basics/Lesson5/Homework/Task1.txt");
            Task1.TaskReg("C:/Users/adely/source/repos/AR-VR/C# basics/Lesson5/Homework/Task1.txt");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\nРешение задачи 2");
            Console.ForegroundColor = ConsoleColor.White;
            Task2.Task("C:/Users/adely/source/repos/AR-VR/C# basics/Lesson5/Homework/Task2.txt");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\nРешение задачи 3");
            Console.ForegroundColor = ConsoleColor.White;
            string str1 = "badc";
            string str2 = "abcd";
            string str3 = "abbd";
            Task3.Task(str1, str2);
            Task3.Task(str1, str3);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\nРешение задачи 4");
            Console.ForegroundColor = ConsoleColor.White;
            Task4.Task("C:/Users/adely/source/repos/AR-VR/C# basics/Lesson5/Homework/Task4.txt");
        }
    }
}
