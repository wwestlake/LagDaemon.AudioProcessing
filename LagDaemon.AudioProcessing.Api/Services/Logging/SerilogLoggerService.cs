using LagDaemon.AudioProcessing.Api.Services.SystemServices;
using Serilog;

public class SerilogLoggerService : ILoggerService
{
    private readonly ILogger _logger;
    private readonly string LOG_FILE_KEY = "log.fileath";

    public SerilogLoggerService(ISystemConfigurationService config)
    {
        var logFilePath = config.GetSetting<string>(LOG_FILE_KEY);
        _logger = new LoggerConfiguration()
            .WriteTo.File(logFilePath)
            .WriteTo.Console()
            .CreateLogger();
    }

    public void LogInformation(string message)
    {
        _logger.Information(message);
    }

    public void LogWarning(string message)
    {
        _logger.Warning(message);
    }

    public void LogError(string message)
    {
        _logger.Error(message);
    }

    public void LogException(Exception exception, string message = null)
    {
        _logger.Error(exception, message);
    }

    public void LogDebug(string message)
    {
        _logger.Debug(message);
    }
}
