using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using MediatR;
using NLog;
using SpaceTraders.Infrastructure.Messaging.Interfaces;
using SpaceTraders.Infrastructure.Modules.HomePage.Messages;
using SpaceTraders.Infrastructure.Modules.ServerInformation.Messages;
using SpaceTraders.ViewModels.NavigationGrid;
using LogManager = NLog.LogManager;

namespace SpaceTraders.ViewModels.HomePage;

public class HomePageViewModel : Screen, INotificationHandler<ServerInfoUpdated>
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    
    private readonly IMessagePublisher _messagePublisher;
    private readonly NavigationGridViewModel _navigationGrid;
    
    public string ServerStatusText { get; set; }

    public NavigationGridViewModel NavigationGrid { get; }

    public HomePageViewModel(IMessagePublisher messagePublisher, NavigationGridViewModel navigationGrid)
    {
        _messagePublisher = messagePublisher;
        NavigationGrid = navigationGrid;
        _navigationGrid = navigationGrid;
    }

    protected override async Task OnInitializeAsync(CancellationToken cancellationToken)
    {
        _navigationGrid.ConductWith(this);
        await _messagePublisher.Publish(new ServerInfoRequested(), cancellationToken);
    } 

    public async Task OpenProfileView() => await _messagePublisher.Publish(new OpenProfileWindow(), CancellationToken.None);

    public Task Handle(ServerInfoUpdated notification, CancellationToken cancellationToken)
    {
        ServerStatusText = notification.ServerInformation.Status;
        _logger.Info($"Server Status: {ServerStatusText}");
        return Task.CompletedTask;
    }
}
