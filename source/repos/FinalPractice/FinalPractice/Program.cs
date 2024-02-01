using FinalPractice;
class Program
{
    public static void Main(string[] args)
    {
        // Create an array of employees
        Employee[] employees = new Employee[]
        {
            new Employee("John Doe", 5000),
            new SalesPerson("Jane Doe", 4000, 150),
            new Manager("Peter Jones", 6000, 200)
        };
        // Create a company object
        Company company = new Company(employees);

        // Set the company bonus
        company.GiveEverybodyBonus(100);

        // Calculate the total compensation for all employees
        int totalToPay = company.TotalToPay();
        Console.WriteLine($"Total compensation to pay: ${totalToPay}");

        // Get the name and compensation of each employee
        for (int i = 0; i < employees.Length; i++)
        {
            string nameAndSalary = company.GetNameSalary(i);
            Console.WriteLine($"Employee: {i}: {nameAndSalary}");
        }
    }
}