using System;

namespace Homework
{
    class Program
    {
        static void Task1()
        {
            //Аделя Сабирова
            //а) Дописать структуру Complex, добавив метод вычитания комплексных чисел. Продемонстрировать работу структуры.
            //б) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса.
            //в) Добавить диалог с использованием switch демонстрирующий работу класса.
            Console.WriteLine(@"This is a Complex Number Class performnance.
Choose what feature you want to test:
1 - create a complex number (do before 4, 5, 6 step, otherwise complex numbers will be with default values)
2 - print a complex number into a console
3 - set current complex number with different values
4 - sum two complex numbers
5 - multiply two complex numbers
6 - substract two complex numbers
0 - quite
");
            int x;
            Complex z = new Complex(), new_z = new Complex();
            double Re = 0, Im = 0;
            do
            {
                x = int.Parse(Console.ReadLine());
                switch (x)
                {
                    case 1:
                        Console.WriteLine("Do you want to add numbers for real and imagenary part of complex number: Y or N");
                        string str = Console.ReadLine();
                        if (str == "Y")
                        {
                            Console.Write("Re: ");
                            Re = double.Parse(Console.ReadLine());
                            Console.Write("Im: ");
                            Im = double.Parse(Console.ReadLine());
                            z = new Complex(Re, Im);
                        }
                        else if (str == "N")
                            continue;
                        else
                        {
                            Console.WriteLine("Wrong inputed character. Quit");
                            x = 0;
                        }                        
                        break;
                    case 2:
                        Console.WriteLine($"Current complex number is z = {z.ToString()}");
                        break;
                    case 3:
                        Console.Write("Re: ");
                        Re = double.Parse(Console.ReadLine());
                        Console.Write("Im: ");
                        Im = double.Parse(Console.ReadLine());
                        z.setValue(Re, Im);
                        break;
                    case 4:
                        Console.WriteLine("Add numbers to create second complex number");
                        Console.Write("Re: ");
                        Re = double.Parse(Console.ReadLine());
                        Console.Write("Im: ");
                        Im = double.Parse(Console.ReadLine());
                        new_z.setValue(Re, Im);
                        Console.WriteLine($"Sum of z1 = {z.ToString()} and z2 = {new_z.ToString()} is z = {(z + new_z).ToString()}");
                        break;
                    case 5:
                        Console.WriteLine("Add numbers to create second complex number");
                        Console.Write("Re: ");
                        Re = double.Parse(Console.ReadLine());
                        Console.Write("Im: ");
                        Im = double.Parse(Console.ReadLine());
                        new_z.setValue(Re, Im);
                        Console.WriteLine($"Multiplication of z1 = {z.ToString()} and z2 = {new_z.ToString()} is z = {(z * new_z).ToString()}");
                        break;
                    case 6:
                        Console.WriteLine("Add numbers to create second complex number");
                        Console.Write("Re: ");
                        Re = double.Parse(Console.ReadLine());
                        Console.Write("Im: ");
                        Im = double.Parse(Console.ReadLine());
                        new_z.setValue(Re, Im);
                        Console.WriteLine($"difference of z1 = {z.ToString()} and z2 = {new_z.ToString()} is z = {(z - new_z).ToString()}");
                        break;
                }
            } while (x != 0);
        }


        static bool IsOdd(int a)
        {
            return a % 2 == 0;
        }

        static void Task2()
        {
            //Аделя Сабирова
            //С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке). 
            //Требуется подсчитать сумму всех нечётных положительных чисел. 
            //Сами числа и сумму вывести на экран, используя tryParse.
            Console.Write("Enter the integer: ");
            int x, sum = 0;
            bool f;
            do {
                f = int.TryParse(Console.ReadLine(), out x);
                if (f && !IsOdd(x) && x != 0)
                {
                    if(x > 0)
                        sum += x;
                }
                else if (!f) Console.WriteLine($"Inputed characters is not an integer. Quit.");
            } while (x != 0);
            Console.WriteLine($"The sum of inputed odd integers above zero is {sum}");
        }

        static void Task3()
        {
            //Аделя Сабирова
            //*Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел. 
            //Предусмотреть методы сложения, вычитания, умножения и деления дробей. 
            //Написать программу, демонстрирующую все разработанные элементы класса.
            //*Добавить свойства типа int для доступа к числителю и знаменателю;
            //*Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
            //**Добавить проверку, чтобы знаменатель не равнялся 0.Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");
            //***Добавить упрощение дробей.
            Console.WriteLine(@"This is a Fraction Class performnance.
Choose what feature you want to test:
1 - create a fraction number (do before 6, 7, 8, 9 step, otherwise complex numbers will be with default values)
2 - print a fraction number into a console
3 - set current fraction number with different values
4 - set numerator for current number
5 - set denomenator for current number
6 - sum two fraction numbers
7 - multiply two fraction numbers
8 - substract two fraction numbers
9 - divide two fraction numbers
0 - quite
");
            int x;
            Fraction z, new_z;
            z = new Fraction();
            int n = 0, d = 0;
            do
            {
                x = int.Parse(Console.ReadLine());
                switch (x)
                {
                    case 1:
                        Console.WriteLine("Do you want to add numbers for numerator and denomenator of fraction number: Y or N");
                        string str = Console.ReadLine();
                        if (str == "Y")
                        {
                            Console.Write("Numerator: ");
                            n = int.Parse(Console.ReadLine());
                            Console.Write("Denomenator: ");
                            d = int.Parse(Console.ReadLine());
                            try
                            {
                                z = new Fraction(n, d);
                            }
                            catch (ArgumentException e)
                            {
                                Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
                            }
                        }
                        else if (str == "N")
                            continue;
                        else
                        {
                            Console.WriteLine("Wrong inputed character. Quit");
                            x = 0;
                        }
                        break;
                    case 2:
                        Console.WriteLine($"Current fraction number is z = {z.ToString()}");
                        break;
                    case 3:
                        z = new Fraction();
                        Console.Write("Numerator: ");
                        n = int.Parse(Console.ReadLine());
                        Console.Write("Denomenator: ");
                        d = int.Parse(Console.ReadLine());
                        try
                        {
                            z.setFraction(n, d);
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
                        }
                        break;
                    case 4:
                        Console.Write("Numerator: ");
                        n = int.Parse(Console.ReadLine());
                        z.setNumerator(n);
                        break;
                    case 5:
                        Console.Write("Denomenator: ");
                        d = int.Parse(Console.ReadLine());
                        z.setDenomenator(d);
                        break;
                    case 6:
                        Console.WriteLine("Add numbers to create second fraction number");
                        Console.Write("Numerator: ");
                        n = int.Parse(Console.ReadLine());
                        Console.Write("Denomenator: ");
                        d = int.Parse(Console.ReadLine());
                        new_z = new Fraction(n, d);
                        Console.WriteLine($"Sum of z1 = {z.ToString()} and z2 = {new_z.ToString()} is z = {(z + new_z).ToString()}");
                        break;
                    case 7:
                        Console.WriteLine("Add numbers to create second fraction number");
                        Console.Write("Numerator: ");
                        n = int.Parse(Console.ReadLine());
                        Console.Write("Denomenator: ");
                        d = int.Parse(Console.ReadLine());
                        new_z = new Fraction(n, d);
                        Console.WriteLine($"Multiplication of z1 = {z.ToString()} and z2 = {new_z.ToString()} is z = {(z * new_z).ToString()}");
                        break;
                    case 8:
                        Console.WriteLine("Add numbers to create second fraction number");
                        Console.Write("Numerator: ");
                        n = int.Parse(Console.ReadLine());
                        Console.Write("Denomenator: ");
                        d = int.Parse(Console.ReadLine());
                        new_z = new Fraction(n, d);
                        Console.WriteLine($"Difference of z1 = {z.ToString()} and z2 = {new_z.ToString()} is z = {(z - new_z).ToString()}");
                        break;
                    case 9:
                        Console.WriteLine("Add numbers to create second fraction number");
                        Console.Write("Numerator: ");
                        n = int.Parse(Console.ReadLine());
                        Console.Write("Denomenator: ");
                        d = int.Parse(Console.ReadLine());
                        new_z = new Fraction(n, d);
                        Console.WriteLine($"Division of z1 = {z.ToString()} and z2 = {new_z.ToString()} is z = {(z / new_z).ToString()}");
                        break;
                    default:
                        break;
                }
            } while (x != 0);
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Choose task to check: 1, 2, 3");
            int task = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"You are checking {task} task.");
            switch (task)
            {
                case 1:
                    Task1();
                    break;
                case 2:
                    Task2();
                    break;
                case 3:
                    Task3();
                    break;
                default:
                    break;
            }
            Console.ReadKey();
        }
    }
}
