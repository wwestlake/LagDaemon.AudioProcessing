using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.Peridot
{
    public abstract class AbstractJob : IRunnable
    {
        private readonly CancellationToken _cancellationToken;
        public AbstractJob(CancellationToken token)
        {
            _cancellationToken = token;
        }

        public void Execute(ITaskExecutionContext context)
        {
            Run(context);
        }

        protected abstract void Run(ITaskExecutionContext context);

    }

    public abstract class AbstractContinuousJob : IRunnable
    {
        private readonly CancellationToken _cancellationToken;
        public AbstractContinuousJob(CancellationToken token)
        {
            _cancellationToken = token;
        }

        public void Execute(ITaskExecutionContext context)
        {
            while (!context.CancellationToken.IsCancellationRequested)
            {
                Run(context);
            }
        }

        protected abstract void Run(ITaskExecutionContext context);
    }

    public abstract class AbstractRestartOnExceptionJob : IRunnable
    {
        private readonly CancellationToken _cancellationToken;
        public AbstractRestartOnExceptionJob(CancellationToken token)
        {
            _cancellationToken = token;
        }
        public void Execute(ITaskExecutionContext context)
        {
            var maxCount = context.Get<int>("MaxCount");
            var exceptions = new List<Exception>();

            while (!context.CancellationToken.IsCancellationRequested)
            {
                try
                {
                    Run(context);
                } 
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                    maxCount--;
                }
                if (maxCount == 0) throw new MaxRestartExceededException(exceptions, context);
            }
        }

        protected abstract void Run(ITaskExecutionContext context);
    }


}


