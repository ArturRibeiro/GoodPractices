namespace Shop.Infrastructure.Mediators;

public interface IIdempotentRequest : IRequest
{
    Guid CommandId { get; }
}

public interface IIdempotentNotification : INotification
{
    Guid CommandId { get; }
}