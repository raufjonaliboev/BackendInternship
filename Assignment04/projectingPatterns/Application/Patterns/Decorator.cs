namespace projectingPatterns.Application.Patterns;

public class Decorator
{
    public void Run()
    {
        Pizza italianPizza = new ItalianPizza();
        italianPizza = new KebabPizza(italianPizza);
        Console.WriteLine($"The name: {italianPizza.Name} and the Value: {italianPizza.GetCost()}");
    }
}

public abstract class Pizza
{
    public Pizza(string name)
    {
        Name = name;
    }
    public string Name { get; set; }
    public abstract decimal GetCost();
}

public class ItalianPizza : Pizza
{
    public ItalianPizza() : base ("Italian Pizza")
    {}
	
    public override decimal GetCost() => 12;
}

public class BulgarianPizza : Pizza
{
    public BulgarianPizza() : base("Bulgarian Pizza")
    {}
	
    public override decimal GetCost() => 10;
}

public abstract class PizzaDecorator : Pizza
{
    protected Pizza _pizza;
	
    public PizzaDecorator(string name, Pizza pizza) : base(name)
    {
        _pizza = pizza;
    }
}

public class CheezeBorder : PizzaDecorator 
{
    public CheezeBorder(Pizza pizza) : base(pizza.Name + "with cheeze border", pizza)
    {}
	
    public override decimal GetCost()
    {
        return _pizza.GetCost() + 6;
    }
}

public class KebabPizza : PizzaDecorator 
{
    public KebabPizza(Pizza pizza) : base(pizza.Name + "Added kebab", pizza)
    {}
	
    public override decimal GetCost()
    {
        return _pizza.GetCost() + 10;
    }
}