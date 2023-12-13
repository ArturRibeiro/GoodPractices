namespace Shop.Application.Checkouts;

public interface ICheckoutApp
{
    Task<Either<Exception, CheckoutMessageResponse>> Checkout(CheckoutMessageRequest request);
}