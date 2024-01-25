using System;

class Messenger
{
    // Static field to store the current state of the messenger
    static string State = "Idle";

    // Private fields to store the message and its sequence number
    private string message;
    private int messageCounter;

    static Messenger()
    {
        Console.WriteLine("Messenger initialized.");
    }

    // Constructor to initialize the message and sequence number when a new messenger is created
    public Messenger(string message, int messageCounter)
    {
        this.message = message;
        this.messageCounter = messageCounter;

        // Set the state to "Processing" when a message is received
        State = "Processing";

        Console.WriteLine("Message received: {0}, sequence number: {1}", message, messageCounter);
    }

    // Deconstructor to handle cleanup when the messenger object is destroyed
    ~Messenger()
    {
        // Set the state to "Terminated" when the messenger is done processing a message
        State = "Terminated";

        Console.WriteLine("Message processed: {0}, sequence number: {1}", message, messageCounter);
    }


    public void DisplayMessage()
    {
        Console.WriteLine("Message: {0}", message);
    }
    public static void Main(string[] args)
    {
        // Access the State field after the static constructor
        Console.WriteLine("State: {0}", State);
        // Create two instances of Messenger, each with a different message and sequence number
        Messenger messenger1 = new Messenger("Hello, world!", 1); // Create a messenger with message "Hello, world!" and sequence number 1
        Console.WriteLine("State: {0}", State);
        messenger1.DisplayMessage();

        Messenger messenger2 = new Messenger("Goodbye!", 2); // Create a messenger with message "Goodbye!" and sequence number 2
        Console.WriteLine("State: {0}", State);
        messenger2.DisplayMessage();
    }
}