public class Coffee {
    private string _name;
    private double _price;
    public string Name {
        get { return _name; }
        set {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name cannot be empty.");
            }
            _name = value;
        }
    }
    public double Price
    {
        get { return _price; }
        set 
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price must be greater than 0.");
            }
            _price = value;
        }
    }
    public Coffee(string name, double price) 
    {
        Name = name;
        Price = price;
    }
    private void GetInfor()
    {
        Console.WriteLine("Drink: " + Name);
        Console.WriteLine("Price: $" + Price.ToString("f2"));
    }
    public void PrintInfo() 
    {
        GetInfor();
        Console.WriteLine("Tá súil agam go mbainfidh tú taitneamh as do chaifé");
    }
}
public class Program
{
    public static void Main(string[] args) 
    {
        Coffee coffee1 = new Coffee("Latte", 3.5);
        coffee1.PrintInfo();
        Console.WriteLine();
        Coffee coffee2 = new Coffee("Cappuccino", 2.5);
        coffee1.PrintInfo();
        Console.WriteLine();
        Coffee coffee3 = new Coffee("Americano", 2);
        coffee1.PrintInfo();
        Console.WriteLine();
    }
}