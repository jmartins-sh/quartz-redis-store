using Common.Logging;

namespace Quartz.Redis.Store.UnitTest.Jobs
{
    [PersistJobDataAfterExecution]
    [DisallowConcurrentExecution]
    [JobCron("0/9 * * * * ?")]
    public class TestJob2 : IJob
    {
        protected ILog Logger = LogManager.GetLogger(typeof(TestJob));
        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Run(() =>
            {
                Logger.Debug(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "TestJob");
            });
        }

    }
}
