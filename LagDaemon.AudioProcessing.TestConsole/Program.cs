using Castle.MicroKernel.Registration;
using Castle.Windsor;
using LagDaemon.AudioProcessing.Api.DataManagement.FileManagement;
using LagDaemon.AudioProcessing.Api.DataManagement.Implementations;
using LagDaemon.AudioProcessing.Api.DataManagement.Models;
using LagDaemon.AudioProcessing.Api.DataManagement.Services;
using LagDaemon.AudioProcessing.Api.Interfaces;
using LagDaemon.AudioProcessing.Api.Services;

namespace LagDaemon.AudioProcessing.TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();
            container.Register(Component.For<ISerializer, JsonSerializerImpl>());
            container.Register(Component.For<ISerializationService, SerializationService>());
            container.Register(Component.For<ISystemConfigurationService,  SystemConfigurationService>());  
            var config = container.Resolve<ISystemConfigurationService>();

            Console.WriteLine($"{config.GetSetting<int>("test")}");

            //config.SetSetting("something", "somevalue");

            Console.WriteLine($"{config.GetSetting<string>("something")}");

            config.Save();
        }
    }
}
