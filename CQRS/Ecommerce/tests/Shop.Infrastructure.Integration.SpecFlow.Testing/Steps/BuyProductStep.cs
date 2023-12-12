using Shop.Api.Reads.Models;
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

    


    // [When(@"o usuário inicia o processo de checkout")]
    // public void WhenOUsuarioRealizaOCheckout(Table table)
    // {
    //     var fromStep = table.CreateInstance<PaymentInformation>();
    //     
    //     // // Assertions
    //     // si.Title.Should().Equal(fromStep.CardValidityData);
    //     // si.Tags.Should().BeEquivalentTo(fromStep.Tags);
    //     // si.CombinedTags.Should().BeEquivalentTo(fromStep.CombinedTags);
    // }


    [Given(@"que o usuário visualize todos os produto")]
    public async Task GivenQueOUsuarioVisualizeTodosOsProduto()
    {
        var queryGraphql = QueryGraphql
            .Instance("products", "id name description price quantityInStock")
            .Builder();
        
        var products = await _factory.SendQuery<List<ProductReadModel>>(queryGraphql);
        products.Should().NotBeNull();
        products.Value.Should().NotBeNull();
        products.Value.Should().HaveCountGreaterThan(1);
        _scenarioContext.Add("Products", products);
     }

    [Given(@"que o usuário seleciona alguns produto")]
    public async Task GivenQueOUsuarioSelecionaAlgunsProduto()
    {
        var allProduct = _scenarioContext.Get<Result<List<ProductReadModel>>>("Products");
        var chosenProducts = allProduct.RandomSelection(4);
        _scenarioContext.Add("ChosenProducts", chosenProducts);
    }

    [Given(@"adiciona no carrinho de compras")]
    public void GivenAdicionaNoCarrinhoDeCompras() 
        => _shoppingCart.AddProducts(_scenarioContext.Get<List<ProductReadModel>>("ChosenProducts"));

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
        var t = _shoppingCart.Products.Select(x => new { id = x.Id, quantity = x.QuantityInStock }).ToArray();
        var jsonProducts = JsonConvert.SerializeObject(t).Replace("\"", " ");
            
        var mutation = MutationGraphql
            .Instance("checkout")
            .AddQuery(@"shippingAddress: { option: 1 }
                        products: #PRODUCTS#
                        creditCard: {
                          number: ""98756456498654""
                          expirationDate: ""102028""
                          cvv: ""011""
                        }".Replace("#PRODUCTS#", jsonProducts))
            .AddGraphQLResult("success")
            .Builder();

        var result = await this._factory.ExceuteMutationAsyn<ShoppingCart>(mutation);
    }
}