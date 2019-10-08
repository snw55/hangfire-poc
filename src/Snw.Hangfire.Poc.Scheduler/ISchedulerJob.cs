using System.Threading.Tasks;
using Hangfire.Server;

namespace Snw.Hangfire.Poc.Scheduler
{
    public interface ISchedulerJob
    {
        Task ScheduleJobsAsync(PerformContext context);
    }
}