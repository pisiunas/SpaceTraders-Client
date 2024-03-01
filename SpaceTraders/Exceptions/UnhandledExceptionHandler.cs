using System;
using System.Windows.Threading;
using NLog;

namespace SpaceTraders.Exceptions;

public class UnhandledExceptionHandler
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    
    public UnhandledExceptionHandler()
    {
        System.Windows.Application.Current.DispatcherUnhandledException += CurrentOnDispatcherUnhandledException;
        AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
    }

    private void CurrentOnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e) =>
        _logger.Error(e.Exception);

    private void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        => _logger.Error(e.ExceptionObject);
}