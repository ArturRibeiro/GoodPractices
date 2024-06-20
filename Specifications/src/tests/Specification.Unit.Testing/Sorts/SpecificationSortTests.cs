namespace Specification.Unit.Testing.Sorts;

public class SpecificationSortTests
{
    [Theory]
    [ClassData(typeof(VagaFaker))]
    public void Ordenacao(IQueryable<VagaReadModel> queryable, TypeSort sortOrder)
    {
        // Arrange
        // Exemplo de uso

        var sortByTotalizadorDay = new SortByTotalizadorDaySpecification();
        var sortByTotalizadorMonth = new SortByTotalizadorMonthTotalSpecification();
        var sortByTotalizadorDescricao = new SortByTotalizadorDescricaoSpecification();
        var compositeSort = new CompositeSpecificationSort<VagaReadModel>();
        compositeSort.AddSpecification(sortByTotalizadorMonth)
            .AddSpecification(sortByTotalizadorDay)
            .AddSpecification(sortByTotalizadorDescricao);

        // Act
        var result = compositeSort.Apply(queryable, sortOrder);

        // Assert
    }
}