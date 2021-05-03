namespace Task1
{
    /// <summary>
    /// Класс работников с почасовой оплаты труда
    /// </summary>
    class Employee1 : BaseObject
    {
        private double hourlyPayment;
        public Employee1(int idPerson, double hourlyPayment) : base(idPerson) 
        {
            this.hourlyPayment = hourlyPayment;
        }

        public override double AverageSalary()
        {
            return 20.8 * 8 * hourlyPayment;
        }
    }
}
