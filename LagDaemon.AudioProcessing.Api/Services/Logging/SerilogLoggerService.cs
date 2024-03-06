using Serilog;
using Serilog.Events;
using System;

public class SerilogLoggerService : ILoggerService
{
    private readonly ILogger _logger;

    public SerilogLoggerService(string logFilePath)
    {
        _logger = new LoggerConfiguration()
            .WriteTo.File(logFilePath)
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
