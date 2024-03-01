using MediatR;
using SpaceTraders.Infrastructure.Api.Calls;
using SpaceTraders.Infrastructure.Interfaces;
using SpaceTraders.Infrastructure.Messaging.Interfaces;
using SpaceTraders.Infrastructure.Modules.ServerInformation.Messages;

namespace SpaceTraders.Infrastructure.Modules.ServerInformation;

public class ServerInformationManager : IServerInformationManager, IOnStartup
{
    private readonly IServerInformationApi _serverInformationApi;
    private readonly IMessagePublisher _messagePublisher;

    public ServerInformationManager(IServerInformationApi serverInformationApi, IMessagePublisher messagePublisher)
    {
        _serverInformationApi = serverInformationApi;
        _messagePublisher = messagePublisher;
    }

    public ServerInformation GetServerInformation()
    {
        var response = _serverInformationApi.GetServerStatus(CancellationToken.None);

        var serverInfo = new ServerInformation(response.Result.Status, response.Result.Version, response.Result.ResetDate,
            response.Result.Description, response.Result.StatsList.Agents, response.Result.StatsList.Ships,
            response.Result.StatsList.Systems, response.Result.StatsList.Waypoints);

        _messagePublisher.Publish(new ServerInfoUpdated(serverInfo), CancellationToken.None);

        return serverInfo;
    }

    public Task Handle(ServerInfoRequested notification, CancellationToken cancellationToken)
    {
        GetServerInformation();
        return Task.CompletedTask;
    }

    public Task OnStartup()
    {
        GetServerInformation();
        return Task.CompletedTask;
    }
}