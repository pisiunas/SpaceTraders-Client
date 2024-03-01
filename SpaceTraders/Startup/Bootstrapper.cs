using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using Autofac;
using Caliburn.Micro;
using NLog;
using SpaceTraders.Configuration;
using SpaceTraders.Exceptions;
using SpaceTraders.Infrastructure.Interfaces;
using SpaceTraders.ViewModels;
using LogManager = NLog.LogManager;

namespace SpaceTraders.Startup;

public class Bootstrapper : BootstrapperBase
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private static IContainer _container = null!;

    public Bootstrapper()
    {
        Initialize();
        new UnhandledExceptionHandler();
    }

    protected override void Configure()
    {
        _container = SpaceTradersContainerBuilder.Build();
    }
    
    protected override async void OnStartup(object sender, StartupEventArgs e)
    {
        _logger.Info($"Starting SpaceTraders Version: {Assembly.GetExecutingAssembly().GetName().Version?.ToString()}");

        await ExecuteOnStartup();

        await DisplayRootViewForAsync<MainWindowViewModel>();
    }
    
    protected override void OnExit(object sender, EventArgs e) => _container.Dispose();

    protected override IEnumerable<Assembly> SelectAssemblies() => new[] { Assembly.GetExecutingAssembly() };

    protected override object GetInstance(Type service, string key) => _container.Resolve(service);

    protected override IEnumerable<object> GetAllInstances(Type service)
        => _container.Resolve(typeof(IEnumerable<>).MakeGenericType(service)) as IEnumerable<object>;

    protected override void BuildUp(object instance) => _container?.InjectProperties(instance);

    private static async Task ExecuteOnStartup()
    {
        await using ILifetimeScope scope = _container.BeginLifetimeScope();
        IEnumerable<IOnStartup> onStartup = scope.Resolve<IEnumerable<IOnStartup>>();
        await Task.WhenAll(onStartup.Select(s => s.OnStartup()));
    }
}