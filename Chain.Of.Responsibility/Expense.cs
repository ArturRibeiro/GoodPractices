namespace Chain.Of.Responsibility
{
    /// <summary>
    /// Classe que representa uma despesa
    /// </summary>
    public class Expense
    {
        public double Amount { get; }

        public Expense(double amount)
        {
            Amount = amount;
        }
    }
}