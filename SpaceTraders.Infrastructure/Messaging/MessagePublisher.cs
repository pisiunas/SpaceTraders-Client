using Autofac;
using MediatR;
using SpaceTraders.Infrastructure.Messaging.Interfaces;

namespace SpaceTraders.Infrastructure.Messaging;

public class MessagePublisher : IMessagePublisher
{
    private readonly ILifetimeScope _lifetimeScope;
    
    public MessagePublisher(IComponentContext context)
    {
        _lifetimeScope = context.Resolve<ILifetimeScope>();
    }

    public async Task Publish<T>(T notification, CancellationToken token) where T : INotification
    {
        await using var scope = _lifetimeScope.BeginLifetimeScope();
        var mediator = scope.Resolve<IMediator>();

        await mediator.Publish(notification, token);
    }

    public async Task Publish<T>(T notification) where T : INotification
    {
        await using var scope = _lifetimeScope.BeginLifetimeScope();
        var mediator = scope.Resolve<IMediator>();

        await mediator.Publish(notification);
    }
}