namespace Snw.Hangfire.Poc.Scheduler
{
    public interface ISchedulerBuilder
    {
        ISchedulerBuilder SetCron(string cron);

        SchedulerConfiguration BuildSchedule();
    }
}