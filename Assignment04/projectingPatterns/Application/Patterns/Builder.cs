namespace projectingPatterns.Application.Patterns;

public class Builder
{
    public void Run()
    {
        var builder = new SneakerBuilder();
        BuildAdidasSamba(builder);
    }
    
    public void BuildAdidasSamba(ISneakerBuilder builder)
    {
        builder.setModel("Samba")
            .setMake("Adidas")
            .setManufacturedAt(DateTime.Now);
        Console.WriteLine($"{builder.Build()}");
    }
}

public class Sneaker
{
    public string Make { get; set; }
    public DateTime ManufacturedAt{ get; set; }
    public string Model { get; set; }
}

public interface ISneakerBuilder 
{
    public ISneakerBuilder setMake(string make);
	
    public ISneakerBuilder setModel(string model);
	
    public ISneakerBuilder setManufacturedAt(DateTime manufacturedAt);
	
    public Sneaker Build();
}

public class SneakerBuilder : ISneakerBuilder
{
    private Sneaker _sneaker = new Sneaker();
	
    public ISneakerBuilder setMake(string make)
    {
        _sneaker.Make = make;
        return this;	
    }
	
    public ISneakerBuilder setModel(string model)
    {
        _sneaker.Model = model;
        return this;
    }
	
    public ISneakerBuilder setManufacturedAt(DateTime manufacturedAt)
    {
        _sneaker.ManufacturedAt = manufacturedAt;
        return this;
    }
	
    public Sneaker Build() => _sneaker;
}
