using Refit;
using SpaceTraders.Infrastructure.Api.Models.Authentication;
using SpaceTraders.Infrastructure.Api.Models.Systems;
using SpaceTraders.Infrastructure.Modules.Responses.SystemsInformation;

namespace SpaceTraders.Infrastructure.Api.Calls;

public interface ISystemsApi
{
    [Get("/v2/systems")]
    Task<SystemsResponse> GetSystems([Body(BodySerializationMethod.Serialized)] CancellationToken token);
    
    [Get("/v2/systems/{systemSymbol}")]
    Task<GetSystemResponse> GetSystem(string systemSymbol, [Body(BodySerializationMethod.Serialized)] CancellationToken token);
}
