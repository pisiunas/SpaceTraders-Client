using Autofac;
using SpaceTraders.ViewModels;
using SpaceTraders.ViewModels.HomePage;
using SpaceTraders.ViewModels.NavigationGrid;
using SpaceTraders.ViewModels.Profile;

namespace SpaceTraders.Configuration.Modules;

public class ViewModelModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<MainWindowViewModel>().AsImplementedInterfaces().AsSelf().SingleInstance();
        builder.RegisterType<ProfileViewModel>().AsImplementedInterfaces().AsSelf();
        builder.RegisterType<HomePageViewModel>().AsImplementedInterfaces().AsSelf().SingleInstance();
        builder.RegisterType<NavigationGridViewModel>().AsImplementedInterfaces().AsSelf().SingleInstance();
    }
}
