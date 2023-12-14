namespace Shop.Application.Checkouts.Imp;

public class ServiceClient : IServiceClient
{
    private readonly ApplicationDbContext _context;
    public ServiceClient(ApplicationDbContext context) => _context = context;

    public async Task<IEnumerable<ProductMessageResponse>> GetProductPrices(ProductMessageRequest[] productsMessage) =>
        (from product in _context.Products
            let ids = productsMessage.Select(x => x.Id).ToArray()
            where ids.Contains(product.Id)
            select new ProductMessageResponse(product.Id, product.Price.Value, product.QuantityInStock))
        .AsEnumerable();
}