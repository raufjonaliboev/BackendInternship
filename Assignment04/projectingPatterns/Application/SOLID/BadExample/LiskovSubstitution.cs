namespace projectingPatterns.Application.SOLID.BadExample;

public class LiskovSubstitution
{
    public void Run()
    {
        Laptop mac =  new Macbook();
        mac.InstallvisualStudio();
    }
}

public class Laptop
{
    public virtual void InstallvisualStudio()
    {
        Console.WriteLine("install Visual Studio");
    }
}

public class Macbook : Laptop
{
    public override void InstallvisualStudio()
    {
        Console.WriteLine("I will throw new UnImplemented exception");
    }
}