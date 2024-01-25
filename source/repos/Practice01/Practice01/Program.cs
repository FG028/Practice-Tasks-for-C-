using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Transactions;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your name: ");
        string name = Console.ReadLine();
        Console.Clear();
        int numberOfCharacters = name.Length;

        Console.WriteLine("Enter your age: ");
        int age;
        while (!int.TryParse(Console.ReadLine(), out age))
        {
            Console.WriteLine("Invalid input. Please enter a valid number for the age: ");
        }
        Console.Clear();

        Console.WriteLine("Enter your e-mail address: ");
        string email = Console.ReadLine();
        Console.Clear();

        Console.WriteLine("Enter your 4-digit password (code)");
        string password = string.Empty;
        ConsoleKey key;
        do
        {
            var keyinfo = Console.ReadKey(intercept: true);
            key = keyinfo.Key;
            if (key == ConsoleKey.Backspace && password.Length > 0)
            {
                Console.Write("\b \b");
                password = password[0..^1];
            }
            else if (!char.IsControl(keyinfo.KeyChar))
            {
                Console.Write("*");
                password += keyinfo.KeyChar;
            }
        } while (key != ConsoleKey.Enter);
        Console.Clear();

        Console.Write("-------------------------------------------------");
        Console.Write("\n\tYour name is : ");
        Console.Write(name + ".");
        Console.Write("\n\tYour e-mail is: ");
        Console.Write(email + ".");
        Console.Write("\n\tYour age is: ");
        Console.Write(age + ".");
        Console.Write("\n\tYour 4-digit password (code): ");
        Console.Write(password + ".");
        Console.Write("\n-------------------------------------------------");
        Console.Write("\nThe length of the name is: " + numberOfCharacters);
    }
}