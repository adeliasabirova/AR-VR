using System;
using System.IO;

namespace Matrix
{
    public class Matrix
    {
        int[,] array;
        int length1;
        int length2;

        public Matrix()
        {
            length1 = 0;
            length2 = 0;
            array = new int[length1, length2];
        }

        public Matrix(string filename)
        {            
            if (File.Exists(filename))
            {
                var readTXT = File.ReadAllLines(filename);
                this.length1 = readTXT.Length;
                this.length2 = readTXT[0].Split(' ').Length;
                this.array = new int[this.length1, this.length2];
                int i = 0;
                foreach (string line in readTXT)
                {
                    string[] elementsInLine = line.Split(' ');
                    for (int j = 0; j < this.length2; j++)
                        this.array[i, j] = Convert.ToInt32(elementsInLine[j]);
                    i++;
                }
            }
            else
            {
                Console.WriteLine("File does not exist.");
            }
        }

        public Matrix(int length1, int length2, int min, int max)
        {
            Random rand = new Random();
            this.length1 = length1;
            this.length2 = length2;
            this.array = new int[length1, length2];
            for (int i = 0; i < this.length1; i++)
                for (int j = 0; j < this.length2; j++)
                    this.array[i, j] = rand.Next(min, max);
        }

        public int SumAll()
        {
            int sum = 0;
            for (int i = 0; i < this.length1; i++)
                for (int j = 0; j < this.length2; j++)
                    sum += this.array[i, j];
            return sum;
        }

        public int SumMoreValue(int value)
        {
            int sum = 0;
            for (int i = 0; i < this.length1; i++)
                for (int j = 0; j < this.length2; j++)
                    if (this.array[i, j] > value)
                        sum += this.array[i, j];
            return sum;
        }

        public int Max
        {
            get
            {
                int max = this.array[0,0];
                for (int i = 0; i < this.length1; i++)
                    for(int j = 0; j< this.length2; j++)
                        if (this.array[i,j] > max) 
                            max = this.array[i,j];
                return max;
            }
        }
        public int Min
        {
            get
            {
                int min = this.array[0,0];
                for (int i = 1; i < this.length1; i++)
                    for (int j = 0; j < this.length2; j++)
                        if (this.array[i,j] < min) 
                            min = this.array[i,j];
                return min;
            }
        }

        public void MaxIndex(ref int index1, ref int index2)
        {
            int max = this.Max;
            for (int i = 1; i < this.length1; i++)
                for (int j = 0; j < this.length2; j++)
                    if (this.array[i, j] == max)
                    {
                        index1 = i;
                        index2 = j;
                        break;
                    }
        }

        public void WriteInFile(string filename)
        {
            if (!File.Exists(filename))
            {
                string text = "";
                for (int i = 0; i < this.length1; i++)
                {
                    for (int j = 0; j < this.length2; j++)
                        text += $"{this.array[i, j]} ";
                    text += "\n";
                }

                File.WriteAllText(filename, text);
            }
            else
            {
                Console.WriteLine($"File \"{filename}\" exists ");
            }
        }
    }
}
