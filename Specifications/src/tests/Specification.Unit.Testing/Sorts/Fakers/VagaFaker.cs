namespace Specification.Unit.Testing.Sorts.Fakers;

public class VagaFaker : TheoryData<VagaReadModel, TypeSort>
{
    public VagaFaker()
    {
        var queryable = new List<VagaReadModel>()
        {
            new() { Descricao = "Vaga 1", TotalDia = 0 },
            new() { Descricao = "Vaga 2", TotalDia = 0 },
            new() { Descricao = "Vaga 3", TotalDia = 0 },
            new() { Descricao = "Vaga 4", TotalDia = 0 },
            new() { Descricao = "Vaga 5", TotalDia = 0 }
        }.AsQueryable();

        AddRow(queryable, TypeSort.Ascending);
        AddRow(queryable, TypeSort.Descending);
    }
}