using System;
using System.IO;

namespace Homework
{
    public static class StaticArray
    {
        public static int[] CreateArray(int length)
        {
            Random rand = new Random();
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
                array[i] = rand.Next(-10000, 10000);
            return array;
        }

        public static int CheckThreeArray(int[] array)
        {
            int count = 0;
            int length = array.Length;
            for (int i = 0; i < length - 1; i++)
            {
                if (array[i] % 3 == 0 && array[i + 1] % 3 == 0)
                    continue;
                else if (array[i] % 3 == 0 || array[i + 1] % 3 == 0)
                    count++;
            }
            return count;
        }

        public static int[] ReadArrayFromFile(string filename)
        {
            string[] readTXT;
            if (File.Exists(filename))
            {
                readTXT = File.ReadAllText(filename).Split(" ");
                int length = readTXT.Length;
                int[] array = new int[length];
                for (int i = 0; i < length; i++)
                    array[i] = Convert.ToInt32(readTXT[i]);
                return array;
            }
            else
            {
                Console.WriteLine("File does not exist.");
                return null;
            }
        }
    }
}
