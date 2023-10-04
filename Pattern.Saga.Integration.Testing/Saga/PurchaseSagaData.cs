using Rebus.Bus;
using Rebus.Handlers;
using Rebus.Sagas;

namespace Pattern.Saga.Integration.Testing.Saga
{
    /// <summary>
    /// Crie uma classe Saga para gerenciar o fluxo da compra
    /// </summary>
    public class PurchaseSagaData: ISagaData
    {
        public bool PaymentConfirmed { get; set; }
        public bool StockUpdated { get; set; }
        public bool EmailSent { get; set; }
        public Guid Id { get; set; }
        public int Revision { get; set; }
    }

    public class PurchaseSaga : Saga<PurchaseSagaData>,
        IAmInitiatedBy<AddToCartMessage>,
        IHandleMessages<PaymentConfirmationMessage>,
        IHandleMessages<StockUpdateMessage>
    {
        private readonly IBus _bus;

        public PurchaseSaga(IBus bus)
        {
            _bus = bus;
        }
        
        protected override void CorrelateMessages(ICorrelationConfig<PurchaseSagaData> config)
        {
            throw new NotImplementedException();
        }

        public async Task Handle(AddToCartMessage message)
        {
            // Etapa 1: Adicionar ao carrinho
            Data.Id = Guid.NewGuid();
            Console.WriteLine($"Produto '{message.ProductId}' adicionado ao carrinho para o usuário '{message.UserId}'");

            // Simule o processo de pagamento
            var paymentConfirmationMessage = new PaymentConfirmationMessage
            {
                UserId = message.UserId,
                Amount = 100.00m // Valor do pagamento simulado
            };
            await _bus.Send(paymentConfirmationMessage);
        }

        public async Task Handle(PaymentConfirmationMessage message)
        {
            // Etapa 2: Confirmação de pagamento
            Console.WriteLine($"Pagamento confirmado para o usuário '{message.UserId}' no valor de {message.Amount:C}");

            Data.PaymentConfirmed = true;

            // Simule a baixa no estoque
            var stockUpdateMessage = new StockUpdateMessage
            {
                ProductId = "Produto123",
                Quantity = 1 // Quantidade a ser atualizada no estoque simulado
            };
            await _bus.Send(stockUpdateMessage);
        }

        public async  Task Handle(StockUpdateMessage message)
        {
            // Etapa 3: Baixa no estoque
            Console.WriteLine($"Estoque atualizado para o produto '{message.ProductId}' em -{message.Quantity} unidades");

            Data.StockUpdated = true;

            // Simule o envio de email
            var emailMessage = new EmailNotificationMessage
            {
                UserId = Data.Id.ToString(),
                Message = "Sua compra foi concluída com sucesso!"
            };
            await _bus.Send(emailMessage);

            // Marque a saga como concluída
            MarkAsComplete();
        }
    }
}