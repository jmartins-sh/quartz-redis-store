using Quartz.Spi;

namespace Quartz.Redis.Store
{
    public class SampleSignaler : ISchedulerSignaler
    {
        internal int fMisfireCount;

        public Task NotifyTriggerListenersMisfired(
            ITrigger trigger,
            CancellationToken cancellationToken = default)
        {
            fMisfireCount++;
            return Task.CompletedTask;
        }

        public Task NotifySchedulerListenersFinalized(
            ITrigger trigger,
            CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task NotifySchedulerListenersError(
            string message,
            SchedulerException jpe,
            CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task NotifySchedulerListenersJobDeleted(
            JobKey jobKey,
            CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        void ISchedulerSignaler.SignalSchedulingChange(DateTimeOffset? candidateNewNextFireTimeUtc, CancellationToken cancellationToken)
        {
            Task.FromResult(true);
        }
    }
}
