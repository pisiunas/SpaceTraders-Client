using Autofac;
using SpaceTraders.Infrastructure.Modules.ServerInformation;

namespace SpaceTraders.Infrastructure.Modules;

public class ServerInformationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ServerInformationManager>().AsImplementedInterfaces().SingleInstance();
    }
}