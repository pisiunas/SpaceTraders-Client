using Caliburn.Micro;

namespace SpaceTraders.Infrastructure.Navigation;

public interface INavigationModule
{
    public Task Navigate(Screen screen, CancellationToken cancellationToken = default);

    public Task NavigateToMainView(CancellationToken cancellationToken = default);
}