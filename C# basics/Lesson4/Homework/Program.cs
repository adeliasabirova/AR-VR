using System;
using System.Collections.Generic;
using Matrix;

namespace Homework
{
    class Program
    {
        static int[] CreateArray(int length)
        {
            Random rand = new Random();
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
                array[i] = rand.Next(-10000, 10000);
            return array;
        }

        static int CheckThreeArray(int[] array)
        {
            int count = 0;
            int length = array.Length;
            for (int i = 0; i < length-1; i++)
            {
                if (array[i] % 3 == 0 && array[i + 1] % 3 == 0)
                    continue;
                else if (array[i] % 3 == 0 || array[i + 1] % 3 == 0)
                    count++;
            }
            return count;
        }
        static void Task1()
        {
            //Аделя Сабирова
            //Дан  целочисленный  массив  из 20 элементов.  
            //Элементы  массива  могут принимать  целые  значения  от –10 000 до 10 000 включительно. 
            //Заполнить случайными числами.  
            //Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых только одно число делится на 3. 
            //В данной задаче под парой подразумевается два подряд идущих элемента массива.
            int length = 20;
            int[] array = CreateArray(length);
            Console.WriteLine($"The {CheckThreeArray(array)} of pairs of array elements in which only one number is divisible by 3");
        }

        static void Task2()
        {
            //Аделя Сабирова
            //Реализуйте задачу 1 в виде статического класса StaticClass;
            //а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
            //б) *Добавьте статический метод для считывания массива из текстового файла. Метод должен возвращать массив целых чисел;
            //в)**Добавьте обработку ситуации отсутствия файла на диске.
            int length = 20;
            int[] array = StaticArray.CreateArray(length);
            Console.WriteLine($"The {StaticArray.CheckThreeArray(array)} of pairs of array elements in which only one number is divisible by 3");
            array = StaticArray.ReadArrayFromFile("C:/Users/adely/source/repos/AR-VR/C# basics/Lesson4/Homework/Array.txt");
            if (array != null)
                Console.WriteLine($"The {StaticArray.CheckThreeArray(array)} of pairs of array elements in which only one number is divisible by 3");
        }

        static string Print(int[] array)
        {
            string s = "";
            foreach (int v in array)
                s = s + v + " ";
            return s;
        }

        static void Task3()
        {
            //Аделя Сабирова
            //Дописать класс для работы с одномерным массивом. 
            //Реализовать конструктор, создающий массив определенного размера 
            //и заполняющий массив числами от начального значения с заданным шагом. 
            //Создать свойство Sum, которое возвращает сумму элементов массива, 
            //метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива 
            //(старый массив, остается без изменений),  метод Multi, умножающий каждый элемент массива на определённое число, 
            //свойство MaxCount, возвращающее количество максимальных элементов. 
            //е) *** Подсчитать частоту вхождения каждого элемента в массив (коллекция Dictionary<int,int>)
            int length = 20, start = 0, step = 5;
            MyArray array = new MyArray(length, start, step, true);
            Dictionary<int, int> keyValues = array.CountElements();
            Console.WriteLine($"Array: {array.ToString()}");
            foreach (KeyValuePair<int, int> keys in keyValues)
                Console.WriteLine($"Element {keys.Key} has {keys.Value} entries");
            int sum = array.Sum();
            int[] inverse = array.Inverse();
            int[] multi = array.Multi(5);
            int maxcount = array.MaxCount();           
            Console.WriteLine($@"Sum: {sum}
Inverse: {Print(inverse)}
Multi: {Print(multi)}
MaxCount: {maxcount}");
        }

        static void Task4()
        {
            //Аделя Сабирова
            //Решить задачу с логинами из урока 2, 
            //только логины и пароли считать из файла в массив. 
            //Создайте структуру Account, содержащую Login и Password.
            Account account = new Account();
            string[,] loginPassword = Account.ReadFromFile("C:/Users/adely/source/repos/AR-VR/C# basics/Lesson4/Homework/LoginPassword.txt");
            if (loginPassword != null)
            {
                int length0 = loginPassword.GetLength(0);
                for (int i = 0; i < length0; i++)
                {
                    account = new Account(loginPassword[i, 0], loginPassword[i, 1]);
                    if (account.IsEntered())
                    {
                        Console.WriteLine($"Login and password are correct.");
                        break;
                    }
                    else
                        Console.WriteLine("Login and password are incorrect.");
                }

                if (!String.Equals(account.getLogin(), ""))
                    Console.WriteLine($"The right login and password are: \n{account.ToString()}");
                else
                    Console.WriteLine("All logins and passwords are incorrect.");
            }
        }

        static void Task5()
        {
            //Аделя Сабирова
            //*а) Реализовать библиотеку с классом для работы с двумерным массивом.
            //Реализовать конструктор, заполняющий массив случайными числами.
            //Создать методы, которые возвращают сумму всех элементов массива, 
            //сумму всех элементов массива больше заданного, 
            //свойство, возвращающее минимальный элемент массива, 
            //свойство, возвращающее максимальный элемент массива, 
            //метод, возвращающий номер максимального элемента массива(через параметры, используя модификатор ref или out).
            //**б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
            //**в) Обработать возможные исключительные ситуации при работе с файлами.

            Matrix.Matrix matrix = new Matrix.Matrix("C:/Users/adely/source/repos/AR-VR/C# basics/Lesson4/Homework/Matrix.txt");
            Console.WriteLine($"Max = {matrix.Max}");
            Console.WriteLine($"Min = {matrix.Min}");
            Console.WriteLine($"Sum = {matrix.SumAll()}");
            Console.WriteLine($"Sum more than 4 = {matrix.SumMoreValue(4)}");
            int index1 = 0, index2 = 0;
            matrix.MaxIndex(ref index1, ref index2);
            Console.WriteLine($"Max index: i = {index1}, j = {index2}");
            Matrix.Matrix matrixRand = new Matrix.Matrix(5, 7, 0, 30);
            matrixRand.WriteInFile("C:/Users/adely/source/repos/AR-VR/C# basics/Lesson4/Homework/MatrixWrite.txt");
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Task1");
            Task1();
            Console.WriteLine("\nTask2");
            Task2();
            Console.WriteLine("\nTask3");
            Task3();
            Console.WriteLine("\nTask4");
            Task4();
            Console.WriteLine("\nTask5");
            Task5();
            Console.ReadKey();
        }
    }
}
