namespace Shop.Application.Checkouts.Imp;

public class CheckoutApp : ICheckoutApp
{
    private readonly IApplicationUser _applicationUser;
    private readonly IOrderRepository _orderRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IServiceClient _serviceClient;

    public CheckoutApp(IApplicationUser applicationUser
        , IOrderRepository orderRepository
        , IClientRepository clientRepository
        , IServiceClient serviceClient)
    {
        _applicationUser = applicationUser;
        _orderRepository = orderRepository;
        _clientRepository = clientRepository;
        _serviceClient = serviceClient;
    }

    public async Task<Either<Exception, CheckoutMessageResponse>> Checkout(
        CheckoutMessageRequest request)
    {
        var productReadModels = await _serviceClient.GetProductPrices(request.Products);

        Either<Exception, bool> x = Try<bool>.Cath(() =>
        {
            _orderRepository.Add(Order.Factory
                .Create()
                .AddClient(new Client(_applicationUser.UserId))
                .AddItem(() => GetItems(productReadModels))
                .Checkout());

            _orderRepository.UnitOfWork.SaveChangesAsync();

            return true;
        });

        // 1 - Confirmar Pagamento
        // 2 - Da baixa no estoque
        // 3 - Enviar o emial de pedido concluído

        return new Right<Exception, CheckoutMessageResponse>(new CheckoutMessageResponse(true));
    }

    private static IEnumerable<Item> GetItems(
        IEnumerable<ProductMessageResponse> productMessageRequests) =>
        from productMessageRequest in productMessageRequests
        let result = new { Product = new Product(productMessageRequest.Id, productMessageRequest.Price), productMessageRequest.Quantity }
        select new Item(result.Product, result.Quantity);
}