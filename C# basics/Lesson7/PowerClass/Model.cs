using System;
using System.Collections.Generic;

namespace PowerClass
{
    public delegate string cancelFun();
    public class Model
    {
        int a; //число
        int count; //количнство ходов
        int goal; //цель
        Stack<cancelFun> cancelFunctions = new Stack<cancelFun>(); 

        public string S { get; set; }
        public string Goal => $"Goal:\n{goal.ToString()}";
        public string Reset() //функция сброса
        {
            count = 0;
            a = 0;
            return "0"; 
        }
        public string Plus1() //функция добавления единички к числу
        {
            count++;
            cancelFunctions.Push(new cancelFun(Minus1));
            a += 1;
            return a.ToString();
        }
        public string Minus1() //функция вычитания единички, необходима для отмены
        {
            count--;
            a -= 1;
            return a.ToString();
        }
        public string X2() //функци умножения на 2
        {
            count++;
            cancelFunctions.Push(new cancelFun(Del2));
            a *= 2;
            return a.ToString();
        }
        public string Del2() //функция деления на два, необхоима для отмены
        {
            count--;
            a /= 2;
            return a.ToString();
        }
        private bool CheckGoal() => a == goal && goal != 0; //функция проверки достижения цели

        /// <summary>
        /// а) Добавить в программу «Удвоитель» подсчёт количества отданных команд удвоителю.
        /// </summary>
        /// <returns></returns>
        public string ShowCount() => CheckGoal() ? $"Goal is reached! \n{count} attempt(s)" : $"{count} attempt(s)";

        public void Play() //функция создания цели
        {
            Random random = new Random();
            goal = random.Next(1, 100);
        }

        public string Cancel() //функция отмены предыдущих шагов
        {
            cancelFun fun;
            if (cancelFunctions.Count != 0)
            {
                fun = cancelFunctions.Pop();
                return fun();
            }
            return "Error";
        }

    }
}
