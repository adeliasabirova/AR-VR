using System;
using System.Text;

namespace Homework
{
    partial class Program
    {
        //Аделя Сабирова
        static class Task2
        {
            /// <summary>
            /// Разработать статический класс Message, содержащий следующие статические методы для обработки текста.
            /// </summary>
            /// <param name="filename"> File with message</param>
            public static void Task(string filename)
            {
                string[] message = Message.ConvertMessageToString(filename);
                string[] array = new string[5]
                {
                    "Quick",
                    "bag",
                    "MTV",
                    "zippers",
                    "fox",
                };

                //пункт а) 
                StringBuilder newMessage = Message.OutputLessN(message, 5);
                Console.WriteLine(newMessage);
                Console.WriteLine();

                //пункт б)
                StringBuilder newText = Message.RemoveWordsOnChar(message, 'a');
                Console.WriteLine(newText);
                Console.WriteLine();

                //пункт в)
                (string, int) longWord = Message.FindLongWord(message);
                Console.WriteLine($"Max length {longWord.Item2} of word {longWord.Item1}");
                Console.WriteLine();

                //пункт г)
                Console.WriteLine(Message.CreateLongWordsString(message));
                Console.WriteLine();

                //пункт д)
                Message.Dictionary(message,array);
            }
        }
    }
}
