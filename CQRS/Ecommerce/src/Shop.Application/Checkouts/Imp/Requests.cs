namespace Shop.Application.Checkouts.Imp;

public record CheckoutMessageRequest (ProductMessageRequest [] Products
    , CreditCardMessageRequest CreditCard
    , UserShippingAddressMessageRequest ShippingAddress);
public record CreditCardMessageRequest (string Number, string ExpirationDate, string CVV);
public record ProductMessageRequest (long Id, int Quantity);
public record UserShippingAddressMessageRequest (int Option);