public class Shape
{
    protected double width;
    protected double height;

    public Shape(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public virtual double GetArea()
    {
        Console.WriteLine("Shape area: " + (width * height));
        return width * height;
    }
}

public class Rectangle : Shape
{
    public Rectangle(double width, double height) : base(width, height)
    {
    }

    public override double GetArea()
    {
        return base.GetArea();
    }
}

public class Program
{
    public static void Main()
    {
        // Create a rectangle object
        Rectangle rectangle = new Rectangle(5, 3);

        // Get the area of the rectangle
        rectangle.GetArea();

        // Create a Shape object
        Shape shape = new Shape(10, 20);

        // Get the area of the Shape
        shape.GetArea();

        // Create two objects using the object type and use the as/is type check operators to cast the types. Then call the GetArea() method on these objects.
        Object shape1 = new Rectangle(8, 6);
        Object shape2 = new Rectangle(4, 9);

        if (shape1 is Rectangle)
        {
            ((Rectangle)shape1).GetArea();
        }
        else
        {
            Console.WriteLine("Object 1 is not a rectangle");
        }

        if (shape2 is Rectangle)
        {
            ((Rectangle)shape2).GetArea();
        }
        else
        {
            Console.WriteLine("Object 2 is not a rectangle");
        }
    }
}