using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LagDaemon.AudioProcessing.Api.Services
{
    public class ErrorHandlingService : IErrorHandlingService
    {
        public void HandleException(Exception exception)
        {
            // we will do something here, for now we write it to the console

            Console.WriteLine($"{DateTime.Now}: {exception.Message}\n{exception.StackTrace}");
        }

        public void HandleError(string message)
        {
            Console.WriteLine($"{DateTime.Now}: {message}");
        }

    }
}
