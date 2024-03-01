using System.Net.Http.Headers;
using SpaceTraders.Infrastructure.SpaceTradersConfig;

namespace SpaceTraders.Infrastructure.Http;

public class AuthenticationHttpMessageHandler : DelegatingHandler
{
    private readonly ISpaceTradersConfigManager _spaceTradersConfigManager;
    
    public AuthenticationHttpMessageHandler(HttpMessageHandler innerHandler, ISpaceTradersConfigManager spaceTradersConfigManager) : base(innerHandler)
    {
        _spaceTradersConfigManager = spaceTradersConfigManager;
        InnerHandler = innerHandler;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        string token = _spaceTradersConfigManager.GetToken();

        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        
        return base.SendAsync(request, cancellationToken);
    }
}