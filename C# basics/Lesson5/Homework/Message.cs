using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Homework
{
    // Аделя Сабирова
    partial class Program
    {
        static class Message
        {
            /// <summary>
            /// Ковертация введенного текста
            /// </summary>
            /// <param name="filename">file name for input</param>
            /// <returns></returns>
            public static string[] ConvertMessageToString(string filename)
            {
                string text = File.ReadAllText(filename);
                StringBuilder message = new StringBuilder(text);
                for (int i = 0; i < message.Length;)
                    if (char.IsPunctuation(message[i]))
                        message.Remove(i, 1);
                    else
                        ++i;

                string[] textstr = message.ToString().Split(' ');

                return textstr;
            }

            /// <summary>
            ///  Вывести только те слова сообщения,  которые содержат не более n букв.
            /// </summary>
            /// <param name="text">array of text words</param>
            /// <param name="n">length of word</param>
            /// <returns></returns>
            public static StringBuilder OutputLessN(string[] text, int n)
            {
                StringBuilder message = new StringBuilder();
                foreach (string word in text)
                {
                    if (word.Length <= n)
                        message.Append(word + ' ');
                }
                return message;
            }

            /// <summary>
            /// Удалить из сообщения все слова, которые заканчиваются на заданный символ.
            /// </summary>
            /// <param name="text">array of text words</param>
            /// <param name="c">specific char</param>
            /// <returns></returns>
            public static StringBuilder RemoveWordsOnChar(string[] text, char c)
            {
                StringBuilder newText = new StringBuilder();
                foreach (string word in text)
                {
                    if (!word.EndsWith(c))
                        newText.Append( word + ' ');
                }
                return newText;
            }

            /// <summary>
            /// Найти самое длинное слово сообщения.
            /// </summary>
            /// <param name="text">array of text words</param>
            /// <returns></returns>
            public static (string, int) FindLongWord(string[] text)
            {
                int max = 0;
                
                string longWord = " ";
                foreach (string word in text)
                    if (word.Length > max)
                    {
                        max = word.Length;
                        longWord = word;
                    }
                return (longWord, max);
            }


            /// <summary>
            /// Найти все длинные слова
            /// </summary>
            /// <param name="text">array of text words</param>
            /// <returns></returns>
            public static List<string> FindLongWords(string[] text)
            {
                List<string> longWords = new List<string>();
                (string word, int max) longword = FindLongWord(text);
                foreach (string word in text)
                    if (word.Length == longword.max)
                    {
                        longWords.Add(word);
                    }
                return longWords;
            }

            /// <summary>
            /// Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
            /// </summary>
            /// <param name="text">array of text words</param>
            /// <returns></returns>
            public static StringBuilder CreateLongWordsString(string[] text)
            {
                StringBuilder message = new StringBuilder();
                List<string> longWords = FindLongWords(text);
                foreach (string word in longWords)
                    message.Append(word + " ");
                return message;
            }

            /// <summary>
            /// Создать метод, который производит частотный анализ текста. 
            /// В качестве параметра в него передается массив слов и текст, 
            /// в качестве результата метод возвращает сколько раз каждое из 
            /// слов массива входит в этот текст. Здесь требуется использовать класс Dictionary.
            /// </summary>
            /// <param name="text">array of text words</param>
            /// <param name="array">array of words to find entries in text</param>
            public static void Dictionary(string[] text, string[] array)
            {
                Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
                for (int i = 0; i < array.Length; i++)
                {
                    int count = 0;
                    for (int j = 0; j < text.Length; j++)
                        if (array[i] == text[j])
                            count++;
                    keyValuePairs.Add(array[i], count);
                }

                foreach (KeyValuePair<string, int> keys in keyValuePairs)
                    Console.WriteLine($"Word {keys.Key} has {keys.Value} entries");
            }
        }
    }
}
