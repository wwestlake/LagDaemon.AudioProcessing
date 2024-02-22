using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.AudioProcessing.Api.Model
{
    public abstract class AudioComponentBase : IAudioComponent
    {
        public AudioComponentBase() { }

        readonly IEnumerable<IAudioComponent> childComponents;
        public IEnumerable<IAudioComponent> ChildComponents => childComponents;

        public IAudioBlock Process(IAudioBlock input)
        {
            IAudioBlock result = PreProcess( input );
            foreach (var child in ChildComponents) 
            { 
                result = child.Process(result);
            }
            return PostProcess( result );
        }

        protected abstract IAudioBlock PreProcess(IAudioBlock input);
        protected abstract IAudioBlock PostProcess(IAudioBlock input);

    }
}
