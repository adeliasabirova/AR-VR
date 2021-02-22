using System;

namespace Homework
{
    class Program
    {
        static double Min(double a, double b)
        {
            return a < b ? a : b;
        }

        static double Min(double a, double b, double c)
        {
            if (c > a && c > b) return Min(a,b);
            else if (a > b) return Min(c,b);
            else if (b > a) return Min(c,a);
            else return c;
        }

        static void Task1()
        {
            //Аделя Сабирова
            //Написать метод, возвращающий минимальное из трёх чисел.
            Console.Write("Enter the first number: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the second number: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the third number: ");
            double c = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"The minimum of the entered numbers is {Min(a, b, c)}");
        }

        static void Task2()
        {
            //Аделя Сабирова
            //Написать метод подсчета количества цифр числа.
            Console.Write("Enter integer: ");
            int x = Convert.ToInt32(Console.ReadLine());
            int y = x;
            int count = 0;
            if (x == 0)
                count++;
            while (x > 0)
            {
                x /= 10;
                count++;
            }
            Console.WriteLine($"{y} has {count} number(s)");
        }

        static bool IsOdd(int a)
        {
            return a % 2 == 0;
        }

        static void Task3()
        {
            //Аделя Сабирова
            //С клавиатуры вводятся числа, пока не будет введен 0. 
            //Подсчитать сумму всех нечетных положительных чисел.
            Console.Write("Enter the integer: ");
            int x = int.Parse(Console.ReadLine());
            int sum = 0;
            while (x != 0)
            {
                if (!IsOdd(x) && x > 0)
                {
                    sum += x;
                }
                x = int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"The sum of inputed odd integers above zero is {sum}");
        }

        static bool IsEntered(string loginEntered, string passwordEntered)
        {
            string login = "root";
            string password = "GeekBrains";
            bool bLogin = String.Equals(loginEntered, login);
            bool bPassword = String.Equals(passwordEntered, password);
            if (bLogin && bPassword)
                return true;
            else
                return false;
        }

        static void Task4()
        {
            //Аделя Сабирова
            //Реализовать метод проверки логина и пароля. 
            //На вход метода подается логин и пароль. 
            //На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). 
            //Используя метод проверки логина и пароля, написать программу: 
            //пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает. 
            //С помощью цикла do while ограничить ввод пароля тремя попытками.
            int count = 0;
            do
            {
                count++;
                Console.Write("Login: ");
                string login = Console.ReadLine();
                Console.Write("password: ");
                string password = Console.ReadLine();

                if (IsEntered(login, password))
                {
                    Console.WriteLine("Login and password are correct.");
                    break;
                }
                else if (count == 3) Console.WriteLine($@"Login and password are incorrect. 
Your account is blocked. 
Please, write to admin.");
                else Console.WriteLine($@"Login and password are incorrect. 
Please write again. 
You have {(3-count)} attempt(s)");

            } while (count < 3);
        }

        static double BMI(double weight, double height)
        {
            return weight / Math.Pow(height, 2);
        }

        static (bool, bool) CheckBMI(double bmi)
        {
            if (18.5 <= bmi && bmi <= 24)
                return (true, true);
            else if (bmi <= 18.5)
                return (false, true);
            else return (false, false);
        }

        static double Weight(double bmi, double height, bool b)
        {
            if (b)
                return (18.5 - bmi) * Math.Pow(height, 2);
            else
                return (bmi - 24) * Math.Pow(height, 2);
        }

        static void Task5()
        {
            //Аделя Сабирова
            //а) Написать программу, которая запрашивает массу и рост человека, 
            //вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.
            //б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
            Console.Write("Enter a height in cm: ");
            double height = 0.01*Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter a weight in kg: ");
            double weight = Convert.ToDouble(Console.ReadLine());
            double bmi = BMI(weight, height);
            (bool b1, bool b2) check = CheckBMI(bmi);
            if (check.b1)
                Console.WriteLine("Your weight is in normal range.");
            else if (check.b2)
                Console.WriteLine($@"Your weight is in underweight range. 
You should gain {(int)Weight(bmi,height,check.b2)} kg");
            else Console.WriteLine($@"Your weight is in overweight range.
You should lose {(int)Weight(bmi, height, check.b2)} kg");
        }

        

        static int Sum(int a)
        {
            if (a == 0) return 0;
            else return a % 10 + Sum(a / 10);

        }

        static bool IsEnumerable(int a)
        {
            if (a % Sum(a) == 0) return true;
            else return false;
        }

        static int EnumerationLoop(int a)
        {
            if (a == 10000) return 1;
            else if (IsEnumerable(a)) return 1 + EnumerationLoop(a + 1);
            else return EnumerationLoop(a + 1);
        }

        static void Task6()
        {
            //Аделя Сабирова
            // Не работает, начиная с 100000, ошибка StackOverflow, рекурсией не получается.
            // НУЖНО ПЕРЕДЕЛАТЬ.
            //Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000. 
            //«Хорошим» называется число, которое делится на сумму своих цифр.
            //Реализовать подсчёт времени выполнения программы, используя структуру DateTime.
            DateTime start = DateTime.Now;
            Console.WriteLine($"The \"Good numbers\" in range (1 - 10000) is {EnumerationLoop(1)}");
            Console.WriteLine($"To check and count \"Good numbers\" the program spent {(DateTime.Now - start)}.");
        }

        static int EnumerationFromAToBLoop(int a, int b)
        {
            Console.Write($"{a} ");
            if (a < b) return a + EnumerationFromAToBLoop(a + 1, b);
            else return b;
        }

        static void Task7()
        {
            //Аделя Сабирова
            //a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
            //б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.
            Console.Write("Enter the first integer, it should be less than second one: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter the second integer: ");
            int b = int.Parse(Console.ReadLine());
            int sum = EnumerationFromAToBLoop(a, b);
            Console.WriteLine($"\nThe sum of entered integers is {sum}");
        }



        static void Main(string[] args)
        {
            Console.WriteLine("Choose task to check: 1, 2, 3, 4, 5, 7");
            int task = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"You are checking {task} task.");
            switch (task)
            {
                case 1: Task1();
                    break;
                case 2: Task2();
                    break;
                case 3: Task3();
                    break;
                case 4: Task4();
                    break;
                case 5: Task5();
                    break;
                //case 6: Task6();
                //    break;
                case 7: Task7();
                    break;
            }
            Console.ReadKey();
        }
    }
}
