using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework
{
    class MyArray
    {
        int[] array;
        public MyArray(int length, int el)
        {
            this.array = new int[length];
            for (int i = 0; i < length; i++)
                this.array[i] = el;
        }
        public MyArray(int length, int min, int max, bool random)
        {
            this.array = new int[length];
            Random rand = new Random();
            for (int i = 0; i < length; i++)
                this.array[i] = rand.Next(min, max);
            
        }
        public MyArray(int length, int start, int step)
        {
            this.array = new int[length];
            for (int i = 0; i < length; i++)
                this.array[i] = start + i*step;
        }
        public int Max
        {
            get
            {
                int max = this.array[0];
                for (int i = 1; i < this.array.Length; i++)
                    if (this.array[i] > max) max = this.array[i];
                return max;
            }
        }
        public int Min
        {
            get
            {
                int min = this.array[0];
                for (int i = 1; i < this.array.Length; i++)
                    if (this.array[i] < min) min = this.array[i];
                return min;
            }
        }
        public int CountPositiv
        {
            get
            {
                int count = 0;
                for (int i = 0; i < this.array.Length; i++)
                    if (this.array[i] > 0) count++;
                return count;
            }
        }

        public int Sum
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < this.array.Length; i++)
                    sum += this.array[i];
                return sum;
            }
        }

        public int[] Inverse()
        {
            int length = this.array.Length;
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
                array[i] = -1 * this.array[i];
            return array;
        }

        public int[] Multi(int value)
        {
            int length = this.array.Length;
            for (int i = 0; i < length; i++)
                this.array[i] = value * this.array[i];
            return this.array;
        }

        public int MaxCount
        {
            get
            {
                int count = 0;
                int max = this.Max;
                for (int i =0; i<this.array.Length; i++)
                    if (this.array[i] == max)
                        count++;
                return count;
            }
        }

        public override string ToString()
        {
            string s = "";
            foreach (int v in this.array)
                s = s + v + " ";
            return s;
        }

        public Dictionary<int,int> CountElements()
        {
            int length = this.array.Length;
            Dictionary<int, int> keyValues = new Dictionary<int, int>();
            var uniqueItems = this.array.Distinct<int>().ToArray();
            for (int i = 0; i<uniqueItems.Length; i++)
            {
                int count = 0;
                int element = uniqueItems[i];
                for (int j = 0; j < length; j++)
                    if (element == this.array[j])
                        count++;
                keyValues.Add(element, count);
            }
            return keyValues;
        }
    }
}
