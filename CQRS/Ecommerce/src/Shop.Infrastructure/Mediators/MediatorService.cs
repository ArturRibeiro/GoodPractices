namespace Shop.Infrastructure.Mediators;

public class MediatorService
{
    private readonly IMediator _mediator;

    public MediatorService(IMediator mediator) => _mediator = mediator;

    public async Task Send<T>(T comando)
        where T : IRequest
        => await _mediator.Send(comando);

    public async Task PublishEvent<T>(T evento)
        where T : INotification
        => await _mediator.Publish(evento);
}