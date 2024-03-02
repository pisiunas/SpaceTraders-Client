using MediatR;
using SpaceTraders.Infrastructure.Modules.Responses.ServerInformation;

namespace SpaceTraders.Infrastructure.Modules.ServerInformation.Messages;

public sealed record ServerInfoUpdated(ServerInformationResponse ServerInformation) : INotification
{
    public ServerInformationResponse ServerInformation { get; } = ServerInformation;
}
