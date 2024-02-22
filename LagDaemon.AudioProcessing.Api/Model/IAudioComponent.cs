using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.AudioProcessing.Api.Model
{
    public interface IAudioComponent
    {
        IEnumerable<IAudioComponent> ChildComponents { get; }
        IAudioBlock Process(IAudioBlock input);
    }
}
