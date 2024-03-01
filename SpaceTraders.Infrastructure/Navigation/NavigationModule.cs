using Caliburn.Micro;
using NLog;
using SpaceTraders.Infrastructure.Interfaces;

namespace SpaceTraders.Infrastructure.Navigation;

public class NavigationModule : INavigationModule
{
    private static readonly Logger _logger = NLog.LogManager.GetCurrentClassLogger();
    
    private readonly IMainWindowViewModel _mainWindowViewModel;

    public NavigationModule(IMainWindowViewModel mainWindowViewModel)
    {
        _mainWindowViewModel = mainWindowViewModel;
    }

    public Task Navigate(Screen screen, CancellationToken cancellationToken = default)
    {
        _logger.Debug($"Navigating to {screen}");
        _mainWindowViewModel.ActivateItem(screen, cancellationToken);
        return Task.CompletedTask;
    }
    
    public Task NavigateToMainView(CancellationToken cancellationToken = default)
    {
        _logger.Debug($"Navigating to MainView");
        _mainWindowViewModel.NavigateToHomePage();
        return Task.CompletedTask;
    }
}