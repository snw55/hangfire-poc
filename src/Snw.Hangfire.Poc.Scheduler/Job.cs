namespace Snw.Hangfire.Poc.Scheduler
{
    public class Job
    {
        public string Name { get; set; }
        public JobType Type { get; set; }
        public string Location { get; set; }
        public string Schedule { get; set; }
    }
}