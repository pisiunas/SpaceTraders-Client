using MediatR;
using NLog;
using SpaceTraders.Infrastructure.Modules.HomePage.Messages;

namespace SpaceTraders.Infrastructure.Messages;

public class PingHandler : INotificationHandler<Ping>
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    
    public Task Handle(Ping notification, CancellationToken cancellationToken)
    {
        _logger.Info("Pinged");
        return Task.CompletedTask;
    }
}