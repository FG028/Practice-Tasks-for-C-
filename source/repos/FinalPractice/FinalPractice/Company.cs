using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalPractice
{
    internal class Company
    {
        private Employee[] employees;

        public Company(Employee[] employees)
        {
            this.employees = employees;
        }

        public void GiveEverybodyBonus(int companyBonus)
        {
            foreach (var employee in employees)
            {
                employee.SetBonus(companyBonus);
            }
        }

        public int TotalToPay()
        {
            int total = 0;

            foreach (var employee in employees)
            {
                total += employee.ToPay();
            }

            return total;
        }

        public string GetNameSalary(int index)
        {
            var employee = employees[index];
            return $"{employee.Name} - ${employee.ToPay()}";
        }
    }
}
