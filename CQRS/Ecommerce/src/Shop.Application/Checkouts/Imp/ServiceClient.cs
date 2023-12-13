namespace Shop.Application.Checkouts.Imp;

public class ServiceClient : IServiceClient
{
    public async Task<IEnumerable<ProductMessageResponse>> GetProductPrices(ProductMessageRequest[] ids)
    {
        throw new NotImplementedException();
    }
}