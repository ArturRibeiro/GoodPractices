namespace Shop.Application.Checkouts;

public interface IServiceClient
{
    Task<IEnumerable<ProductMessageResponse>> GetProductPrices(ProductMessageRequest[] products);
}