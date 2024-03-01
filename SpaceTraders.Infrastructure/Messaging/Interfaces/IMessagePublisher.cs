using MediatR;

namespace SpaceTraders.Infrastructure.Messaging.Interfaces;

public interface IMessagePublisher
{
    public Task Publish<T>(T notification, CancellationToken token) where T : INotification;

    public Task Publish<T>(T notification) where T : INotification;
}