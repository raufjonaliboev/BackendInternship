namespace projectingPatterns.Application.SOLID.BadExample;

public class OpenClosed
{
    public void Run()
    {
        LoyaltyService loyaltyService = new LoyaltyService();
        double price = loyaltyService.CalculatePrice("Gold", 100);
        Console.WriteLine($"Price for GOLD customer: {price}");
    }
}

public class LoyaltyService
{
    public double CalculatePrice(string customerType, double price)
    {
        if (customerType == "Gold")
            return price * 0.9;
        if (customerType == "Platinum")
            return price * 0.7;

        return price;
    }
}

