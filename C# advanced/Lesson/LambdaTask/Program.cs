using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaTask
{
    class Program
    {
        public static void Task2()
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 18, 1, 2, 1, -1, 1, 4, 4, 5});

            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i=0; i< list.Count; i++)
            {
                if (dict.ContainsKey(list[i]))
                    dict[list[i]]++;
                else
                    dict.Add(list[i], 1);
            }

            foreach (var pair in dict)
                Console.WriteLine($"{pair.Key} - {pair.Value}");

            Console.WriteLine();

            foreach (var value in list.Distinct())
                Console.WriteLine($"{value} - {list.Where(x => x == value).Count()}");
        }
        public static void Task3()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four",4 },
                {"two",2 },
                { "one",1 },
                {"three",3 },
            };
            Console.WriteLine("Сортировка с использованием делегата");
            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }

            Console.WriteLine("Сортировка с использованием лямбда выражения");
            var sortDict = dict.OrderBy(pair => pair.Value);
            foreach (var pair in d)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
        }
        static void Main(string[] args)
        {
            Task2();
            //Task3();
            Console.ReadKey();
        }
    }
}
