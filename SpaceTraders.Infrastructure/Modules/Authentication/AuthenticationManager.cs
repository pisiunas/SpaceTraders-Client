using NLog;
using SpaceTraders.Infrastructure.Api.Calls;
using SpaceTraders.Infrastructure.Api.Models.Authentication;
using SpaceTraders.Infrastructure.Interfaces;
using SpaceTraders.Infrastructure.SpaceTradersConfig;

namespace SpaceTraders.Infrastructure.Modules.Authentication;

public class AuthenticationManager : IAuthenticationManager, IOnStartup
{
    private readonly IAuthenticationApi _authenticationApi;
    private readonly ISpaceTradersConfigManager _spaceTradersConfigManager;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

    public AuthenticationManager(IAuthenticationApi authenticationApi, ISpaceTradersConfigManager spaceTradersConfigManager)
    {
        _authenticationApi = authenticationApi;
        _spaceTradersConfigManager = spaceTradersConfigManager;
    }

    public bool IsAuthenticated { get; private set; }
    
    public bool Register(RegistrationRequest request)
    {
        try
        {
            var response = _authenticationApi.Register(request, CancellationToken.None);
            _spaceTradersConfigManager.SetIsRegistered(true);
            _spaceTradersConfigManager.SetToken(response.Result.Data.Token);
            _logger.Debug($"Agent created: Name {request.AgentName}, Faction {request.Faction}, Email {request.Email}");
            return true;
        }
        catch (Exception e)
        {
            _logger.Error(e,"Failed to register");
            return false;
        }
    }

    public Task OnStartup()
    {
        if (_spaceTradersConfigManager.GetIsRegistered())
        {
            return Task.CompletedTask;
        }

        Register(new RegistrationRequest(Factions.Cosmic, "Pisiunas00000", "pokezen123@gmail.com"));
        return Task.CompletedTask;
    }
}