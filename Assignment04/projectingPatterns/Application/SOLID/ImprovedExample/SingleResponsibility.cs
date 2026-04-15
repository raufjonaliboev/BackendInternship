namespace projectingPatterns.Application.SOLID.ImprovedExample;

public class SingleResponsibility
{
    public void Run()
    {
        var cartService = new CartService(new NotificationService());
        cartService.CreateCart();
    }
}

public class CartService
{
    private readonly INotificationService _notificationService;

    public CartService(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public void CreateCart()
    {
        Console.WriteLine("Creating cart...");
        _notificationService.SendNotification();
    }
}

public interface INotificationService
{
    public void SendNotification();
}
public class NotificationService : INotificationService
{
    public void SendNotification()
    {
        Console.WriteLine("Sending notification...");
    }
}