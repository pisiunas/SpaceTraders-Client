using NLog;
using SpaceTraders.Infrastructure.Api.Calls;
using SpaceTraders.Infrastructure.Api.Models.Authentication;
using SpaceTraders.Infrastructure.Interfaces;
using SpaceTraders.Infrastructure.Modules.Responses.UserInformation;
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
            Task<RegistrationResponse> response = _authenticationApi.Register(request, CancellationToken.None);
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

        Register(new RegistrationRequest(Factions.Cosmic, RandomString(6), "pokezen123@gmail.com"));
        return Task.CompletedTask;
    }
    
    private static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[new Random().Next(s.Length)]).ToArray());
    }
}
