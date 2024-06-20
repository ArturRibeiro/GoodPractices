namespace Specification.Unit.Testing.Sorts.Specifications;

public class SortByTotalizadorDaySpecification : ISpecificationSort<VagaReadModel>
{
    private readonly Expression<Func<VagaReadModel, int>> OrdinationCriteriaSortByTotalizadorDay = v => v.TotalDia;
    
    public IQueryable<VagaReadModel> Apply(IQueryable<VagaReadModel> query, TypeSort sortOrder)
    {
        if (query.Any(x=>x.TotalDia > 0))
            return sortOrder == TypeSort.Ascending
            ? query.OrderBy(OrdinationCriteriaSortByTotalizadorDay)
            : query.OrderByDescending(OrdinationCriteriaSortByTotalizadorDay);
        return query;
    }
}