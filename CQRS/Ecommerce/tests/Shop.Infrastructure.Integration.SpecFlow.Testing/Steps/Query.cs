namespace Shop.Infrastructure.Integration.SpecFlow.Testing.Steps;

public static class Query
{
    public static Dictionary<string, string> Dummy = new() { { "dummy", "id " } };

    public static Dictionary<string, string> Products = new()
        { { "products", "id name description price quantityInStock" } };
}

public record PaymentInformation(string CreditCardNumber, string CardValidityData, string CVV);

public record DeliveryInformation(string Street, string City, string State, string Country, string ZipCode);