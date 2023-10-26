O padrão Chain of Responsibility em C#. Neste exemplo, criaremos uma cadeia de manipuladores para aprovar despesas. Vamos criar três tipos de manipuladores para funcionários **júnior**, **intermediário** e **sênior**, cada um com seu limite de aprovação.

```plaintext
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
```

```plaintext
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
```

```plaintext
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
```

Neste exemplo, criamos três classes para representar funcionários **júnior**, **intermediário** e **sênior**, cada uma com sua lógica de aprovação de despesas. Eles são conectados em uma cadeia de responsabilidade onde a despesa é enviada para o próximo gerente se o limite não for atendido. Isso permite que a despesa percorra a cadeia até ser aprovada ou rejeitada.

```plaintext
[Fact(DisplayName = "Pattern Chain Of Responsibility")]
public void ChainOfResponsibility()
{
    // Arrange
    var juniorManager = new JuniorManager();
    var intermediateManager = new IntermediateManager();
    var seniorManager = new SeniorManager();
    
    juniorManager
        .SetNextManager(intermediateManager)
        .SetNextManager(seniorManager);
    
    void ApproveExpense(ExpenseHandler manager, double amount) => manager.ApproveExpense(new Expense(amount));
    
    // Act
    ApproveExpense(juniorManager, 80);     // Aprovado pelo funcionário júnior
    ApproveExpense(juniorManager, 300);    // Aprovado pelo funcionário intermediário
    ApproveExpense(juniorManager, 1200);   // Aprovado pelo funcionário sênior
    ApproveExpense(juniorManager, 2500);   // Nenhum funcionário pode aprovar
    
    // Assert's
}
```