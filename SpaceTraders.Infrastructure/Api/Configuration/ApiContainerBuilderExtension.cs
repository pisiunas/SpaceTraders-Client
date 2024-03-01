using System.Text.Json;
using System.Text.Json.Serialization;
using Autofac;
using Refit;
using SpaceTraders.Infrastructure.Http;
using SpaceTraders.Infrastructure.SpaceTradersConfig;

namespace SpaceTraders.Infrastructure.Api.Configuration;

public static class ApiContainerBuilderExtension
{
    public static void RegisterApiClient<T>(this ContainerBuilder builder) where T : notnull
        => builder.Register(context =>
            RestService.For<T>(
                Constants.Api.BaseApiUrl,
                new RefitSettings
                {
                    HttpMessageHandlerFactory = () => GetHttpMessageHandlers(context),
                    ContentSerializer = new SystemTextJsonContentSerializer(GetOptions())
                }));

    private static HttpMessageHandler GetHttpMessageHandlers(IComponentContext context)
        => new AuthenticationHttpMessageHandler(
            GetInnerHandler(),
            context.Resolve<ISpaceTradersConfigManager>());

    private static HttpMessageHandler GetInnerHandler()
    {
        return new HttpMessageLoggingHandler(new HttpClientHandler());
    }

    private static JsonSerializerOptions GetOptions()
        => new()
        {
            Converters =
            {
                new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
            }
        };
}