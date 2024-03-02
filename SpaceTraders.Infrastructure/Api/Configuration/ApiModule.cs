using Autofac;
using SpaceTraders.Infrastructure.Api.Calls;

namespace SpaceTraders.Infrastructure.Api.Configuration;

public class ApiModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterApiClient<IServerInformationApi>();
        builder.RegisterApiClient<IAuthenticationApi>();
        builder.RegisterApiClient<ISystemsApi>();
    }
}
