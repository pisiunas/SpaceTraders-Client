using NLog;

namespace SpaceTraders.Infrastructure.Http;

public class HttpMessageLoggingHandler : DelegatingHandler
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    
    public HttpMessageLoggingHandler(HttpMessageHandler innerHandler) : base(innerHandler)
    {
        InnerHandler = innerHandler;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        _logger.Debug("Begin request {request}", request.RequestUri);
        _logger.Debug("{@request}", request);

        HttpResponseMessage? response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

        _logger.Debug("Got response {response}", response.ReasonPhrase);
        _logger.Debug("{@response}", response);

        return response;
    }
}