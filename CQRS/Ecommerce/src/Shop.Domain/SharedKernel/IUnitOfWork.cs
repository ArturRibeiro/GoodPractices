namespace Shop.Domain.SharedKernel;

public interface IUnitOfWork : IDisposable
{
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
}