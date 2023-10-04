namespace Pattern.Saga.Application.Orders
{
    public class OrderCreateSagaData : ISagaData
    {
        public Guid Id { get; set; }
        public int Revision { get; set; }
        public Guid OrderId { get; set; }
        public bool WelcomeEmailSend { get; set; }
        public bool PaymentRequestSent { get; set; }
    }
}