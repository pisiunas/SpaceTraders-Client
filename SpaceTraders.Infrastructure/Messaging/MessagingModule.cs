using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;
using SpaceTraders.Infrastructure.Messages;
using SpaceTraders.Infrastructure.Messaging.Interfaces;

namespace SpaceTraders.Infrastructure.Messaging;

public class MessagingModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<MessagePublisher>().AsImplementedInterfaces().AsSelf();
        builder.RegisterType<CommandPublisher>().AsImplementedInterfaces().AsSelf();

        builder.RegisterDecorator<MessagesLogging, IMessagePublisher>();
        
        var configuration = MediatRConfigurationBuilder
            .Create(typeof(PingHandler).Assembly)
            .WithAllOpenGenericHandlerTypesRegistered()
            .WithRegistrationScope(RegistrationScope.Scoped) // currently only supported values are `Transient` and `Scoped`
            .Build();
        
        builder.RegisterMediatR(configuration);
    }
}
