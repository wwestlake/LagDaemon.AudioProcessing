using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LagDaemon.Peridot
{
    public class JobRunner<T> where T : IRunnable
    {
        private Type _jobType;
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public JobRunner()
        {
            _jobType = typeof(T);
        }

        public void Start(ITaskExecutionContext context)
        {
            context.CancellationToken = _cancellationTokenSource.Token;
            var job = CreateJob(context.CancellationToken);
            job.Execute(context);
        }

        public void Stop()
        {
            _cancellationTokenSource?.Cancel();
        }

        private IRunnable CreateJob(CancellationToken token)
        {
            if (_jobType.IsClass && !_jobType.IsAbstract)
            {
                var constructor = _jobType.GetConstructor(new[] { typeof(CancellationToken) });
                if (constructor != null)
                {
                    var tempResult = constructor.Invoke(new object[] { token });
                    if (tempResult != null)
                    {
                        return tempResult as IRunnable;
                    }
                }
            }
            throw new ApplicationException($"Unable to create job: {_jobType.FullName}");
        }
    }
}
