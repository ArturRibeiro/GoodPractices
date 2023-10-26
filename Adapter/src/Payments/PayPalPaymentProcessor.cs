namespace Pattern.Adapter.Payments
{
    public class PayPalPaymentProcessor
    {
        public void MakePaymentWithPayPal(decimal amount) => Console.WriteLine($"Processing payment of {amount:C} with PayPal.");
    }
}