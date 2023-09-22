namespace Writing.Architecture.Unit.Tests.Rules
{
    public class RulesDomain : TheoryData<Assembly, string>
    {
        public RulesDomain()
        {
            AddRow(Assembly.GetAssembly(typeof(IEntity)), HelperLayer.API);
            AddRow(Assembly.GetAssembly(typeof(IEntity)), HelperLayer.INFRA);
            AddRow(Assembly.GetAssembly(typeof(IEntity)), HelperLayer.APPLICATION);
        }
    }
}