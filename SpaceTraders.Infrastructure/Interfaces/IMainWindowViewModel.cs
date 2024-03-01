using Caliburn.Micro;

namespace SpaceTraders.Infrastructure.Interfaces;

public interface IMainWindowViewModel
{
    Task ActivateItem(Screen screen, CancellationToken cancellationToken = default);
    Task NavigateToHomePage();
}