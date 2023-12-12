namespace Shop.Application.Checkouts.Imp;

public class CheckoutApp : ICheckoutApp
{
    private readonly IApplicationUser _applicationUser;
    private readonly IOrderRepository _orderRepository;
    private readonly IClientRepository _clientRepository;

    public CheckoutApp(IApplicationUser applicationUser
        , IOrderRepository orderRepository
        , IClientRepository clientRepository)
    {
        _applicationUser = applicationUser;
        _orderRepository = orderRepository;
        _clientRepository = clientRepository;
    }

    public Either<Exception, CheckoutMessageResponse> Checkout(
        CheckoutMessageRequest request)
    {
        Either<Exception, bool> x = Try<bool>.Cath(() =>
        {
            _orderRepository.Add(Order.Factory
                .Create()
                .AddClient(new Client(_applicationUser.UserId))
                .AddItem(() => GetItems(request.Products))
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
        ProductMessageRequest[] productMessageRequests) =>
        from productMessageRequest in productMessageRequests
        let product = new { Product = new Product(productMessageRequest.Id), productMessageRequest.Quantity }
        select new Item(product.Product, product.Quantity);
}