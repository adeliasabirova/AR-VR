using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
//Аделя Сабирова

namespace HomeworkTask1
{
    class Program
    {
        /// <summary>
        /// Вывод свойств DateTime
        /// </summary>
        /// <param name="t">объект свойства, полученный рефлексии</param>
        static void PrintProperties(PropertyInfo t)
        {
            DateTime dateTime = new DateTime();
            Console.WriteLine($"Название свойства DateTime: {t.Name}");
            Console.WriteLine($"Возможность чтение свойства: {t.CanRead}");
            Console.WriteLine($"Возможность записи свойства: {t.CanWrite}");
            Console.WriteLine($"Default значение свойства: {t.GetValue(dateTime, null)}\n");
        }
        /// <summary>
        /// Решение задачи 1
        /// </summary>
        static void Task1()
        {            
            Type type = typeof(DateTime);
            foreach (var t in type.GetProperties())
                PrintProperties(t);
            Console.ReadKey();
        }
        /// <summary>
        /// С помощью рефлексии выведите все свойства структуры DateTime
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Task1();
        }
    }
}
