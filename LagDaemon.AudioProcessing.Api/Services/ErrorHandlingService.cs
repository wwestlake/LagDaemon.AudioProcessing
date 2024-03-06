namespace LagDaemon.AudioProcessing.Api.Services
{
    public class ErrorHandlingService : IErrorHandlingService
    {
        private readonly ILoggerService _logger;

        public ErrorHandlingService(ILoggerService logger)
        {
            _logger = logger;
        }

        public void HandleException(Exception exception)
        {
            _logger.LogException(exception);
        }

        public void HandleError(string message)
        {
            _logger.LogError(message);
        }

    }
}
