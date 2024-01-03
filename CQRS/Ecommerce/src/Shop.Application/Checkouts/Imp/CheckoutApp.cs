namespace Shop.Application.Checkouts.Imp;

public class CheckoutApp : IRequestHandler<CheckoutMessageRequest>
{
    private readonly IApplicationUser _applicationUser;
    private readonly IOrderRepository _orderRepository;
    private readonly IServiceClient _serviceClient;

    public CheckoutApp(IApplicationUser applicationUser
        , IOrderRepository orderRepository
        , IClientRepository clientRepository
        , IServiceClient serviceClient)
    {
        _applicationUser = applicationUser;
        _orderRepository = orderRepository;
        _serviceClient = serviceClient;
    }

    public async Task Handle(CheckoutMessageRequest request, CancellationToken cancellationToken)
    {
        var productReadModels = await _serviceClient.GetProductPrices(request.Products);

        Try<bool>.Cath(() =>
        {
            _orderRepository.Add(Order.Factory
                .Create()
                .AddClient(CreateClient(_applicationUser.UserId))
                .AddItem(() => GetItems(productReadModels))
                .Checkout());

            _orderRepository.UnitOfWork.SaveChangesAsync();

            return true;
        });

        // 1 - Confirmar Pagamento
        // 2 - Da baixa no estoque
        // 3 - Enviar o emial de pedido concluído
    }

    private static Func<long, Client> CreateClient = arg => new Client(arg);
    
    private static Func<IEnumerable<ProductMessageResponse>, IEnumerable<Item>> GetItems = productMessageRequests 
        => from productMessageRequest in productMessageRequests
        let result = new { Product = new Product(productMessageRequest.Id, productMessageRequest.Price), productMessageRequest.Quantity }
        select new Item(result.Product, result.Quantity);
}