using System;

// User account
public class User 
{
    // ID
    public int UserID { get; set; }
    // Balance
    public double Balance { get; set; }

    // User constructor initializes UserID and Balance
    public User(int userID, double balance) 
    {
        UserID = userID;
        Balance = balance;
    }
}

// Provides a service to check the balance of the user
public class Provider<U> where U : User
{
    // CheckBalance method takes the user object as input and prints 
    public void CheckBalance(U user)
    {
        Console.WriteLine("User ID: {0}", user.UserID);
        Console.WriteLine("Balance: {0:0.00}", user.Balance);
    }
}
public class Program
{
    // The Main method creates a User object and a Provider object,
    // and then calls the CheckBalance method to print the user's ID and balance.
    public static void Main(string[] args)
    {
        // Create a User object
        User user = new User(123, 500.0);
        // Create a Provider object that can handle User objects.
        Provider<User> provider = new Provider<User>();
        
        provider.CheckBalance(user);
    }
}