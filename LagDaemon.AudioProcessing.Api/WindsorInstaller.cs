using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using LagDaemon.AudioProcessing.Api.DataManagement.Implementations;
using LagDaemon.AudioProcessing.Api.DataManagement.Services;
using LagDaemon.AudioProcessing.Api.Interfaces;
using LagDaemon.AudioProcessing.Api.Services;
using LagDaemon.AudioProcessing.Api.Services.FileManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.AudioProcessing.Api
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IErrorHandlingService>().ImplementedBy<ErrorHandlingService>());
            container.Register(Component.For<IMetadataService>().ImplementedBy<MetadataService>());
            container.Register(Component.For<ISerializer, JsonSerializerImpl>());
            container.Register(Component.For<ISerializationService, SerializationService>());
            container.Register(Component.For<ISystemConfigurationService, SystemConfigurationService>());
            container.Register(Component.For<IProjectManagementService, ProjectManagementService>());
            container.Register(Component.For<ILoggerService, SerilogLoggerService>());
            container.Register(Component.For<IFileManagementService, FileManagementService>());
        }
    }
}
