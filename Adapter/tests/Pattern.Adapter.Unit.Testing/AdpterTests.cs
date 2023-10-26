namespace Pattern.Adapter.Unit.Testing
{
    public class AdpterTests
    {
        [Theory]
        [ClassData(typeof(PaymentsFaker))]
        public void PaymentWithAdapter(IPaymentProcessor payment, decimal paymentAmount)
        {
            // Arrange
            
            // Act
            var result = payment.ProcessPayment(paymentAmount);

            // Asset's
            result.Should().BeTrue();
        }
    }
}