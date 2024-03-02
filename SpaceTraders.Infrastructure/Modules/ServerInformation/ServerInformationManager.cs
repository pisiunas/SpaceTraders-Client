using MediatR;
using SpaceTraders.Infrastructure.Api.Calls;
using SpaceTraders.Infrastructure.Interfaces;
using SpaceTraders.Infrastructure.Messaging.Interfaces;
using SpaceTraders.Infrastructure.Modules.Responses.ServerInformation;
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

    public ServerInformationResponse GetServerInformation()
    {
        Task<ServerInformationResponse> response = _serverInformationApi.GetServerStatus(CancellationToken.None);

        _messagePublisher.Publish(new ServerInfoUpdated(response.Result), CancellationToken.None);

        return response.Result;
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
