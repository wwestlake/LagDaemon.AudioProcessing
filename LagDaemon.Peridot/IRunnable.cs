using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.Peridot
{
    /// <summary>
    /// Executes a job once and returns.  This kind of job may loop internally, but the engine will 
    /// exit once the job completes.
    /// </summary>
    public interface IRunnable
    {
        void Execute(ITaskExecutionContext context);
    }

}
