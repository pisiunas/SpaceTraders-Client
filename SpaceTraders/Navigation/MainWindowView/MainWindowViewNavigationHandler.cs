using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SpaceTraders.Infrastructure.Messages;
using SpaceTraders.Infrastructure.Modules.HomePage.Messages;
using SpaceTraders.Infrastructure.Navigation;
using SpaceTraders.ViewModels.Profile;

namespace SpaceTraders.Navigation.MainWindowView;

public class MainWindowViewNavigationHandler : INotificationHandler<OpenProfileWindow>
{
    private readonly ProfileViewModel _profileViewModel;
    private readonly INavigationModule _navigationModule;

    public MainWindowViewNavigationHandler(ProfileViewModel profileViewModel, INavigationModule navigationModule)
    {
        _profileViewModel = profileViewModel;
        _navigationModule = navigationModule;
    }


    public Task Handle(OpenProfileWindow notification, CancellationToken cancellationToken)
    {
        _navigationModule.Navigate(_profileViewModel, cancellationToken);
        
        return Task.CompletedTask;
    }
}