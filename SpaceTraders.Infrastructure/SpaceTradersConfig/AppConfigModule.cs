using Autofac;

namespace SpaceTraders.Infrastructure.SpaceTradersConfig;

public class AppConfigModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<SpaceTradersConfigManager>().AsImplementedInterfaces();
    }
}