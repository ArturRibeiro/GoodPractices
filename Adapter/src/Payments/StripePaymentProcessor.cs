namespace Pattern.Adapter.Payments
{
    public class StripePaymentProcessor
    {
        public void ChargeWithStripe(decimal amount) => Console.WriteLine($"Charging {amount:C} using Stripe.");
    }
}