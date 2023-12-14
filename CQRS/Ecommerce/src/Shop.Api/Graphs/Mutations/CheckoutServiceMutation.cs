using Shop.Application.Extensions;
using Shop.Infrastructure.Mediators;

namespace Shop.Api.Graphs.Mutations;

[ExtendObjectType("Mutation")]
public record CheckoutServiceMutation
{
    public CheckoutMessageResponse Checkout(
        CheckoutMessageRequest input
        , [Service] MediatorService service)
    {
        service.Send(input);
        
        return new CheckoutMessageResponse(true);
    }
}