using TechTalk.SpecFlow.Assist;

namespace Shop.Infrastructure.Integration.SpecFlow.Testing.Steps;

[Binding]
[Collection("ShopWebApplicationFactory")]
public class BuyProductStep
{
    private readonly ShopWebApplicationFactory _factory;
    private readonly ScenarioContext _scenarioContext;
    private readonly ShoppingCart _shoppingCart;


    public BuyProductStep(ShopWebApplicationFactory factory, ScenarioContext scenarioContext)
    {
        _factory = factory;
        _factory.ApplicationDbContext.Should().NotBeNull();
        _scenarioContext = scenarioContext;
        _shoppingCart = new ShoppingCart();
    }

    [Given(@"que o usuário visualize todos os produto")]
    public async Task GivenQueOUsuarioVisualizeTodosOsProduto()
    {
        var queryGraphql = QueryGraphql
            .Instance("products", "id name description unitPrice quantityInStock")
            .Builder();
        
        var products = await _factory.SendQuery<List<ProductDto>>(queryGraphql);
        products.Should().NotBeNull();
        products.Value.Should().NotBeNull();
        products.Value.Should().HaveCountGreaterThan(1);
        _scenarioContext.Add("Products", products);
     }

    [Given(@"que o usuário seleciona alguns produto")]
    public async Task GivenQueOUsuarioSelecionaAlgunsProduto()
    {
        var allProduct = _scenarioContext.Get<Result<List<ProductDto>>>("Products");
        var chosenProducts = allProduct.RandomSelection(4);
        foreach (var productReadModel in chosenProducts) productReadModel.QuantityInStock = 1;
        _scenarioContext.Add("ChosenProducts", chosenProducts);
    }

    [Given(@"adiciona no carrinho de compras")]
    public void GivenAdicionaNoCarrinhoDeCompras() 
        => _shoppingCart.AddProducts(_scenarioContext.Get<List<ProductDto>>("ChosenProducts"));

    [When(@"o usuário inicia o processo de checkout")]
    public async Task WhenOUsuarioIniciaOProcessoDeCheckout() 
        => _shoppingCart.CheckOut();

    [Given(@"o usuário fornece informações de entrega válidas")]
    public async Task WhenOUsuarioForneceInformacoesDeEntregaValidas(Table table) 
        => _shoppingCart.AddDeliveryInformation(table.CreateInstance<DeliveryInformation>());

    [Given(@"o usuário fornece informações de pagamento válidas")]
    public async Task WhenOUsuarioForneceInformacoesDePagamentoValidas(Table table) 
        => _shoppingCart.AddPaymentInformation(table.CreateInstance<PaymentInformation>());

    [Then(@"a compra deve ser concluída com sucesso\.")]
    public async Task ThenACompraDeveSerConcluidaComSucesso()
    {
        var result = await this._factory.ExceuteMutationAsyn<ShoppingCart>(_shoppingCart.ToMutationGraphql());

        result.Should().NotBeNull();
    }
}