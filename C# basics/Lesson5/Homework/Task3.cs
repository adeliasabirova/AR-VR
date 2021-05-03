using System;
using System.Linq;

namespace Homework
{
    partial class Program
    {
        // Аделя Сабирова
        static class Task3
        {
            /// <summary>
            /// Сравнение двух строк
            /// </summary>
            /// <param name="str1">первая строка</param>
            /// <param name="str2">вторая строка</param>
            /// <returns></returns>
            private static bool IsPermutation(string str1, string str2)
            {
                if (str1.Length != str2.Length)
                    return false;
                char[] char1 = str1.ToCharArray();
                char[] char2 = str2.ToCharArray();
                Array.Sort(char1);
                Array.Sort(char2);
                if (!char1.SequenceEqual(char2))
                    return false;
                //for (int i = 0; i < char1.Length; i++)
                //    if (char1[i] != char2[i])
                //        return false;
                return true;
            }

            /// <summary>
            /// Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой
            /// </summary>
            /// <param name="str1">первая строка</param>
            /// <param name="str2">вторая строка</param>
            public static void Task(string str1, string str2)
            {
                if (IsPermutation(str1, str2))
                    Console.WriteLine($"{str1} is permutation of {str2}");
                else Console.WriteLine($"{str1} is not permutation of {str2}");
            }
        }
    }
}
