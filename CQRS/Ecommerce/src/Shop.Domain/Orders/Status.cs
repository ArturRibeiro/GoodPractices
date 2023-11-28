namespace Shop.Domain.Orders;

public class Status : ValueObject<Status>
{
    public static readonly Status Pending = new(1, "Pending","O cliente iniciou o processo de checkout, mas não o concluiu. Os pedidos incompletos recebem o status Pendente e podem ser encontrados na guia Mais na tela Ver pedidos.");
    public static readonly Status AwaitingPayment  = new(2,"AwaitingPayment", "O cliente concluiu o processo de finalização da compra, mas o pagamento ainda não foi confirmado. Autorizar apenas transações que ainda não foram capturadas têm esse status.");
    public static readonly Status AwaitingShipment   = new(3,"AwaitingShipment", "O pedido foi retirado e embalado e aguarda coleta de um fornecedor de remessa.");
    public static readonly Status Shipped   = new(4, "Shipped", "O pedido foi enviado, mas o recebimento não foi confirmado; o vendedor usou a ação Enviar Itens. Uma lista de todos os pedidos com status Enviado pode ser encontrada na guia Mais da tela Visualizar pedidos.");
    public static readonly Status Cancelled = new(5, "Cancelled","O vendedor cancelou um pedido devido a inconsistência de estoque ou outros motivos. Os níveis de estoque serão atualizados automaticamente dependendo das suas configurações de inventário. O cancelamento de um pedido não reembolsará o pedido. ");
    public static readonly Status Completed = new(6, "Completed","A encomenda foi expedida/retirada e a receção está confirmada; cliente pagou por seu produto digital e seus arquivos estão disponíveis para download.");

    protected Status() { }
    
    private Status(int id, string name, string description)
    {
        this.Id = id;
        this.Name = name;
        this.Description = description;
    }

    public string Description { get; }

    public int Id { get; }
    public string Name { get; }

    protected override IEnumerable<object> Reflect()
    {
        yield return Pending;
        yield return AwaitingPayment;
        yield return AwaitingShipment;
        yield return Shipped;
        yield return Cancelled;
        yield return Completed;
    }
}