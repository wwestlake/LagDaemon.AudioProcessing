public interface ILoggerService
{
    void LogInformation(string message);
    void LogWarning(string message);
    void LogError(string message);
    void LogException(Exception exception, string message = null);
    void LogDebug(string message);
}
