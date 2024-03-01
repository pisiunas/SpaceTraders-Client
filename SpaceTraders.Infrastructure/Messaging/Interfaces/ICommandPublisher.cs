using MediatR;

namespace SpaceTraders.Infrastructure.Messaging.Interfaces;

public interface ICommandPublisher
{
    Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
}