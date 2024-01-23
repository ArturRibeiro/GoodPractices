namespace Shop.Application.Unit.Testing;

public class CheckoutAppTests
{
    private readonly Mock<IApplicationUser> _applicationUser = new();
    private readonly Mock<IClientRepository> _clientRepository = new();
    private readonly Mock<IOrderRepository> _orderRepository = new();
    private readonly Mock<IServiceClient> _serviceClient = new();
    private readonly Mock<IUnitOfWork> _unitOfWork = new();

    
    [Theory]
    [ClassData(typeof(CheckoutMessageRequestFaker))]
    public async Task CheckoutSuccess(CheckoutMessageRequest request, Client client)
    {
        // Stub's
        _orderRepository.Setup(x => x.Add(It.IsAny<Order>()));
        _orderRepository.SetupGet(x => x.UnitOfWork).Returns(_unitOfWork.Object);
        
        var app = new CheckoutApp(_applicationUser.Object, _orderRepository.Object, _serviceClient.Object);

        // Act
        var result = app.Handle(request, CancellationToken.None);
        
        //Assert's
        _orderRepository.Verify(x => x.Add(It.IsAny<Order>()), Times.Once);
        _unitOfWork.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}