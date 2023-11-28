namespace Shop.Domain.Orders;

public class PaymentInfo : ValueObject<PaymentInfo>
{
    public string CardNumber { get; private set; }
    public DateTime ExpirationDate { get; private set; }
    public string Cvv { get; private set; }

    public PaymentInfo(string cardNumber, DateTime expirationDate, string cvv)
    {
        CardNumber = cardNumber;
        ExpirationDate = expirationDate;
        Cvv = cvv;
    }

    protected override IEnumerable<object> Reflect()
    {
        throw new NotImplementedException();
    }
}