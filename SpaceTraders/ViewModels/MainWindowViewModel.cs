using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using SpaceTraders.Infrastructure.Interfaces;
using SpaceTraders.ViewModels.HomePage;

namespace SpaceTraders.ViewModels;

public class MainWindowViewModel : Conductor<Screen>.Collection.OneActive, IMainWindowViewModel
{
    private readonly HomePageViewModel _homePageViewModel;

    public MainWindowViewModel(HomePageViewModel homePageViewModel)
    {
        _homePageViewModel = homePageViewModel;
    }
    
    protected override async Task OnInitializeAsync(CancellationToken cancellationToken)
    {
        await ActivateItem(_homePageViewModel, cancellationToken).ConfigureAwait(false);
    }
    
    public Task ActivateItem(Screen screen, CancellationToken cancellationToken = default)
    {
        OnUIThread(() => ActivateItemAsync(screen, cancellationToken));
        return Task.CompletedTask;
    }

    public async Task NavigateToHomePage() => await ActivateItem(_homePageViewModel).ConfigureAwait(false);
}