using System;
using System.Linq;

namespace LagDaemon.AudioProcessing.Api.Services
{
    public interface IErrorHandlingService
    {
        void HandleError(string message);
        void HandleException(Exception exception);
    }
}
