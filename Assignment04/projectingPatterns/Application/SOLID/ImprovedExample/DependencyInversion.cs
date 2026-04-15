namespace projectingPatterns.Application.SOLID.ImprovedExample;

public class DependencyInversion
{
    private readonly PaymentService _paymentService = new PaymentService(new PayPal());
    public void Run()
    {
        _paymentService.Pay(100);
    }
}

public class PaymentService 
{
    private readonly IPaymentProvider _paymentProvider;

    public PaymentService(IPaymentProvider paymentProvider)
    {
        _paymentProvider = paymentProvider;
    }

    public void Pay(double amount)
    {
        _paymentProvider.ProcessPayment(amount);
    }
}

public interface IPaymentProvider
{
    void ProcessPayment(double amount);
}

public class PayPal : IPaymentProvider
{
    public void ProcessPayment(double amount)
    {
        Console.WriteLine($"{amount} Payment processing via PayPal...");
    }
}