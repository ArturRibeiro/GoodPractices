namespace Chain.Of.Responsibility
{
    /// <summary>
    /// Classe abstrata que define um manipulador de despesas
    /// </summary>
    public abstract class ExpenseHandler
    {
        protected ExpenseHandler NextHandler;

        public ExpenseHandler SetNextManager(ExpenseHandler handler) => NextHandler = handler;

        public abstract void ApproveExpense(Expense expense);
    }
}