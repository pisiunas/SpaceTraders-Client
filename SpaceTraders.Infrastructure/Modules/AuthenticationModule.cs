using Autofac;
using SpaceTraders.Infrastructure.Modules.Authentication;
using SpaceTraders.Infrastructure.SpaceTradersConfig;

namespace SpaceTraders.Infrastructure.Modules;

public class AuthenticationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<AuthenticationManager>().AsImplementedInterfaces();
    }
}