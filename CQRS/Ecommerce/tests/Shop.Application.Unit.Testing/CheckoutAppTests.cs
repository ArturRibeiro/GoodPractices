namespace Shop.Application.Unit.Testing;

public class CheckoutAppTests
{
    private readonly Mock<IApplicationUser> _applicationUser = new();
    private readonly Mock<IClientRepository> _clientRepository = new();
    private readonly Mock<IOrderRepository> _orderRepository = new();

    
    [Theory]
    [ClassData(typeof(CheckoutMessageRequestFaker))]
    public void CheckoutSuccess(CheckoutMessageRequest request, Client client)
    {
        // Stub's
        _clientRepository.Setup(x => x.GetById(It.IsAny<long>())).Returns(client);
        _orderRepository.Setup(x => x.Add(It.IsAny<Order>()));
        
        var app = new CheckoutApp(_applicationUser.Object, _orderRepository.Object, _clientRepository.Object);

        // Act
        var result = app.Checkout(request);
        
        //Assert's
        _orderRepository.Verify(x => x.Add(It.IsAny<Order>()), Times.Once);
    }
}