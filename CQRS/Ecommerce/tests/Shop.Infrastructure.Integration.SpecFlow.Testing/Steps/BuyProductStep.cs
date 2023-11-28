namespace Shop.Infrastructure.Integration.SpecFlow.Testing.Steps;

[Binding]
public class BuyProductStep
{
    [Given(@"existe alguns produtos com nome e preço")]
    public void GivenExisteAlgunsProdutosComNomeEPreco() { }

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
    public void ThenOStatusDaOrdemDeveSer(string pending)
    {
    }

    [When(@"o status da ordem é alterado para ""(.*)""")]
    public void WhenOStatusDaOrdemEAlteradoPara(string awaitingPayment)
    {
    }

    [When(@"o usuário realiza o pagamento")]
    public void WhenOUsuarioRealizaOPagamento()
    {
    }

    [When(@"o usuário cancela o pedido")]
    public void WhenOUsuarioCancelaOPedido()
    {
    }

    [When(@"o pedido é enviado")]
    public void WhenOPedidoEEnviado()
    {
    }
}