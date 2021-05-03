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

        static void Task2()
        {
            MyArray array = new MyArray("C:/Users/adely/source/repos/AR-VR/C# basics/Lesson4/Lesson/Task2.txt");
            Console.WriteLine(array.ToString());
            Console.WriteLine(array.Average);
        }

        static void Task3()
        {
            Random rand = new Random();
            int[] a = new int[10];
            for (int i = 0; i < 10; i++)
                a[i] = rand.Next(0, 100);
            foreach (var v in a)
                Console.Write(v + " ");
            int[] mass = new int[100];
            foreach (var v in a) mass[v]++;
            int imax = 0;
            for (int i = 0; i < mass.Length; i++)
                if (mass[i] > mass[imax]) imax = i;
            for (int i = 0; i < mass.Length; i++)
                if (mass[i] == mass[imax]) Console.WriteLine("\n" + i);
        }

        static void Task4()
        {
            MyArrayTwoDim a = new MyArrayTwoDim(2, 0, 10);
            Console.WriteLine(a.ToString());
            Console.WriteLine("\nМаксимальный элемент: " + a.Max);
            Console.WriteLine("Минимальный элемент: " + a.Min);
            Console.WriteLine("Среднее значение элементов: " + a.Average);
        }

        static void Task5()
        {
            Matrix a = new Matrix(5, 2);
            a.Print();
            a.SearchRows();
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Task5();
            Console.ReadKey();
        }
    }
}
