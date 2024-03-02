using MediatR;
using SpaceTraders.Infrastructure.Api.Calls;
using SpaceTraders.Infrastructure.Modules.NavigationGrid.Commands;
using SpaceTraders.Infrastructure.Modules.Responses.SystemsInformation;

namespace SpaceTraders.Infrastructure.Modules.NavigationGrid;

public class LocalSystemDataRequestHandler : IRequestHandler<RequestLocalSystemData, GetSystemResponse>
{
    private readonly ISystemsApi _systemsApi;

    public LocalSystemDataRequestHandler(ISystemsApi systemsApi)
    {
        _systemsApi = systemsApi;
    }

    public Task<GetSystemResponse> Handle(RequestLocalSystemData request, CancellationToken cancellationToken) => _systemsApi.GetSystem(request.SystemSymbol, cancellationToken);
}
