using SpaceTraders.Infrastructure.Api.Models.Authentication;

namespace SpaceTraders.Infrastructure.Modules.Authentication;

public interface IAuthenticationManager
{
    bool Register(RegistrationRequest request);
}