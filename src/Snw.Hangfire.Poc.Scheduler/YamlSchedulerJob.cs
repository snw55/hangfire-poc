using System.Threading.Tasks;

namespace Snw.Hangfire.Poc.Scheduler
{
    public class YamlSchedulerJob : ISchedulerJob
    {
        public Task ScheduleJobs()
        {
            return Task.CompletedTask;
        }
    }
}