namespace Pattern.Saga.Application.Orders
{
    public record OrderCreatedEvent(Guid orderId);
    public record OrderConfirmationEmail(Guid orderId);
    public record OrderPaymentRequestSent(Guid orderId);
    public record OrderOrderConfirmationEmail(Guid orderId);
}