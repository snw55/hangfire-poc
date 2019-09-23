using System.Threading.Tasks;

namespace Snw.Hangfire.Poc.Scheduler
{
    public interface ISchedulerJob
    {
        Task ScheduleJobs();
    }
}