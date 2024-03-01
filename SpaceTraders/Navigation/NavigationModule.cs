using Autofac;
using SpaceTraders.Navigation.MainWindowView;
using SpaceTraders.ViewModels;

namespace SpaceTraders.Navigation;

public class NavigationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<MainWindowViewNavigationHandler>().AsImplementedInterfaces().AsSelf();
    }
}