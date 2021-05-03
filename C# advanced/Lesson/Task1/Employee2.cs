namespace Task1
{
    /// <summary>
    /// Класс работников с фиксированной оплатой
    /// </summary>
    class Employee2 : BaseObject
    {
        private double salary;
        public Employee2(int idPerson, double salary) : base(idPerson)
        {
            this.salary = salary;
        }
        public override double AverageSalary()
        {
            return salary;
        }
    }
}
