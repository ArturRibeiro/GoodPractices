namespace Shop.Domain.SharedKernel;

public class Price : ValueObject<Price>
{
    public long ValueInCents { get; }
    public decimal Value => ValueInCents / 100.0m;

    private Price(decimal value)
    {
        if (value < 0) throw new ArgumentException("O valor da unidade de preço não pode ser negativo.");
        var valueInCents = Convert.ToInt64(value * 100);
        ValueInCents = valueInCents;
    }

    public override string ToString() => $"R$ {ValueInCents / 100.0m:N2}";

    public override bool Equals(object obj) => Equals(obj as Price);

    public bool Equals(Price other) => other != null && ValueInCents == other.ValueInCents;

    public static bool operator ==(Price price1, Price price2) => Equals(price1, price2);

    public static bool operator !=(Price price1, Price price2) => !Equals(price1, price2);

    public static implicit operator Price(decimal value) => new(value);
    
    protected override IEnumerable<object> Reflect()
    {
        throw new NotImplementedException();
    }
}