namespace projectingPatterns.Application.Patterns;

public class Factory
{
    public void Run()
    {
        ButtonFactory btnf = new TailwindButtonFactory("Send");	
        Button button = btnf.CreateButton();
        btnf = new BootstrapButtonFactory("receive");
        Button button2 = btnf.CreateButton();
    }
}

public abstract class Button
{
    public abstract string Type{ get;}
}

public class BootstrapButton : Button
{
    public BootstrapButton()
    {
        Console.WriteLine("Bootstrap button");
    }
    public override string Type => "Bootstrap";
}

public class TailwindButton: Button
{
    public TailwindButton()
    {
        Console.WriteLine("TailwindButton button");
    }
    public override string Type => "Tailwind";
}

public abstract class ButtonFactory
{
    public string Name{ get; set; }
	
    public ButtonFactory(string name)
    {
        Name = name;
    }
    public abstract Button CreateButton();
	
}

public class TailwindButtonFactory : ButtonFactory
{
    public TailwindButtonFactory(string name) : base(name)
    {}
	
    public override Button CreateButton()
    {
        return new TailwindButton();
    }
}

public class BootstrapButtonFactory : ButtonFactory
{
    public BootstrapButtonFactory(string name) : base(name)
    {}
	
    public override Button CreateButton()
    {
        return new BootstrapButton();
    }
}

