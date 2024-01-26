using System;
using Microsoft.VisualBasic;

// Abstract class Car representing common properties and methods for car models
public abstract class Car
{
    // Properties to store the car's quantity and warranty duration
    public int quantity;
    public int warranty;

    // Constructor to initialize the car's quantity and warranty
    public Car(int quantity, int warranty)
    {
        this.quantity = quantity;
        this.warranty = warranty;
    }
    // Virtual method GetQuantity() to get the car's production quantity
    public virtual void GetQuantity()
    {
        Console.WriteLine($"The number of produced cars: {quantity}");
    }
    // Virtual method GetFullInfo\(\) to get the full car information, including quantity and warranty
    public virtual void GetFullInfo()
    {
        // Call the GetQuantity() method to get the production quantity
        GetQuantity();
        Console.WriteLine($"Warranty period: {warranty} months.");
    }

    public void SetWarranty(int newWarranty)
    {
        warranty = newWarranty;
    }
}
// Class WV inheriting from the Car class, representing Volkswagen cars
public class WV : Car
{
    // Constructor to initialize the WV car properties
    public WV(int quantity, int warranty) : base(quantity, warranty) { }

    // Override the GetQuantity() method to display "Volkswagen" model information
    public override void GetQuantity()
    {
        Console.WriteLine($"The number of produced Volkswagens: {quantity}");
    }
    // Override the GetFullInfo\(\) method to include Volkswagen\-specific information
    public override void GetFullInfo()
    {
        Console.WriteLine($"Volkswagen model");
        base.GetFullInfo();
    }
}
// Class Toyota inheriting from the Car class, representing Toyota cars
public class Toyota : Car
{
    // Constructor
    public Toyota(int quantity, int warranty) : base(quantity, warranty) { }

    // Override the GetQuantity()
    public override void GetQuantity()
    {
        Console.WriteLine($"The number of produced Toyotas: {quantity}");
    }
    // Override the GetFullInfo
    public override void GetFullInfo()
    {
        Console.WriteLine($"Toyota model");
        Console.WriteLine($"Additional information: known for reliability and fuel efficiency.");
        base.GetFullInfo();
    }
}
// Class Audi inheriting from the WV class, representing Audi cars
public class Audi : WV
{
    // Constructor
    public Audi(int quantity, int warranty) : base(quantity, warranty) { }
    // Override the GetQuantity
    public override void GetQuantity()
    {
        Console.WriteLine($"The number of produced Audi's: {quantity}");
    }
    // Override the GetFullInfo()
    public override void GetFullInfo()
    {
        Console.WriteLine($"Audi model");
        base.GetFullInfo();
        Console.WriteLine($"Additional information: known for premium features and performance.");
    }
}
class MainClass
{
    static void Main(string[] args)
    {
        // Create VW and Toyota instances
        var vw = new WV(100, 24);
        var toyota = new Toyota(50, 36);

        // Output VW information
        vw.GetQuantity();
        vw.GetFullInfo();

        // Change VW warranty
        vw.SetWarranty(30);

        // Output updated VW information
        vw.GetQuantity();
        vw.GetFullInfo();

        // Output Toyota information
        toyota.GetQuantity();
        toyota.GetFullInfo();

        // Create Audi instance inheriting from WV
        var audi = new Audi(25, 48);

        // Output Audi information
        audi.GetQuantity();
        audi.GetFullInfo();
    }
}
