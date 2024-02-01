using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalPractice
{
    internal class Manager : Employee
    {
        private int quantity;

        public Manager(string name, int salary, int quantity) : base(name, salary)
        {
            this.quantity = quantity;
        }

        public override void SetBonus(int bonusAmount)
        {
            if (quantity > 150)
            {
                bonus = bonusAmount + 1000;
            }
            else if (quantity > 100)
            {
                bonus = bonusAmount + 500;
            }
            else
            {
                bonus = bonusAmount;
            }
        }
    }
}
