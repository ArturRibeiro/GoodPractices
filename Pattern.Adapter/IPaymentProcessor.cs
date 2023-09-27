namespace Pattern.Adapter
{
    public interface IPaymentProcessor
    {
        bool ProcessPayment(decimal amount);
    }
}