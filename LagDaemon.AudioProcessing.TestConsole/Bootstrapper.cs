using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace LagDaemon.AudioProcessing.TestConsole;

public class Bootstrapper
{
    public static WindsorContainer Container { get; private set; }

    private static void Initialize()
    {
        if (Container != null) return;
        Container = new WindsorContainer();

        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        Container.Register(Component.For<IConfiguration>().Instance(configuration));

        InstallAssemblies();
    }

    private static void InstallAssemblies()
    {
        var assemblyDirectory = AppDomain.CurrentDomain.BaseDirectory;
        var assemblyFiles = Directory.GetFiles(assemblyDirectory, "LagDaemon.*.dll");

        foreach (var assemblyFile in assemblyFiles)
        {
            try
            {
                var assembly = Assembly.LoadFrom(assemblyFile);
                var installerTypes = assembly.GetExportedTypes()
                    .Where(t => typeof(IWindsorInstaller).IsAssignableFrom(t) && !t.IsAbstract);

                foreach (var installerType in installerTypes)
                {
                    var installer = Activator.CreateInstance(installerType) as IWindsorInstaller;
                    Container.Install(installer);
                }
            }
            catch (Exception ex)
            {
                // Handle assembly loading errors
                Console.WriteLine($"Error loading assembly '{assemblyFile}': {ex.Message}");
            }
        }
    }

    public static void StartApplication(Action action)
    {
        Initialize();
        action();
    }

}
