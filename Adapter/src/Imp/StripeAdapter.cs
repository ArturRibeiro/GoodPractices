using Pattern.Adapter.Payments;

namespace Pattern.Adapter.Imp
{
    public class StripeAdapter : IPaymentProcessor
    {
        private StripePaymentProcessor stripeProcessor;

        public StripeAdapter(StripePaymentProcessor processor) => this.stripeProcessor = processor;

        public bool ProcessPayment(decimal amount)
        {
            stripeProcessor.ChargeWithStripe(amount);
            return true;
        }
    }
}