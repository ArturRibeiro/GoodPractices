namespace Specification.Unit.Testing.Sorts.Fakers;

public class VagaFaker : TheoryData<Vaga, TypeSort>
{
    public VagaFaker()
    {
        AddRow(GenerateVagas(), TypeSort.Ascending);
        AddRow(GenerateVagas(), TypeSort.Descending);
    }
    
    public static IQueryable<Vaga> GenerateVagas() => new List<Vaga>()
    {
        new()
        {
            Totalizadores = new List<Totalizador>
            {
                new() { Data = new DateTime(2024, 6, 18), TotalDia = 10 },
                new() { Data = new DateTime(2024, 6, 19), TotalDia = 20 }
            }
        },

        new()
        {
            Totalizadores = new List<Totalizador>
            {
                new() { Data = new DateTime(2024, 6, 17), TotalDia = 5 },
                new() { Data = new DateTime(2024, 6, 20), TotalDia = 25 }
            }
        }
    }.AsQueryable();
}