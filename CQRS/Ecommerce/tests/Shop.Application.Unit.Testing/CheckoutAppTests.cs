namespace Shop.Application.Unit.Testing;

public class CheckoutAppTests
{
    private readonly Mock<IApplicationUser> _applicationUser = new();
    private readonly Mock<IClientRepository> _clientRepository = new();
    private readonly Mock<IOrderRepository> _orderRepository = new();
    private readonly Mock<IServiceClient> _serviceClient = new();

    
    [Theory]
    [ClassData(typeof(CheckoutMessageRequestFaker))]
    public async Task CheckoutSuccess(CheckoutMessageRequest request, Client client)
    {
        // Stub's
        _clientRepository.Setup(x => x.GetById(It.IsAny<long>())).Returns(client);
        _orderRepository.Setup(x => x.Add(It.IsAny<Order>()));
        
        var app = new CheckoutApp(_applicationUser.Object, _orderRepository.Object, _clientRepository.Object, _serviceClient.Object);

        // Act
        var result = app.Handle(request, CancellationToken.None);
        
        //Assert's
        _orderRepository.Verify(x => x.Add(It.IsAny<Order>()), Times.Once);
        _serviceClient.Verify(x => x.GetProductPrices(It.IsAny<ProductMessageRequest[]>()), Times.Once);
    }
}