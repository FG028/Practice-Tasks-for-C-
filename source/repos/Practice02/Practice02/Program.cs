using System;

class Calculator
{
    static void Main(string[] args) {
        int choice;
        while (true){
            Console.Clear();
            Console.WriteLine("Select the operator.");
            Console.WriteLine("-----------------------");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Exit");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Enter your choice:");

            choice = int.Parse(Console.ReadLine());
            
            switch (choice) {
                case 1:
                    doAddition();
                    break;
                case 2:
                    doSubtraction();
                    break;
                case 3:
                    doMultiplication();
                    break;
                case 4:
                    doDivision();
                    break;
                case 5:
                    Console.WriteLine("Initiating shutdown sequence...");
                    return;
                default:
                    Console.WriteLine("Wrong choice mate! Please enter a number from 1 to 5.");
                    break;
            }
        } 
    }
    private static void doAddition()
    {

        int num1, num2;

        Console.Clear();
        Console.WriteLine("Enter the first number: ");
        num1 = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Enter the second number: ");
        num2 = int.Parse(Console.ReadLine());

        int result =  num1 + num2;
        Console.WriteLine("The result of the sum is: {0}", result);
    }
    private static void doSubtraction() {

        int num1, num2;

        Console.Clear();
        Console.WriteLine("Enter the first number: ");
        num1 = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Enter the second number: ");
        num2 = int.Parse(Console.ReadLine());

        int result = num1 - num2;
        Console.WriteLine("The result of the difference is : {0}", result);
    }
    private static void doMultiplication() {
        int num1, num2;

        Console.Clear();
        Console.WriteLine("Enter the first number: ");
        num1 = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Enter the second number: ");
        num2 = int.Parse(Console.ReadLine());

        int result = num1 * num2;
        Console.WriteLine("The result of the multiplication is: {0}", result);
    }

    private static void doDivision() {
        int num1, num2;

        Console.Clear();
        Console.WriteLine("Enter the first number: ");
        num1 = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Enter the second number: ");
        num2 = int.Parse(Console.ReadLine());

        if (num2 == 0)
        {
            Console.WriteLine("Division by zero is not allowed!");
            
        } else
        {
            int result = num1 / num2;
            Console.WriteLine("The result of the division is: {0}", result);
        }
    }
}