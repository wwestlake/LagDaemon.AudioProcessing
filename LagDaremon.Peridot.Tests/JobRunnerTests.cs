using LagDaemon.Peridot;

namespace LagDaremon.Peridot.Tests
{
    public class JobRunnerTests
    {
        private const int LifeTheUniverseAndEverything = 42;

        public class AnserToLifeTheUniverseAndEverythingJob : AbstractJob
        {

            public AnserToLifeTheUniverseAndEverythingJob(CancellationToken token) : base(token)
            {
            }

            protected override void Run(ITaskExecutionContext context)
            {
                var callback = context.Get<Action<int>>("callback");
                callback(LifeTheUniverseAndEverything);
            }
        }

        public class ThrowsExceptionJob : AbstractRestartOnExceptionJob
        {
            public ThrowsExceptionJob(CancellationToken token) : base(token)
            {
            }

            protected override void Run(ITaskExecutionContext context)
            {
                throw new NotImplementedException();
            }
        }


        [Fact]
        public void JobRunnerCreatsAndRunsAJob()
        {
            JobRunner<AnserToLifeTheUniverseAndEverythingJob> jobRunner 
                = new JobRunner<AnserToLifeTheUniverseAndEverythingJob>();

            var context = new TaskExecutionContext();

            int result = 0;

            context.Set("callback", (int a) => { 
                result = a;
            });

            jobRunner.Start(context);

            Assert.Equal(LifeTheUniverseAndEverything, result);

        }

        [Fact]
        public void AbstractRestartOnExceptionJob_throws_MaxRestartExceededException()
        {
            JobRunner<ThrowsExceptionJob> jobRunner
                = new JobRunner<ThrowsExceptionJob>();

            var context = new TaskExecutionContext();

            context.Set("MaxCount", 3);

            Assert.Throws<MaxRestartExceededException>(() => jobRunner.Start(context));

        }
    }
}