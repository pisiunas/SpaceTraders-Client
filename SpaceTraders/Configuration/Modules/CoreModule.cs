using Autofac;
using Caliburn.Micro;
using SpaceTraders.Infrastructure.Navigation;
using SpaceTraders.Infrastructure.SpaceTradersConfig;

namespace SpaceTraders.Configuration.Modules;

public class CoreModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<WindowManager>().As<IWindowManager>().SingleInstance();
        builder.RegisterType<NavigationModule>().AsImplementedInterfaces();
    }
}