using System;
using Caliburn.Micro;
using NLog;
using SpaceTraders.Logging;
using SpaceTraders.Startup;
using LogManager = NLog.LogManager;

namespace SpaceTraders
{
    public class AppExtensions
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public int Main()
        {
            LoggingConfigurator.ConfigureLogging();
        
            try
            {
                _logger.Info("== Booting SpaceTraders ==");
                ConfigureUiLocators();

                new Bootstrapper();
            }
            catch(Exception e)
            {
                _logger.Error($"Failed to boot application {e}");
            }
        
            return Environment.ExitCode;
        }
    
        private static void ConfigureUiLocators()
        {
            var config = new TypeMappingConfiguration
            {
                DefaultSubNamespaceForViews = "SpaceTraders.Views",
                DefaultSubNamespaceForViewModels = "SpaceTraders.ViewModels"
            };

            ViewLocator.ConfigureTypeMappings(config);
            ViewModelLocator.ConfigureTypeMappings(config);
        }
    }
}