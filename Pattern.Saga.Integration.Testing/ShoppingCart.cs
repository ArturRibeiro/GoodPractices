namespace Pattern.Saga.Integration.Testing
{
    /// <summary>
    /// Defina uma mensagem para representar a adição de um item ao carrinho
    /// </summary>
    public class AddToCartMessage
    {
        public string UserId { get; set; }
        public string ProductId { get; set; }
    }
    
    /// <summary>
    /// Defina uma mensagem para representar a confirmação de pagamento
    /// </summary>
    public class PaymentConfirmationMessage
    {
        public string UserId { get; set; }
        public decimal Amount { get; set; }
    }
    
    /// <summary>
    /// Defina uma mensagem para representar a baixa no estoque
    /// </summary>
    public class StockUpdateMessage
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
    
    /// <summary>
    /// Defina uma mensagem para representar o envio de email
    /// </summary>
    public class EmailNotificationMessage
    {
        public string UserId { get; set; }
        public string Message { get; set; }
    }
    
    

}
