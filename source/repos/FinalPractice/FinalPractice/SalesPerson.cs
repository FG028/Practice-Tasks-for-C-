using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalPractice
{
    internal class SalesPerson : Employee
    {
            private int percent;

            public SalesPerson(string name, int salary, int percent) : base(name, salary)
            {
                this.percent = percent;
            }

            public override void SetBonus(int bonusAmount)
            {
                if (percent > 200)
                {
                    bonus = bonusAmount * 3;
                }
                else if (percent > 100)
                {
                    bonus = bonusAmount * 2;
                }
                else
                {
                    bonus = bonusAmount;
                }
          }
     }
   
}
