using MediatR;

namespace SpaceTraders.Infrastructure.Modules.ServerInformation.Messages;

public sealed record ServerInfoRequested : INotification;