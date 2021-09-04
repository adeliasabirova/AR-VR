using System;
using System.Numerics;

namespace Homework1
{
    class MathProgram
    {
        private int _number;
        public bool IsInt { get; private set; }

        public MathProgram()
        {
            _number = 0;
            IsInt = true;
        }

        public MathProgram(string number)
        {
            IsInt = Int32.TryParse(number, out _number);
        }

        public BigInteger Factorial() 
        {
            BigInteger factorial = 1;
            for (int i = 1; i <= _number; i++)
                factorial *= i;
            return factorial;
        }

        public BigInteger SumFrom1toNumber()
        {
            BigInteger summa = 0;
            for (int i = 1; i <= _number; i++)
                summa += i;
            return summa;
        }

        public BigInteger MaxEvenNumber()
        {
            BigInteger max = 0;
            for (int i = 1; i <= _number; i++)
                if(i%2 == 0)
                    max = i;
            return max;
        }
    }

    static class Manager
    { 
        public static void Execution()
        {
            Console.WriteLine("Здравствуйте, вас приветствует математическая программа");
            Console.WriteLine("Пожалуйста введите натуральное число или q для выхода. ");

            String number = Console.ReadLine();

            if (number == "q")
                return;

            MathProgram mathProgram = new MathProgram(number);

            if (mathProgram.IsInt)
            {
                Console.WriteLine($"Факториал равен {mathProgram.Factorial()}");
                Console.WriteLine($"Сума от 1 до N равна {mathProgram.SumFrom1toNumber()}");
                Console.WriteLine($"Максимальное четное число меньше или равен N равно {mathProgram.MaxEvenNumber()}");
            }
            else
            {
                Console.WriteLine($"Введеное значение не является натуральным числом");
            }
            Console.ReadLine();
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            Manager.Execution();
        }
    }
}
