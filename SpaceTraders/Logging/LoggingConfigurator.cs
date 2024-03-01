using NLog;

namespace SpaceTraders.Logging;

public static class LoggingConfigurator
{
    public static void ConfigureLogging()
    {
        LogManager.Setup().LoadConfiguration(builder => {
            builder.ForLogger().FilterMinLevel(LogLevel.Debug).WriteToFile(fileName: "Logs/logs.log", layout: "${longdate} [${level:uppercase=true}] [${logger}] ${message:withexception=true}");
        });
    }
}