namespace Shop.Domain.SharedKernel;

public abstract class Entity<T>
{
    public T Id { get; protected set; }
}