using System.Collections.Generic;

namespace Snw.Hangfire.Poc.Scheduler
{
    public interface IJobSource
    {
        IEnumerable<Job> GetJobs();
    }
}