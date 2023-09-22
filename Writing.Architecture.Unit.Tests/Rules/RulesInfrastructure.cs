using Infrastructure;

namespace Writing.Architecture.Unit.Tests.Rules
{
    public class RulesInfrastructure : TheoryData<Assembly, string>
    {
        public RulesInfrastructure()
        {
            AddRow(Assembly.GetAssembly(typeof(Repository)), HelperLayer.API);
            AddRow(Assembly.GetAssembly(typeof(Repository)), HelperLayer.APPLICATION);
        }
    }
}