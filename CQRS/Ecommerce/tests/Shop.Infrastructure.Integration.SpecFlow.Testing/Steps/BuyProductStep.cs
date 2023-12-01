namespace Shop.Infrastructure.Integration.SpecFlow.Testing.Steps;

[Binding]
[Collection("ShopWebApplicationFactory")]
public class BuyProductStep
{
    private readonly ShopWebApplicationFactory _factory;

    public BuyProductStep(ShopWebApplicationFactory factory)
    {
        _factory = factory;
        _factory.ApplicationDbContext.Should().NotBeNull();
    }

    [Given(@"existe alguns produtos com nome e preço")]
    public async Task GivenExisteAlgunsProdutosComNomeEPreco()
    {
        var result = await _factory.Send<Dummy>("{dummy {id}}");
    }

    [Given(@"o usuário tem um carrinho de compras vazio")]
    public void GivenOUsuarioTemUmCarrinhoDeComprasVazio() { }

    [When(@"o usuário adiciona alguns produtos ao carrinho")]
    public void WhenOUsuarioAdicionaAlgunsProdutosAoCarrinho() { }

    [When(@"o usuário realiza o checkout")]
    public void WhenOUsuarioRealizaOCheckout() { }

    [Then(@"a ordem do usuário deve conter os mesmos Produtos e a mesma quantidade selecionadas")]
    public void ThenAOrdemDoUsuarioDeveConterOsMesmosProdutosEaMesmaQuantidadeSelecionadas() { }

    [Then(@"o estoque do produto deve ser reduzido de acordo com a quantidade selecionada pelo usuário")]
    public void ThenOEstoqueDoProdutoDeveSerReduzidoDeAcordoComAQuantidadeSelecionadaPeloUsuaroo() { }

    [Then(@"o status da ordem deve ser ""(.*)""")]
    public void ThenOStatusDaOrdemDeveSer(string pending) { }

    [When(@"o status da ordem é alterado para ""(.*)""")]
    public void WhenOStatusDaOrdemEAlteradoPara(string awaitingPayment) { }

    [When(@"o usuário realiza o pagamento")]
    public void WhenOUsuarioRealizaOPagamento() { }

    [When(@"o usuário cancela o pedido")]
    public void WhenOUsuarioCancelaOPedido() { }

    [When(@"o pedido é enviado")]
    public void WhenOPedidoEEnviado() { }

    [Then(@"o estoque do produto deve voltar a quantidade anterior")]
    public void ThenOEstoqueDoProdutoDeveVoltarAQuantidadeAnterior() { }
}