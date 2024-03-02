using Autofac;

namespace SpaceTraders.Infrastructure.Modules;

public class SystemInformationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        //builder.RegisterType<ServerInformationManager>().AsImplementedInterfaces().SingleInstance();
    }
}
