namespace Writing.Architecture.Unit.Tests.Rules
{
    public class RulesApplication : TheoryData<Assembly, string>
    {
        public RulesApplication()
        {
            AddRow(Assembly.GetAssembly(typeof(Application.Class1)), HelperLayer.API);
        }
    }
}