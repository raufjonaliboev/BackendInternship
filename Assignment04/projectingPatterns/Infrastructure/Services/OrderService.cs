using projectingPatterns.Application.Common.Interfaces;
using projectingPatterns.Application.SOLID.ImprovedExample;

namespace projectingPatterns.Infrastructure.Services;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly INotificationService _notificationService;
    private readonly IPaymentProvider _paymentProvider;
    private readonly IPromotionService _promotionService;
    private readonly IDiscountStrategy _discountStrategy;

    public OrderService(
        IOrderRepository orderRepository, 
        INotificationService notificationService, 
        IPaymentProvider paymentProvider,
       IPromotionService promotionService, IDiscountStrategy discountStrategy)
    {
        _orderRepository = orderRepository;
        _notificationService = notificationService;
        _paymentProvider = paymentProvider;
        _promotionService = promotionService;
        _discountStrategy = discountStrategy;
    }
    public void PlaceOrder(double orderPrice)
    {
        var total = _promotionService.CalculatePromotion(_discountStrategy, orderPrice);
        var order = _orderRepository.CreateOrder();
        _paymentProvider.ProcessPayment(total);
        _notificationService.SendNotification();
    }
}