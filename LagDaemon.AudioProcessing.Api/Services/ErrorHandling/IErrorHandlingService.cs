using System;
using System.Linq;

namespace LagDaemon.AudioProcessing.Api.Services.ErrorHandling
{
    public interface IErrorHandlingService
    {
        void HandleError(string message);
        void HandleException(Exception exception);
    }
}
