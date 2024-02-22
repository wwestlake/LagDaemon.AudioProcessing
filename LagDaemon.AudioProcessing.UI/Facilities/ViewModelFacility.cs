using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using LagDaemon.AudioProcessing.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.AudioProcessing.UI.Facilities
{
    public class ViewModelFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.Register(
                Classes.FromThisAssembly()
                    .BasedOn<IViewModelBase>()
                    .WithServiceAllInterfaces()
            );
        }
    }
}
