using Pattern.Adapter.Payments;

namespace Pattern.Adapter.Imp
{
    public class PayPalAdapter : IPaymentProcessor
    {
        private PayPalPaymentProcessor paypalProcessor;

        public PayPalAdapter(PayPalPaymentProcessor processor) => this.paypalProcessor = processor;

        public bool ProcessPayment(decimal amount)
        {
            paypalProcessor.MakePaymentWithPayPal(amount);
            return true;
        }
    }
}