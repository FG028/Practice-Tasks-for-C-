public class Employee 
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
public class SalesPerson : Employee
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
public class Manager : Employee
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
public class Company
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
        foreach (int i in Enumerable.Range(0, employees.Length))
        // Enumerable.Range is a method that generates a sequence of integers from a starting point to an end point
        // In this case, it's generating a sequence of integers from 0 to the length of the employees array,
        // which means it will generate one integer for each employee in the array
        {
            string nameAndSalary = company.GetNameSalary(i);
            Console.WriteLine($"Employee: {i}: {nameAndSalary}");
        }
    }
}