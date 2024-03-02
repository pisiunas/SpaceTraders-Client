using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using PropertyChanged;
using SpaceTraders.Infrastructure.Messaging.Interfaces;
using SpaceTraders.Infrastructure.Modules.NavigationGrid.Commands;
using SpaceTraders.Infrastructure.Modules.Responses.SystemsInformation;
using SpaceTraders.ViewModels.NavigationGrid.Waypoints;
using Waypoint = SpaceTraders.ViewModels.NavigationGrid.Waypoints.Waypoint;

namespace SpaceTraders.ViewModels.NavigationGrid;

public class NavigationGridViewModel : Screen
{
    private readonly ICommandPublisher _commandPublisher;
    
    public ObservableCollection<Waypoint> PlanetsWayPoints { get; set; } = new();

    public NavigationGridViewModel(ICommandPublisher commandPublisher)
    {
        _commandPublisher = commandPublisher;
        AddPlanetWayPoint();
    }
    
    protected override async Task OnInitializeAsync(CancellationToken cancellationToken)
    {
    }
    
    public void AddPlanetWayPoint()
    {
        Task<GetSystemResponse> localSystemData = _commandPublisher.Send(new RequestLocalSystemData("X1-BD70"));

         foreach (var waypoint in localSystemData.Result.Data.Waypoints)
         {
             PlanetsWayPoints.Add(new Waypoint()
             {
                 Symbol = waypoint.Symbol,
                 Type = waypoint.Type,
                 X = waypoint.X,
                 Y = waypoint.Y
             });
             
        
         }
    }
}
