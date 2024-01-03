using Newtonsoft.Json;

namespace Shop.Infrastructure.Mediators;

public class MediatorService
{
    private readonly IMediator _mediator;
    private readonly IEventSourcingRepository _eventSourcingRepository;

    public MediatorService(IMediator mediator, IEventSourcingRepository eventSourcingRepository)
    {
        _mediator = mediator;
        _eventSourcingRepository = eventSourcingRepository;
    }

    public async Task Send<T>(T message)
        where T : IIdempotentRequest
    {
        await _mediator.Send(message);
        var id = message as IIdempotentRequest;
        _eventSourcingRepository.Add(CreateStorage(typeof(T), id.CommandId, message));
        await _eventSourcingRepository.UnitOfWork.SaveChangesAsync();
    }

    public async Task PublishEvent<T>(T message)
        where T : IIdempotentNotification
    {
        await _mediator.Publish(message);
        var empotentNotification = message as IIdempotentNotification;
        _eventSourcingRepository.Add(CreateStorage(typeof(T), empotentNotification.CommandId, message));
        await _eventSourcingRepository.UnitOfWork.SaveChangesAsync();
    }


    private static Func<Type, Guid, object, Storage> CreateStorage = (type, commmandId, obj) => new Storage(commmandId, type.Name, JsonConvert.SerializeObject(obj));
}