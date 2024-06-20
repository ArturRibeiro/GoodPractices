namespace Specification.Unit.Testing.Sorts.Specifications;

public class SortByTotalizadorMonthTotalSpecification : ISpecificationSort<VagaReadModel>
{
    private readonly Expression<Func<VagaReadModel, int>> OrdinationCriteriaSortByTotalizadorMonthTotal = v => v.TotalMes;
    
    public IQueryable<VagaReadModel> Apply(IQueryable<VagaReadModel> query, TypeSort sortOrder)
    {
        if (query.Any(x=>x.TotalDia == 0))
            return sortOrder == TypeSort.Ascending
                ? query.OrderBy(OrdinationCriteriaSortByTotalizadorMonthTotal)
                : query.OrderByDescending(OrdinationCriteriaSortByTotalizadorMonthTotal);
        
        return query;

    }
}