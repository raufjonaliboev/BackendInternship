namespace projectingPatterns.Application.Patterns;

public class Strategy
{
    public void Run()
    {
        var services = new ServiceCollection();
	
        services.AddTransient<INotification, SmsNotification>();
        services.AddTransient<INotification, EmailNotification>();
	
        services.AddTransient<CartService>();

        var provider = services.BuildServiceProvider();
	
        var cartService = provider.GetRequiredService<CartService>();
        cartService.Process("email");
    }
}

public interface INotification
{
    public string Type { get;}
    public void Notify();
}

public class EmailNotification : INotification
{
    public string Type => "email";
	
    public void Notify()
    {
        Console.WriteLine("The logic of sending Email notification! Here we also can inject any service or provider for sending notification"); 
    }
}

public class SmsNotification : INotification
{

    public string Type => "sms";	
    public void Notify()
    {
        Console.WriteLine("The logic of sending Sms notification! The same situcation! We can provide any tool via CTOR or something else here!");
    }
}

public class CartService
{
    private readonly IEnumerable<INotification> _notifications;

    public CartService(IEnumerable<INotification> notifications)
    {
        _notifications = notifications;
    }

    public void Process(string type)
    {
        var strategy = _notifications.First(n=>n.Type == type);
        strategy.Notify();
    }
}