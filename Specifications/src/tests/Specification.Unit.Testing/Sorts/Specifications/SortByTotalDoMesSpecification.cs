public class SortByTotalDoMesSpecification : ISpecificationSort<Vaga>
{
    public IQueryable<Vaga> Apply(IQueryable<Vaga> query, TypeSort sortOrder)
    {
        return sortOrder == TypeSort.Ascending
            ? query.OrderBy(v => v.Totalizadores
                .GroupBy(t => new { t.Data.Year, t.Data.Month })
                .Select(g => g.Sum(t => t.TotalDia))
                .FirstOrDefault())
            : query.OrderByDescending(v => v.Totalizadores
                .GroupBy(t => new { t.Data.Year, t.Data.Month })
                .Select(g => g.Sum(t => t.TotalDia))
                .FirstOrDefault());
    }
}