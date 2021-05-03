using System;
using System.Collections.Generic;
using System.IO;

namespace Tasks
{
    public static class Task3
    {
        public static int CompareName(Student st1, Student st2)          
        {

            return String.Compare(st1.firstName, st2.firstName);          
        }

        /// <summary>
        /// отсортировать список по возрасту студента;
        /// </summary>
        /// <param name="st1">объект первого студента</param>
        /// <param name="st2">объект второго студента</param>
        /// <returns></returns>
        public static int CompareAge(Student st1, Student st2)
        {
            if (st1.age > st2.age) return 1;
            if (st1.age < st2.age) return -1;
            return 0;
        }

        /// <summary>
        /// отсортировать список по курсу и возрасту студента;
        /// </summary>
        /// <param name="st1">объект первого студента</param>
        /// <param name="st2">объект второго студента</param>
        /// <returns></returns>
        public static int CompareCourse(Student st1, Student st2)
        {
            if (st1.course > st2.course) return 1;
            if (st1.course < st2.course) return -1;
            if (st1.age > st2.age) return 1;
            if (st1.age < st2.age) return -1;
            return 0;
        }

        /// <summary>
        /// Переделать программу Пример использования коллекций для решения следующих задач:
        ///а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
        ///б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(*частотный массив);
        ///в) отсортировать список по возрасту студента;
        ///г) *отсортировать список по курсу и возрасту студента;
        /// </summary>
        public static void Execution()
        {
            int course5 = 0;
            int course6 = 0;
            List<Student> list = new List<Student>();
            int[,] frequencies = new int[3, 6];

            StreamReader sr = new StreamReader("C:/Users/adely/source/repos/AR-VR/C# basics/Lesson6/Tasks/Task3.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                    if (int.Parse(s[5]) == 5) course5++; 
                    else if (int.Parse(s[5]) == 6) course6++;
                    if (int.Parse(s[6]) >= 18 && int.Parse(s[6]) <= 20)
                        frequencies[int.Parse(s[6]) - 18, int.Parse(s[5]) - 1]++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                    // Выход из Main
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return;
                }
            }
            sr.Close();
            Console.WriteLine("Всего студентов:" + list.Count);
            Console.WriteLine($"Количество студентов 5 курса: {course5}");
            Console.WriteLine($"Количество студентов 6 курса: {course6}");
            list.Sort(new Comparison<Student>(CompareAge));
            Console.WriteLine($"Студенты, отсортированные по возрасту");
            foreach (var v in list) Console.WriteLine(v.firstName+' '+v.age.ToString());
            for (int i = 0; i < frequencies.GetLength(0); i++)
                for (int j = 0; j < frequencies.GetLength(1); j++)
                    if(frequencies[i,j]!=0)
                        Console.WriteLine($"Количество студентов {j + 1} курса возраста {i + 18} лет: {frequencies[i, j]}");

            list.Sort(new Comparison<Student>(CompareCourse));
            Console.WriteLine($"Студенты, отсортированные по курсу и возрасту");
            foreach (var v in list) Console.WriteLine(v.firstName + ' ' + v.age.ToString() + ' ' + v.course.ToString());
            Console.ReadKey();
        }

    }
}
