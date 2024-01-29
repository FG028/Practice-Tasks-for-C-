public abstract class Animal : IAnimal, IRunnable, IEatable, ISleepable
{
    public abstract string Sound();

    public virtual void Run()
    {
        Console.WriteLine($"{this.GetType().Name} is running");
    }
    public virtual void Eat()
    {
        Console.WriteLine($"{this.GetType().Name} is eating");
    }
    public virtual void Sleep()
    {
        Console.WriteLine($"{this.GetType().Name} is sleeping");
    }
}

public class Dog : Animal
{
    public override string Sound()
        {
            return "Woof";
        }
    /*/public override void Run()
        {
            Console.WriteLine($"{this.GetType().Name} is running fast");
        }*/
    // Explicit method implementation
    public override void Eat()
        {
            Console.WriteLine($"{this.GetType().Name} is eating dog food.");
        }
    // Explicit method implementation
    public override void Sleep()
        {
            Console.WriteLine($"{this.GetType().Name} is sleeping soundly.");
        }
}

public class Cat : Animal
{
    public override string Sound()
    {
        return "Meow";
    }
    public override void Run()
    {
        Console.WriteLine($"{this.GetType().Name} is running gracefully");
    }
    public override void Eat()
    {
        Console.WriteLine($"{this.GetType().Name} is eating cat food.");
    }
    public override void Sleep()
    {
        Console.WriteLine($"{this.GetType().Name} is sleeping curled up.");
    }
}

public interface IAnimal : IRunnable, IEatable, ISleepable { }

public interface IRunnable
{
    void Run();
}

public interface IEatable
{
    void Eat();
}

public interface ISleepable
{
    void Sleep() => Console.WriteLine($"{this.GetType().Name} makes a sound.");
}

class Program
{
    static void Main(string[] args) 
    {
        var dog = new Dog();
        Console.WriteLine($"Dog's sound: {dog.Sound()}");
        dog.Run();
        dog.Eat();
        dog.Sleep();

        var cat = new Cat();
        Console.WriteLine($"Cat's sound: {cat.Sound()}");
        cat.Run();
        cat.Eat();
        cat.Sleep();
    }
}