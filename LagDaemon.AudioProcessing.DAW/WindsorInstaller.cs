using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace LagDaemon.AudioProcessing.DAW;

public class WindsorInstaller : IWindsorInstaller
{
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
        //container.Register(Component.For<MainViewModel>());
        //container.Register(Component.For<MainWindow>());
        //container.Register(Component.For<NewProjectViewModel>());
        //container.Register(Component.For<DevicesViewModel>());
        //container.Register(Component.For<StartPageViewModel>());
    }
}
