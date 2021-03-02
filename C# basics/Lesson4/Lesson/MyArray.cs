using System;
using System.Collections.Generic;
using System.Linq;


namespace Lesson
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
            public MyArray(int length, int min, int max)
            {
                this.array = new int[length];
                Random rand = new Random();
                for (int i = 0; i < length; i++)
                    this.array[i] = rand.Next(min, max);

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

            public override string ToString()
            {
                string s = "";
                foreach (int v in this.array)
                    s = s + v + " ";
                return s;
            }
        }
}


