using System;
using System.IO;
using System.Linq;

namespace Homework
{
    partial class Program
    {
        static class Task4
        {
            struct Element
            {
                public string name;
                public double averageScore;
            }
            /// <summary>
            /// На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы. 
            /// В первой строке сообщается количество учеников N, которое не меньше 10, 
            /// но не превосходит 100, каждая из следующих N строк имеет следующий формат:
            /// Фамилия Имя оценки,
            ///где Фамилия — строка, состоящая не более чем из 20 символов, 
            ///Имя — строка, состоящая не более чем из 15 символов, 
            ///оценки — через пробел три целых числа, соответствующие оценкам по пятибалльной системе. 
            ///Фамилия и Имя, а также Имя и оценки разделены одним пробелом. 
            ///Пример входной строки: Иванов Петр 4 5 3
            ///Требуется написать как можно более эффективную программу, 
            ///которая будет выводить на экран фамилии и имена трёх худших по среднему баллу учеников. 
            ///Если среди остальных есть ученики, набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.
            /// </summary>
            /// <param name="filename">File with the data</param>
            public static void Task(string filename)
            {
                int n = int.Parse(File.ReadLines(filename).First());
                Element[] elements = new Element[n];
                for (int i = 0; i < n; i++)
                {
                    string[] str = File.ReadLines(filename).ElementAtOrDefault(i + 1).Split(' ');
                    elements[i].name = str[0] + ' ' + str[1];
                    elements[i].averageScore = (double)(int.Parse(str[2])+int.Parse(str[3]) + int.Parse(str[4]))/3;
                }
                Array.Sort<Element>(elements, (x, y) => x.averageScore.CompareTo(y.averageScore));
                int count = 1;
                double min = elements[0].averageScore;
                for (int i=0; i<elements.Length; i++)
                {
                    if (count == 3)
                        break;
                    else if (elements[i].averageScore == min)
                            Console.WriteLine(elements[i].name);
                        else if (elements[i].averageScore >min && count < 3)
                        {
                            min = elements[i].averageScore;
                            Console.WriteLine(elements[i].name);
                            count++;
                        }
                }
            }
        }
    }
}
