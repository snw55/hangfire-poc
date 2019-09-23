using System;

namespace Snw.Hangfire.Poc.Scheduler
{
    public class SchedulerConfigurationBuilder : ISchedulerConfigurationBuilder
    {
        private const string DefaultJobId = "SchedulerJob";
        private const string Every5ThMinute = "5/10 * * * *";

        private string _schedule;
        private string _jobId;

        public ISchedulerConfigurationBuilder SetCron(string cron)
        {
            _schedule = string.Copy(cron ?? throw new ArgumentNullException(nameof(cron)));
            return this;
        }

        public ISchedulerConfigurationBuilder SetJobId(string jobId)
        {
            _jobId = string.Copy(jobId ?? throw new ArgumentNullException(nameof(jobId)));
            return this;
        }

        public SchedulerConfiguration BuildConfiguration()
        {
            return new SchedulerConfiguration
            {
                Cron = string.Copy(_schedule ?? Every5ThMinute),
                JobId = string.Copy(_jobId ?? DefaultJobId)
            };
        }
    }
}