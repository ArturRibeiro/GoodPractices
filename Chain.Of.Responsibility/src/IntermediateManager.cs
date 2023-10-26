namespace Chain.Of.Responsibility
{
    /// <summary>
    /// Implementação do manipulador de despesas para funcionários intermediários
    /// </summary>
    public class IntermediateManager : ExpenseHandler
    {
        public override void ApproveExpense(Expense expense)
        {
            if (expense.Amount <= 500) Console.WriteLine($"Despesa de {expense.Amount:C} aprovada pelo funcionário intermediário.");
            else if (NextHandler is not null)
                NextHandler.ApproveExpense(expense);
            else Console.WriteLine($"Nenhum funcionário pode aprovar a despesa de {expense.Amount:C}.");
        }
    }
}