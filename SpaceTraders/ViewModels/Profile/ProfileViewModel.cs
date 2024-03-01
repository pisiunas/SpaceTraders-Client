using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using NLog;
using SpaceTraders.Infrastructure.Api.Calls;
using SpaceTraders.Infrastructure.Navigation;
using LogManager = NLog.LogManager;

namespace SpaceTraders.ViewModels.Profile;

public class ProfileViewModel : Screen
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private readonly INavigationModule _navigationModule;
    private readonly IAuthenticationApi _authenticationApi;

    public string AccountId { get; set; }
    public string AgentName { get; set; }
    public string Headquarters { get; set; }
    public int Credits { get; set; }
    public string StartingFaction { get; set; }
    public int ShipCount { get; set; }

    public ProfileViewModel(INavigationModule navigationModule, IAuthenticationApi authenticationApi)
    {
        _navigationModule = navigationModule;
        _authenticationApi = authenticationApi;
    }

    protected override Task OnInitializeAsync(CancellationToken cancellationToken)
    {
        var response = _authenticationApi.GetAgent(cancellationToken);

        AccountId = response.Result.Agent.AccountId;
        AgentName = response.Result.Agent.AgentName;
        Headquarters = response.Result.Agent.Headquarters;
        Credits = response.Result.Agent.Credits;
        StartingFaction = response.Result.Agent.StartingFaction;
        ShipCount = response.Result.Agent.ShipCount;
        
        return base.OnInitializeAsync(cancellationToken);
    }

    public async Task NavigateBackToMainView()
    {
        await _navigationModule.NavigateToMainView();
    }
}