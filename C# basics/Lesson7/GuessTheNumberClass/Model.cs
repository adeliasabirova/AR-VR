using System;

namespace GuessTheNumberClass
{
    public class Model
    {
        int number; //число
        int goal; //цель
        public string Number { get;  set; }
        public string Play() //функция создания цели игры
        {
            Random random = new Random();
            goal = random.Next(1, 100);
            return $"The number is choosen";
        }

        private bool CheckNumber() => int.TryParse(Number, out number); //функция прверки введенного числа 

        public string Check() //функция проверки введенного числа по отношению к цели
        {
            if (CheckNumber())
                if (number == goal)
                    return "Goal is reached!";
                else if (number > goal)
                    return "Lower";
                else
                    return "Greater";
            return "Error format";
        }
    }
}
