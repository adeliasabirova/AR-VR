using System;
using System.Collections.Generic;

namespace Task1
{
    /// <summary>
    /// 1. Построить три класса (базовый и 2 потомка), 
    /// описывающих некоторых работников с почасовой оплатой (один из потомков) и фиксированной оплатой (второй потомок).
    ///а) Описать в базовом классе абстрактный метод для расчёта среднемесячной заработной платы.
    ///Для «повременщиков» формула для расчета такова: «среднемесячная заработная плата = 20.8 * 8 * почасовая ставка», 
    ///для работников с фиксированной оплатой «среднемесячная заработная плата = фиксированная месячная оплата».
    ///б) Создать на базе абстрактного класса массив сотрудников и заполнить его.
    ///в) * Реализовать интерфейсы для возможности сортировки массива, используя Array.Sort().
    ///г) * Создать класс, содержащий массив сотрудников, и реализовать возможность вывода данных с использованием foreach.
    /// </summary>
    /// 
    class SalaryComparer : IComparer<BaseObject>
    {
        public int Compare(BaseObject x, BaseObject y)
        {
            return (int)(x.AverageSalary() - y.AverageSalary()); 
        }
    }
    
    static class Solution
    {
        static BaseObject[] employees;
        static Random random = new Random();

        static Solution() { }

        /// <summary>
        /// Метод создания массива работников
        /// </summary>
        public static void Execution()
        {
            employees = new BaseObject[15];
            for (int i = 0; i < employees.Length; i++)
            {
                int index = random.Next(0, 2);
                if (index == 0)
                {
                    double hourlyPayment = random.Next(150, 600);
                    employees[i] = new Employee1(i + 1, hourlyPayment);
                }
                else
                {
                    double salary = random.Next(25000, 100000);
                    employees[i] = new Employee2(i + 1, salary);
                }
            }
        }

        /// <summary>
        /// Метод сортировки массива
        /// </summary>
        public static void Sort()
        {
            Array.Sort(employees, new SalaryComparer());
        }

        /// <summary>
        /// Вывод массива на консоль
        /// </summary>
        public static void PrintToConsole()
        {
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.ToString());
            }
        }
    }
}
