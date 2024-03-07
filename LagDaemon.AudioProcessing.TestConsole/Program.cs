using LagDaemon.AudioProcessing.Api.Services.ProjectManagement;

namespace LagDaemon.AudioProcessing.TestConsole;

internal class Program
{
    static void Main(string[] args)
    {
        Bootstrapper.StartApplication(() => 
        {
            Bootstrapper.Container.Resolve<IApplication>().Run();            
        });
    }
}
