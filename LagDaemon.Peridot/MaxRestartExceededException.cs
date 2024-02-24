namespace LagDaemon.Peridot
{
    public class MaxRestartExceededException : Exception
    {
        public MaxRestartExceededException(List<Exception> exceptions, ITaskExecutionContext context)
        {
            Exceptions = exceptions;
            Context = context;
        }

        public List<Exception> Exceptions { get; }
        public ITaskExecutionContext Context { get; }
    }
}
