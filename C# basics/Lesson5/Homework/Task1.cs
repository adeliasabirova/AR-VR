using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Homework
{
    //Аделя Сабирова
    static class Task1
    {
        /// <summary>
        /// Создать программу, которая будет проверять корректность ввода логина. 
        /// Корректным логином будет строка от 2 до 10 символов, содержащая только 
        /// буквы латинского алфавита или цифры, при этом цифра не может быть первой.
        /// с использованием регулярных выражений.
        /// </summary>
        /// <param name="filename"> File with list of logins</param>
        public static void TaskReg(string filename)
        {
            Regex reg = new Regex(@"^[a-z][a-z0-9]{1,9}\b");
            foreach(string line in File.ReadLines(filename))
            {
                if (reg.IsMatch(line))
                    Console.WriteLine($"Login {line} is valid");
                else Console.WriteLine($"Login {line} is not valid");
            }
        }

        public static bool IsLatinLetter(char c)
        {
            return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
        }

        /// <summary>
        /// Создать программу, которая будет проверять корректность ввода логина. 
        /// Корректным логином будет строка от 2 до 10 символов, содержащая только 
        /// буквы латинского алфавита или цифры, при этом цифра не может быть первой.
        /// без использования регулярных выражений.
        /// </summary>
        /// <param name="filename"> File with list of logins</param>
        public static void Task(string filename)
        {
            foreach(string line in File.ReadLines(filename))
            {
                if (line.Length >= 2 && line.Length <= 10)
                    if (!char.IsDigit(line[0]))
                        if (line.All(c=> IsLatinLetter(c) || char.IsDigit(c)))
                            Console.WriteLine($"Login {line} is valid");
                        else Console.WriteLine($"Login {line} is not valid");
                    else Console.WriteLine($"Login {line} is not valid");
                else Console.WriteLine($"Login {line} is not valid");
            }
        }
    }
}
