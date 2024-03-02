using Refit;
using SpaceTraders.Infrastructure.Api.Models;
using SpaceTraders.Infrastructure.Modules.Responses.ServerInformation;

namespace SpaceTraders.Infrastructure.Api.Calls;

public interface IServerInformationApi
{
    [Get("/v2")]
    Task<ServerInformationResponse> GetServerStatus([Body(BodySerializationMethod.Serialized)] CancellationToken token);
}
