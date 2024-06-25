public class SortByDataEntradaSpecification : ISpecificationSort<Vaga>
{
    public IQueryable<Vaga> Apply(IQueryable<Vaga> query, TypeSort sortOrder)
    {
        return sortOrder == TypeSort.Ascending
            ? query.OrderBy(v => v.Totalizadores.Min(t => t.Data))
            : query.OrderByDescending(v => v.Totalizadores.Min(t => t.Data));
    }
}