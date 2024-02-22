using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using LagDaemon.AudioProcessing.UI.Facilities;
using LagDaemon.AudioProcessing.UI.ViewModels;
using System.IO;
using System.Reflection;
using System.Windows;

namespace LagDaemon.AudioProcessing.UI
{
    public class Bootstrapper
    {
        public static WindsorContainer Container { get; private set; }

        private static void Initialize()
        {
            if (Container != null) return;
            Container = new WindsorContainer();
            //Container.AddFacility<ViewModelFacility>();

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
    


        public static void StartApplication()
        {
            Initialize();
            // Start the WPF application on a separate STA thread
            Thread wpfThread = new Thread(() =>
            {
                // Initialize WPF application context
                var app = new Application();

                // Load your WPF UserControl or Window from the DLL
                // Replace "YourNamespace" and "YourUserControl" with appropriate names
                var control = Container.Resolve<MainWindow>();

                // Show the WPF UserControl or Window
                app.Run(control);
            });

            // Set the apartment state before starting the thread
            wpfThread.SetApartmentState(ApartmentState.STA);
            wpfThread.Start();

            // Wait for the WPF application thread to exit
            wpfThread.Join();

        }




    }
}
