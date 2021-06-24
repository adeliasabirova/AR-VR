using System;

namespace Homework1
{
    class MathProgram
    {
        private int number;
        public bool _IsInt { get; private set; }

        public MathProgram()
        {
            number = 0;
            _IsInt = true;
        }

        public MathProgram(string number)
        {
            _IsInt = Int32.TryParse(number, out this.number);
        }

        public long Factorial() 
        {
            long factorial = 1;
            for (int i = 1; i <= number; i++)
                factorial *= i;
            return factorial;
        }

        public int SumFrom1toNumber()
        {
            int summa = 0;
            for (int i = 1; i <= number; i++)
                summa += i;
            return summa;
        }

        public int MaxEvenNumber()
        {
            int max = 0;
            for (int i = 1; i <= number; i++)
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

            if (mathProgram._IsInt)
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
