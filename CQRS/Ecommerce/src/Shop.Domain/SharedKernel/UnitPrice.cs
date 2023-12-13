namespace Shop.Domain.SharedKernel;

public class UnitPrice : ValueObject<UnitPrice>
{
    public long ValueInCents { get; }
    public decimal Value => ValueInCents / 100.0m;

    private UnitPrice(decimal value)
    {
        if (value < 0) throw new ArgumentException("O valor da unidade de preço não pode ser negativo.");
        var valueInCents = Convert.ToInt64(value * 100);
        ValueInCents = valueInCents;
    }

    public override string ToString() => $"R$ {ValueInCents / 100.0m:N2}";

    public override bool Equals(object obj) => Equals(obj as UnitPrice);

    public bool Equals(UnitPrice other) => other != null && ValueInCents == other.ValueInCents;

    public static bool operator ==(UnitPrice price1, UnitPrice price2) => Equals(price1, price2);

    public static bool operator !=(UnitPrice price1, UnitPrice price2) => !Equals(price1, price2);

    public static implicit operator UnitPrice(decimal value) => new(value);
    
    protected override IEnumerable<object> Reflect()
    {
        throw new NotImplementedException();
    }
}