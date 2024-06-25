public class SortByTotalDoDiaSpecification : ISpecificationSort<Vaga>
{
    public IQueryable<Vaga> Apply(IQueryable<Vaga> query, TypeSort sortOrder)
    {
        return sortOrder == TypeSort.Ascending
            ? query.OrderBy(v => v.Totalizadores.Sum(t => t.TotalDia))
            : query.OrderByDescending(v => v.Totalizadores.Sum(t => t.TotalDia));
    }
}