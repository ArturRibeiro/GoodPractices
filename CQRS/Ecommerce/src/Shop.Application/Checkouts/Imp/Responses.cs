namespace Shop.Application.Checkouts.Imp;

public record CheckoutMessageResponse(bool Success);

public record ProductMessageResponse(long Id, decimal Price, int Quantity);