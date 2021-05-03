using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Lesson
{
    class Program
    {

        static void Task1()
        {
            //Дана строка, в которой содержится осмысленное текстовое сообщение. 
            //Слова сообщения разделяются пробелами и знаками препинания. 
            //Вывести все слова сообщения, которые начинаются и заканчиваются на одну и ту же букву.
            string text = @"One morning, when Gregor Samsa woke from troubled dreams, 
he found himself transformed in his bed into a horrible vermin. 
He lay on his armour-like back, and if he lifted his head a little he could see his brown belly, 
slightly domed and divided by arches into stiff sections. 
The bedding was hardly able to cover it and seemed ready to slide off any moment. 
His many legs, pitifully thin compared with the size of the rest of him, waved about helplessly as he looked.";
            StringBuilder message = new StringBuilder(text);
            for (int i = 0; i < message.Length;)
                if (char.IsPunctuation(message[i])) 
                    message.Remove(i, 1);
                else 
                    ++i;

            string[] str = message.ToString().Split(' ');
            for (int i = 0; i < str.Length; ++i)
                if (str[i][0] == str[i][str[i].Length - 1]) 
                    Console.WriteLine(str[i]);
        }

        static void Task2()
        {
            //На вход программы подаются произвольные алфавитно-цифровые символы. Ввод этих символов заканчивается точкой.
            //Требуется написать программу, которая будет печатать последовательность строчных английских букв('a' 'b'... 'z') 
            //из входной последовательности и частот их повторения.
            int value;
            string str = "fhb5kbfshfm.";
            Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();
            for(int i = 0; i < str.Length; i++)
            {
                if (str[i] != '.')
                    if (str[i]>='a' && str[i]<='z')
                        if (!keyValuePairs.TryGetValue(str[i], out value))
                            keyValuePairs.Add(str[i], 1);
                        else
                            keyValuePairs[str[i]] = value + 1;
            }
            foreach (KeyValuePair<char, int> keys in keyValuePairs)
                Console.WriteLine($"Element {keys.Key} has {keys.Value} entries");
        }

        struct Info
        {
            public string name;
            public string surname;
            public int count;
        }


        static void Task3(string filename)
        {
            //На вход программы подаются фамилии и имена учеников. Известно, что общее количество учеников не превосходит 100.
            //В первой строке вводится количество учеников, принимавших участие в соревнованиях, N.Далее следует N строк, имеющих следующий формат: 
            //{ Фамилия}  { Имя}
            // Здесь { Фамилия} — строка, состоящая не более чем из 20 символов;
            //{ Имя} — строка, состоящая не более чем из 15 символов.При этом { Фамилия}
            //и { Имя}
            //разделены одним пробелом.

            Info[] info = new Info[100];
            string[] lines = File.ReadAllText(filename).Split("\r\n");
            
            for(int i=0; i< lines.Length; i++)
            {
                int count = 1;
                for (int j = 0; j < i; j++)
                    if (lines[i].Split(' ')[0] == info[j].surname)
                        count++;
                info[i].surname = lines[i].Split(' ')[0];
                info[i].name = lines[i].Split(' ')[1];
                info[i].count = count;
            }

            for(int i=0; i < lines.Length; i++)
            {
                Console.Write($"Participant: {info[i].surname} {info[i].name}, login: {info[i].surname}");
                if (info[i].count > 1)
                    Console.Write(info[i].count);
                Console.WriteLine();
            }

        }

        struct Element
        {
            public string name;
            public int number;
        }

        static void Task4(string filename)
        {
            int n = int.Parse(File.ReadLines(filename).First());
            Element[] elements = new Element[n];
            for(int i=0; i<n; i++)
            {
                string[] str = File.ReadLines(filename).ElementAtOrDefault(i + 1).Split(' ');
                elements[i].name = str[0] + str[1];
                elements[i].number = int.Parse(str[2]);
            }
            int[] massiv = new int[100];
            for (int i = 0; i < n; i++) 
                massiv[elements[i].number]++;

            int min = massiv.Where(x => x != 0).Min();

            var indexes = massiv.Select((v, i) => new { v, i }).Where(x => x.v == min).Select(x => x.i);
            foreach(int index in indexes)
                Console.WriteLine($"{index}");
        }

        struct Tag
        {
            public string tag;
            public string str;
            public Tag(string tag, string str)
            {
                this.tag = tag;
                this.str = str;
            }
        }

        static void Task6(string filename)
        {
            string str = File.ReadAllText(filename);
            Tag[] tags = new Tag[8]
            {
                new Tag("name1","ООО 'Дружба'"),
                new Tag("name2","Иванову И.И."),
                new Tag("name3","менеджера по продажам"),
                new Tag("name4","Сидорова А.А."),
                new Tag("name5","Сидоров А.А."),
                new Tag("data1","01.06.16"),
                new Tag("data2","14.06.16"),
                new Tag("data3","20.04.16"),
            };

            foreach (var tag in tags)
            {
                Regex reg = new Regex("<" + tag.tag + ">");
                str = reg.Replace(str, tag.str);
            }

            Console.WriteLine(str);
        }

        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3("C:/Users/adely/source/repos/AR-VR/C# basics/Lesson5/Lesson/Task3.txt");
            Task4("C:/Users/adely/source/repos/AR-VR/C# basics/Lesson5/Lesson/Task4.txt");
            Task6("C:/Users/adely/source/repos/AR-VR/C# basics/Lesson5/Lesson/Task6.txt");
            Console.ReadKey();
        }
    }
}
