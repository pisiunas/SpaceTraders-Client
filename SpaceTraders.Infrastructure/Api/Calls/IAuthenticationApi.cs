using Refit;
using SpaceTraders.Infrastructure.Api.Models.Authentication;
using SpaceTraders.Infrastructure.Modules.Responses.UserInformation;

namespace SpaceTraders.Infrastructure.Api.Calls;

public interface IAuthenticationApi
{
    [Post("/v2/register")]
    Task<RegistrationResponse> Register([Body(BodySerializationMethod.Serialized)] RegistrationRequest request, CancellationToken token);
    
    [Get("/v2/my/agent")]
    Task<AgentResponse> GetAgent([Body(BodySerializationMethod.Serialized)] CancellationToken token);
}