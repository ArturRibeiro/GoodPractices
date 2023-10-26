using Pattern.Adapter.Imp;
using Pattern.Adapter.Payments;

namespace Pattern.Adapter.Unit.Testing.Fakes
{
    public class PaymentsFaker : TheoryData<IPaymentProcessor, decimal>
    {
        public PaymentsFaker()
        {
            Add(new PayPalAdapter(new PayPalPaymentProcessor()), 100.50m);
            Add(new StripeAdapter(new StripePaymentProcessor()), 10.50m);
        }
    }
}