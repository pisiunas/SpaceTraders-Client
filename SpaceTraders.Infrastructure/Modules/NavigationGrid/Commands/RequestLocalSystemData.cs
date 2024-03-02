using MediatR;
using SpaceTraders.Infrastructure.Modules.Responses.SystemsInformation;

namespace SpaceTraders.Infrastructure.Modules.NavigationGrid.Commands;

public sealed record RequestLocalSystemData(string SystemSymbol) : IRequest<GetSystemResponse>
{
    public string SystemSymbol { get; set; } = SystemSymbol;
}
