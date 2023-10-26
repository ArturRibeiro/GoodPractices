namespace Chain.Of.Responsibility
{
    /// <summary>
    ///  Implementação do manipulador de despesas para funcionários sênior
    /// </summary>
    public class SeniorManager : ExpenseHandler
    {
        public override void ApproveExpense(Expense expense)
        {
            if (expense.Amount <= 1000) Console.WriteLine($"Despesa de {expense.Amount:C} aprovada pelo funcionário sênior.");
            else if (NextHandler != null) NextHandler.ApproveExpense(expense);
            else Console.WriteLine($"Nenhum funcionário pode aprovar a despesa de {expense.Amount:C}.");
        }
    }
}