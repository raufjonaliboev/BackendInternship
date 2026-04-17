namespace projectingPatterns.Application.SOLID.ImprovedExample;

public class LiskovSubstitution
{
    public void Run()
    {
        IWindowsSupport asus = new Asus();
        IMacOSSupport mac = new Macbook();
        asus.InstallVisualStudio();
        mac.InstallXCode();
        ILaptop laptop = (ILaptop)asus;
        User me = new User(laptop);
        me.OpenApiLink();
    }
}

public class User
{
    private readonly ILaptop _laptop;

    public User(ILaptop laptop)
    {
        _laptop = laptop;
    }

    public void OpenApiLink()
    {
        _laptop.OpenBrawser();
    }
}

public interface ILaptop
{
    public void OpenBrawser();
}

public interface IMacOSSupport 
{
    public void InstallXCode();
}

public interface IWindowsSupport
{
    public void InstallVisualStudio();
}
public class Asus : ILaptop, IWindowsSupport
{
    public void InstallVisualStudio()
    {
        Console.WriteLine("install Visual Studio");
    }

    public void OpenBrawser()
    {
        Console.WriteLine("I Will open via Chrome");
    }
}

public class Macbook : ILaptop, IMacOSSupport
{
    public void InstallXCode()
    {
       Console.WriteLine("install XCode");  
    }

    public void OpenBrawser()
    {
        Console.WriteLine("I Will open via Safari");
    }
}