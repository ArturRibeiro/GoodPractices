namespace Chain.Of.Responsibility.Unit.Testing
{
    public class ChainOfResponsibilityTests
    {
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
    }
}