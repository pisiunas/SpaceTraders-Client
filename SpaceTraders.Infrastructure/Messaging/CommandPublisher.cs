using Autofac;
using MediatR;
using SpaceTraders.Infrastructure.Messaging.Interfaces;

namespace SpaceTraders.Infrastructure.Messaging;

public class CommandPublisher : ICommandPublisher
{
    private readonly ISender _sender;
    
    public CommandPublisher(ISender sender)
    {
        _sender = sender;
    }
    
    public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default) => _sender.Send(request, cancellationToken);
}