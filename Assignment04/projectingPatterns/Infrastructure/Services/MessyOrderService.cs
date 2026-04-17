namespace projectingPatterns.Infrastructure.Services;

public class MessyOrderService
{
    public void PlaceOrder(string email, List<string> items, decimal total)
    {
        if (string.IsNullOrEmpty(email))
            throw new Exception("Invalid email");

        if (items == null || !items.Any())
            throw new Exception("No items");

        if (total > 1000)
        {
            total *= 0.9m; 
        }

        Console.WriteLine("Saving order to database...");
        Console.WriteLine($"Sending email to {email}");
        Console.WriteLine("Order placed successfully");
    }
}