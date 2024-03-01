using Autofac;
using SpaceTraders.Configuration.Modules;
using SpaceTraders.Infrastructure.Api.Configuration;
using SpaceTraders.Infrastructure.Messaging;
using SpaceTraders.Infrastructure.Modules;
using SpaceTraders.Infrastructure.SpaceTradersConfig;
using SpaceTraders.Navigation;

namespace SpaceTraders.Configuration;

public class SpaceTradersContainerBuilder
{
    public static IContainer Build()
    {
        var builder = new ContainerBuilder();

        builder.RegisterModule<CoreModule>();
        builder.RegisterModule<ViewModelModule>();
        builder.RegisterModule<MessagingModule>();
        builder.RegisterModule<ApiModule>();
        builder.RegisterModule<ServerInformationModule>();
        builder.RegisterModule<AppConfigModule>();
        builder.RegisterModule<AuthenticationModule>();
        builder.RegisterModule<NavigationModule>();

        return builder.Build();
    }
}