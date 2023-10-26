using System.Collections.Concurrent;
using Pattern.Saga.Integration.Testing.Saga;
using Rebus.Activation;
using Rebus.Config;
using Rebus.Transport.InMem;

namespace Pattern.Saga.Integration.Testing;

public class UnitTest1
{
    private static readonly ConcurrentDictionary<Guid, TaskCompletionSource<bool>> SagaCompletionTasks = new ConcurrentDictionary<Guid, TaskCompletionSource<bool>>();
    
    [Fact]
    public async Task Test1()
    {
        using var activator = new BuiltinHandlerActivator();
        Configure.With(activator)
            .Transport(t => t.UseInMemoryTransport(new InMemNetwork(), "eCommerce"))
            .Start();

        var bus = activator.Bus;

        var saga = new PurchaseSaga(bus);
        activator.Register(() => saga);

        var addToCartMessage = new AddToCartMessage
        {
            UserId = "Usuario123",
            ProductId = "ProdutoXYZ"
        };

        var completionSource = new TaskCompletionSource<bool>();

        // Registre um manipulador de eventos para marcar a conclusão da saga
        await bus.Subscribe<PurchaseSaga>();

        await bus.Send(addToCartMessage);

        // Aguarde até que a saga seja concluída ou falhe
        var sagaId = saga.Data.Id;
        var sagaCompletionTask = new TaskCompletionSource<bool>();
        SagaCompletionTasks.TryAdd(sagaId, sagaCompletionTask);
        await sagaCompletionTask.Task;

        Console.WriteLine("Pressione Enter para sair.");
        Console.ReadLine();
    }
}