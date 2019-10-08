using System;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.Server;

namespace Snw.Hangfire.Poc.Scheduler
{
    public class SchedulerJob : ISchedulerJob
    {
        private readonly IJobSource _jobSource;

        public SchedulerJob(IJobSource jobSource)
        {
            _jobSource = jobSource;
        }

        public Task ScheduleJobsAsync(PerformContext context)
        {
            var jobs = _jobSource.GetJobs();

            foreach (var job in jobs)
            {
                RecurringJob.AddOrUpdate(job.Name, () => Console.WriteLine("test"), job.Schedule);
            }

            return Task.CompletedTask;
        }
    }
}