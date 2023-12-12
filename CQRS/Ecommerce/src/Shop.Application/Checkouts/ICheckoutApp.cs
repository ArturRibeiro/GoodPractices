namespace Shop.Application.Checkouts;

public interface ICheckoutApp
{
    Either<Exception, CheckoutMessageResponse> Checkout(CheckoutMessageRequest request);
}