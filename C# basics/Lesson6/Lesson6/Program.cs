using System;
using System.IO;

namespace Lesson6
{
    public delegate bool Check(int a1, int a2);
    class Program
    {
        static bool Check1(int a1, int a2)
        {
            return Math.Abs(a1 - a2) >= 8;
        }


        static long FindMaxMult(int[] array, Check check)
        {
            long max = 0;
            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array.Length; j++)
                    if (check(i,j) && (long)array[i] * array[j] > max)
                        max = array[i] * array[j];
            return max;
        }

        static void Task2()
        {
            Random rand = new Random();
            int[] array = new int[100000];
            for (int i = 0; i < 100000; i++)
                array[i] = rand.Next(0, 100000);

            long max = FindMaxMult(array, Check1);
            Console.WriteLine(max);
        }
        static void Save(string fileName, int n)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            uint a0 = 0;                                      
            uint a1 = 1;
            uint a = a1;
            bw.Write(a0);
            bw.Write(a1);
            for (int i = 2; i < n; i++)
            {
                a = a0 + a1;
                bw.Write(a);
                a0 = a1;
                a1 = a;
            }
            fs.Close();
            bw.Close();
        }
        static void Load(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            for (int i = 1; i <= fs.Length / 4; i++) 
            {
                uint a = br.ReadUInt32();
                if (i % 3 == 0) Console.WriteLine("{0,3} {1}", i, a);
            }
            br.Close();
            fs.Close();
        }

        static void Task1()
        {
            Save("data.bin", 33);
            Load("data.bin");
            Console.ReadKey();
        }

        static void Task_3()
        {
            Task3.SaveFunc("data.bin", -100, 100, 0.5);
            Console.WriteLine(Task3.Load("data.bin"));
        }


        static int Compare(int a, int b)
        {
            if (a % 10 > b % 10) return 1;
            if (a % 10 < b % 10) return -1;
            return 0;
        }
        static void Task4()
        {
            Random rand = new Random();
            int[] array = new int[25];
            for (int i = 0; i < 25; i++)
                array[i] = rand.Next(0, 50);

            Array.Sort(array, Compare);
            foreach (var element in array)
            {
                Console.Write("{0,4}", element);
            }

        }


        static void Main(string[] args)
        {
            Task4();
        }
    }
}
