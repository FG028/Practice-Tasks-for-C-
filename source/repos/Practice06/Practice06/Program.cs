using System;
public class User {

    // Declare class fields
    private int userId;
    private String name;
    private int age;

    //Create a constructor
    public User(int userId, String name, int age) {
        this.userId = userId;
        this.name = name;
        this.age = age;
    }

    //Display the user's information
    public void PrintInfo() {
        Console.WriteLine("User ID: {0}", userId);
        Console.WriteLine("User Name: {0}",  name);
        Console.WriteLine("User Age: {0}",  age);
    }
    public static void ChangeUserAge(User user, int newAge) {
        user.age = newAge;
    }
}
class Program {
    static void Main(string[] args)
    {
        // Create a user object
        User user = new User(1, "Scott Washington", 25);

        Console.WriteLine("User's Old Information");
        Console.WriteLine();

        // Display the user's information
        user.PrintInfo();

        Console.WriteLine();
        Console.WriteLine("--------------------------");
        Console.WriteLine();

        //Change the user's age
        User.ChangeUserAge(user, 35);

        Console.WriteLine("User's New Information");
        Console.WriteLine();

        //Display the updated information
        user.PrintInfo();
    }
}