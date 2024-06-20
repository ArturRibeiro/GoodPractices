namespace Shared.Specifications.Sorts;

public class CompositeSpecificationSort<T> : ISpecificationSort<T>
{
    private readonly List<ISpecificationSort<T>> _specifications = new();

    public CompositeSpecificationSort<T> AddSpecification(ISpecificationSort<T> specification)
    {
        _specifications.Add(specification);
        return this;
    }

    public IQueryable<T> Apply(IQueryable<T> query, TypeSort sortOrder) => 
        _specifications.Aggregate(query, (current, specification) => specification.Apply(current, sortOrder));
}