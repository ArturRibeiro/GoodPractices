namespace Chain.Of.Responsibility
{
    /// <summary>
    /// Implementação do manipulador de despesas para funcionários júnior
    /// </summary>
    public class JuniorManager : ExpenseHandler
    {
        public override void ApproveExpense(Expense expense)
        {
            if (expense.Amount <= 100) Console.WriteLine($"Despesa de {expense.Amount:C} aprovada pelo funcionário júnior.");
            else if (NextHandler != null) NextHandler.ApproveExpense(expense);
            else Console.WriteLine($"Nenhum funcionário pode aprovar a despesa de {expense.Amount:C}.");
        }
    }
}