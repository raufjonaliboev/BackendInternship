namespace CoffeeAtHome.Models;

public static class CoffeeMaker
{
    public static async Task MakeAsync()
    {
        var boilingWater = BoilWaterAsync();

        Console.WriteLine("Take cups out");
	
        var a = 0;
	
        for (int i=0; i < 10000; i++)
        {
            a+=i;
        }
	
        Console.WriteLine("Put coffee in cups");
    
        Console.WriteLine("Add some milk");
	
        var boiledWater = await boilingWater;
	
        var coffee = $"Pour {boiledWater} in cups";

        Console.WriteLine(coffee);
    }

    public static void Make()
    {
        var boiledWater = BoilWater();

        Console.WriteLine("Take cups out");

        Console.WriteLine("Put coffee in cups");
    
        Console.WriteLine("Add some milk");

        var coffee = $"Pour {boiledWater} in cups";

        Console.WriteLine(coffee);    
    }
    
    private static async Task<string> BoilWaterAsync()
    {
        Console.WriteLine("Start the kettle");
        Console.WriteLine("Waiting for the kettle");

        await Task.Delay(2000);

        Console.WriteLine("Kettle finished boiling");

        return "Boiled water";   
    }

    private static string BoilWater()
    {
        Console.WriteLine("Start the kettle");
    
        Console.WriteLine("Waiting for the kettle");
    
        Task.Delay(3000).GetAwaiter().GetResult();
    
        Console.WriteLine("Kettle finished boiling");
    
        return "Boiled water";
    }
}