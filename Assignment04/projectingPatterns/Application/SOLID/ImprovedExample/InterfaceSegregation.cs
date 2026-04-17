namespace projectingPatterns.Application.SOLID.ImprovedExample;

public class InterfaceSegregation
{
    public void Run()
    {
        Robot worker = new Robot();
        worker.Work();

        Human feedable = new Human();
        feedable.Eat();
        feedable.Work();
    }
}

public interface IWorker
{
    public void Work();
}

public interface IFeedable
{
    public void Eat();
}

public class Robot : IWorker
{
    public void Work()
    {
        Console.WriteLine("Robot working...");
    }
}

public class Human : IWorker, IFeedable
{
    public void Work()
    {
        Console.WriteLine("Human working...");
    }

    public void Eat()
    {
        Console.WriteLine("Human eating...");
    }
}