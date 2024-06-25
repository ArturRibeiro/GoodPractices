namespace Specification.Unit.Testing.Sorts;

public class SpecificationSortTests
{
    [Theory]
    [ClassData(typeof(VagaFaker))]
    public void Ordenacao(IQueryable<Vaga> queryable, TypeSort sortOrder)
    {
        // Arrange
        // Exemplo de uso

        var sortByTotalizadorDay = new SortByDataEntradaSpecification();
        var sortByTotalizadorMonth = new SortByTotalDoDiaSpecification();
        var sortByTotalizadorDescricao = new SortByTotalDoDiaSpecification();
        var compositeSort = new CompositeSpecificationSort<Vaga>();
        compositeSort.AddSpecification(sortByTotalizadorMonth)
            .AddSpecification(sortByTotalizadorDay)
            .AddSpecification(sortByTotalizadorDescricao);

        // Act
        var result = compositeSort.Apply(queryable, sortOrder);

        // Assert
    }
}