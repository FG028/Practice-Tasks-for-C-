sealed class Worker
{
    public int Rate;
    public int TotalHour;
    public Worker(int rate, int totalHour)
    {
        Rate = rate;
        TotalHour = totalHour;
    }
    public double CalculateSalary() 
    {
        return Rate * TotalHour * 1.5;
    }
}
static class TopWorker
{
    public static double CalculateSalaryWithBonus(this Worker worker)
    {
        if (worker.Rate < 50 && worker.TotalHour > 200)
        {
            //Increase the salary by 20% for top performers
            return worker.CalculateSalary() * 2;
        } else
        {
            // Use the default salary calculation
            return worker.CalculateSalary();
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        Worker worker = new Worker(45, 210);
        double salary;

        // Check if the worker qualifies for a bonus
        if (worker.Rate < 50 && worker.TotalHour > 200)
        {
            salary = worker.CalculateSalaryWithBonus();
        } else
        {
            salary = worker.CalculateSalary();
        }
        Console.WriteLine("Employee compensation: ${0:0.00}", salary);
    }
}