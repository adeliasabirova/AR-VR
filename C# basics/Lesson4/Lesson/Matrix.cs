using System;

namespace Lesson
{
    class Matrix
    {
        int[,] a; 
        int[] Rows;   
        public Matrix(int n, int m)
        {
            a = new int[n, m];
            Random rnd = new Random();
            Rows = new int[n];
            for (int i = 0; i < n; i++)
            {
                int s = 0;
                for (int j = 0; j < m; j++)
                {
                    a[i, j] = rnd.Next(0, 10);
                    s += a[i, j];
                }
                Rows[i] = s;
            }
        }

        public void Print()
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    Console.Write("{0,4}", a[i, j]);
                Console.WriteLine();
            }
        }

        public int Search(out int count)
        {
            int min = int.MaxValue;
            count = 0;         
            foreach (int e in Rows)
            {
                if (e < min) min = e;
            }
            foreach (int e in Rows)
            {
                if (e == min) count++;
            }
            return min;
        }
        public void SearchRows()
        {
            int countRow;
            int min = Search(out countRow); ;
            for (int i = 0; i < Rows.Length; i++)
            {
                if (Rows[i] == min)
                {
                    Console.WriteLine("\n{0} {1}", i, Rows[i]);
                }
            }
        }
    }
}
