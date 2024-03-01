using MediatR;
using NLog;
using SpaceTraders.Infrastructure.Messaging.Interfaces;

namespace SpaceTraders.Infrastructure.Messaging;

public class MessagesLogging : IMessagePublisher
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private readonly IMessagePublisher _messagePublisher;

    public MessagesLogging(IMessagePublisher messagePublisher)
    {
        _messagePublisher = messagePublisher;
    }

    public Task Publish<T>(T notification, CancellationToken token) where T : INotification
    {
        _logger.Debug("Publishing {notificationName}, {@notification}", notification.GetType().Name, notification);
        return _messagePublisher.Publish(notification, token);
    }

    public Task Publish<T>(T notification) where T : INotification
    {
        _logger.Debug("Publishing {notificationName}, {@notification}", notification.GetType().Name, notification);
        return _messagePublisher.Publish(notification);
    }
}