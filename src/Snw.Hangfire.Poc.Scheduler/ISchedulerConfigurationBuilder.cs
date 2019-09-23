namespace Snw.Hangfire.Poc.Scheduler
{
    public interface ISchedulerConfigurationBuilder
    {
        ISchedulerConfigurationBuilder SetCron(string cron);
        ISchedulerConfigurationBuilder SetJobId(string jobId);

        SchedulerConfiguration BuildConfiguration();
    }
}