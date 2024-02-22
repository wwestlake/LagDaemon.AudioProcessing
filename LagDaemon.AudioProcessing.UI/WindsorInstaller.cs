﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using LagDaemon.AudioProcessing.UI.ViewModels;

namespace LagDaemon.AudioProcessing.UI
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<MainViewModel>());
            container.Register(Component.For<MainWindow>());
            container.Register(Component.For<NewProjectViewModel>());
            container.Register(Component.For<DevicesViewModel>());
        }
    }
}
