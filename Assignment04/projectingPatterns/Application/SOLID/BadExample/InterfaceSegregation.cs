using Microsoft.CSharp.RuntimeBinder;

namespace projectingPatterns.Application.SOLID.BadExample;

public class InterfaceSegregation
{
    public void Run()
    {
        IWorker worker = new Robot();
        worker.Work();
        worker.Eat();
    }
}

public interface IWorker
{
    void Work();
    void Eat();
}

public class Robot : IWorker
{
    public void Work()
    {
        Console.WriteLine("Robot working...");
    }

    public void Eat()
    {
       Console.WriteLine("I am a robot, I don't eat. Throwing exception...");
    }
}