using Rebus.Bus;

namespace Pattern.Saga.Application.Orders
{
    public class OrderCreateSaga : Saga<OrderCreateSagaData>
        , IAmInitiatedBy<OrderCreatedEvent>
        , IHandleMessages<OrderConfirmationEmail>
        , IHandleMessages<OrderPaymentRequestSent>
    {
        private readonly IBus _bus;

        public OrderCreateSaga(IBus bus) => _bus = bus;

        protected override void CorrelateMessages(ICorrelationConfig<OrderCreateSagaData> config)
        {
            config.Correlate<OrderCreatedEvent>(x => x.orderId, s => s.OrderId);
            config.Correlate<OrderConfirmationEmail>(x => x.orderId, s => s.OrderId);
            config.Correlate<OrderPaymentRequestSent>(x => x.orderId, s => s.OrderId);
        }

        public async Task Handle(OrderCreatedEvent message)
        {
            if (!IsNew) return;
            await _bus.Send(new OrderOrderConfirmationEmail(message.orderId));
        }

        public async Task Handle(OrderConfirmationEmail message) => throw new NotImplementedException();

        public async Task Handle(OrderPaymentRequestSent message) => throw new NotImplementedException();
    }
}