namespace Specification.Unit.Testing.Sorts.Specifications;

public class SortByTotalizadorDescricaoSpecification : ISpecificationSort<VagaReadModel>
{
    private readonly Expression<Func<VagaReadModel, string>> OrdinationCriteriaDescricao = v => v.Descricao;
    
    public IQueryable<VagaReadModel> Apply(IQueryable<VagaReadModel> query, TypeSort sortOrder) =>
        sortOrder == TypeSort.Ascending 
            ? query.OrderBy(OrdinationCriteriaDescricao) 
            : query.OrderByDescending(OrdinationCriteriaDescricao);
}