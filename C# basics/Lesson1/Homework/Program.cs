using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    public class Task6
    {

        public Task6() { }

        public void Print(string msg, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(msg);
        }

        public void Print(string msg, ConsoleColor foregroundcolor)
        {
            Console.ForegroundColor = foregroundcolor;
            Console.WriteLine(msg);
        }
        public void Print(string msg, int x, int y, ConsoleColor foregroundcolor)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = foregroundcolor;
            Console.WriteLine(msg);
        }

        public void Print(string msg, ConsoleColor foregroundcolor, bool center)
        {
            if (center)
            {
                int height = Console.WindowHeight;
                int width = Console.WindowWidth;
                int y = height / 2;
                int x = width / 2 - msg.Length / 2;
                Console.SetCursorPosition(x, y);
                Console.WriteLine(msg);
                Console.ForegroundColor = foregroundcolor;
                Console.SetCursorPosition(x, y);
                Console.WriteLine(msg);
            }
            else
            {
                Console.ForegroundColor = foregroundcolor;
                Console.WriteLine(msg);
            }
        }

        public void Pause()
        {
            Console.ReadKey();
        }
        public void Pause(string msg)
        {
            Console.WriteLine(msg);
            Console.ReadKey();
        }

    }
    class Program
    {
        static void Task1Questionnaire()
        {
            // Аделя Сабирова
            // 1.Написать программу «Анкета». 
            // Последовательно задаются вопросы(имя, фамилия, возраст, рост, вес).
            // В результате вся информация выводится в одну строчку.
            // а) используя склеивание;
            // б) используя форматированный вывод;
            // в) *используя вывод со знаком $.

            Console.Write("Enter a name: ");
            string name = Console.ReadLine();
            Console.Write("Enter a surname: ");
            string surname = Console.ReadLine();
            Console.Write("Enter an age: ");
            string age = Console.ReadLine();
            Console.Write("Enter a height: ");
            string height = Console.ReadLine();
            Console.Write("Enter a weight: ");
            string weight = Console.ReadLine();
            Console.WriteLine(name + " " + surname + ", age =" + age + ", height = " + height + ", weight = " + weight + ".");
            Console.WriteLine("{0} {1}, age = {2}, height = {3}, weight = {4}.", name, surname, age, height, weight);
            Console.WriteLine($"{name} {surname}, age = {age}, height = {height}, weight = {weight}.");
        }

        static void Task2BMI()
        {
            // Аделя Сабирова
            // 2.Ввести вес и рост человека. 
            // Рассчитать и вывести индекс массы тела(ИМТ) по формуле I = m / (h * h); 
            // где m — масса тела в килограммах, h — рост в метрах

            Console.Write("Enter a height: ");
            double height = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter a weight: ");
            double weight = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("BMI = {0}", weight / (height * height));
        }

        static double Distance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        static void Task3Distance()
        {
            // Аделя Сабирова
            // 3.а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 
            // по формуле r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2).
            // Вывести результат, используя спецификатор формата .2f(с двумя знаками после запятой);
            // б) *Выполните предыдущее задание, оформив вычисления расстояния между точками в виде метода;

            Console.Write("Enter x1: ");
            double x1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter y1: ");
            double y1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter x2: ");
            double x2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter y2: ");
            double y2 = Convert.ToDouble(Console.ReadLine());
            double r = Distance(x1, y1, x2, y2);
            Console.WriteLine($"The distance between entered points is {r:F2}");

        }

        static (int, int) Swap1(int a, int b)
        {
            int t = a;
            a = b;
            b = t;
            return (a, b);
        }

        static (int, int) Swap2(int a, int b)
        {
            a += b;
            b = a - b;
            a -= b;
            return (a, b);
        }

        static void Task4Swap()
        {
            // Аделя Сабирова
            //4.Написать программу обмена значениями двух переменных.
            //а) с использованием третьей переменной;
            //б) *без использования третьей переменной.

            Console.Write("Enter a for swap: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter b for swap: ");
            int b = Convert.ToInt32(Console.ReadLine());
            (int a, int b) t1 = Swap1(a, b);
            (int a, int b) t2 = Swap2(a, b);
            Console.WriteLine($"After the swap with first method a = {t1.a}, b = {t1.b}");
            Console.WriteLine($"After the swap with second method a = {t2.a}, b = {t2.b}");
        }

        public static void Print(string str, ConsoleColor foregroundcolor)
        {
            int height = Console.WindowHeight;
            int width = Console.WindowWidth;
            int y = height / 2;
            int x = width / 2 - str.Length / 2;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(str);
            Console.ForegroundColor = foregroundcolor;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(str);
        }

        static void Task5Print()
        {
            // Аделя Сабирова
            //5.а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
            //б) Сделать задание, только вывод организуйте в центре экрана
            //в) *сделать задание б с использованием собственных методов(например, print(string ms, int x, int y)

            string str = "Adelia Sabirova, Kazan";
            Console.WriteLine(str);

            //int height = Console.WindowHeight;
            //int width = Console.WindowWidth;
            //int y = height / 2;
            //int x = width / 2 - str.Length;
            //Console.SetCursorPosition(x, y);
            //Console.WriteLine(str);

            Print(str, ConsoleColor.Blue);
        }

        static void Task6Class()
        {
            //Adelia Sabirova
            //6.*Создать класс с методами, которые могут пригодиться в вашей учебе(Print, Pause).
            Task6 task = new Task6();
            string str = "Adelia Sabirova, Kazan";
            task.Print(str, 10, 5);
            task.Print(str, 50, 5, ConsoleColor.Blue);
            task.Print(str, ConsoleColor.Yellow);
            task.Print(str, ConsoleColor.Green, true);
            task.Print(str, ConsoleColor.Cyan, false);
            task.Pause();
            task.Pause(str);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Choose task to check: 1, 2, 3, 4, 5, 6");
            int task = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"You are checking {task} task.");
            if (task == 1)
                Task1Questionnaire();
            else if (task == 2)
                Task2BMI();
            else if (task == 3)
                Task3Distance();
            else if (task == 4)
                Task4Swap();
            else if (task == 5)
                Task5Print();
            else if (task == 6)
                Task6Class();
            Console.ReadKey();
        }
    }
}
