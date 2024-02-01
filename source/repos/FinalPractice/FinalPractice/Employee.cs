using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalPractice
{
    internal class Employee
    {
        private string name;
        private int salary;
        protected int bonus;

        public string Name
        {
            get => name;
        }
        public int Salary
        {
            get => salary;
            set => salary = value;
        }
        public int Bonus
        {
            get => bonus;
        }
        public Employee(string name, int salary)
        {
            this.name = name;
            this.salary = salary;
        }
        public virtual void SetBonus(int bonus)
        {
            this.bonus = bonus;
        }
        public int ToPay()
        {
            return salary + bonus;
        }
    }
}
