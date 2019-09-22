namespace Snw.Hangfire.Poc.Scheduler
{
    public interface ISchedulerBuilder
    {
        string Schedule { get; }

        ISchedulerBuilder SetSchedule(string cron);
    }
}