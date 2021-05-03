using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Базовый класс
    /// </summary>
    public abstract class BaseObject
    {
        protected int idPerson;

        protected BaseObject(int idPerson)
        {
            this.idPerson = idPerson;
        }
        public abstract double AverageSalary();

        public override string ToString()
        {
            return $"ID Employee: {idPerson}, AverageSalary: {AverageSalary()}";
        }
    }
}
