using MediatR;

namespace SpaceTraders.Infrastructure.Modules.ServerInformation.Messages;

public sealed record ServerInfoUpdated(ServerInformation ServerInformation) : INotification
{
    public ServerInformation ServerInformation { get; } = ServerInformation;
}