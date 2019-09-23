using System;

namespace Snw.Hangfire.Poc.Scheduler
{
    public class SchedulerBuilder : ISchedulerBuilder
    {
        private const string Every5ThMinute = "5/10 * * * *";
        private string _schedule;

        public ISchedulerBuilder SetCron(string cron)
        {
            _schedule = string.Copy(cron ?? throw new ArgumentNullException(nameof(cron)));
            return this;
        }

        public SchedulerConfiguration BuildSchedule()
        {
            return new SchedulerConfiguration
            {
                Cron = string.Copy(_schedule)
            };
        }

        public static Action<ISchedulerBuilder> DefaultConfiguration = builder => builder.SetCron(Every5ThMinute);
    }
}