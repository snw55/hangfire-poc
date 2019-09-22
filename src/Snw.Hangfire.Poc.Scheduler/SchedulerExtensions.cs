using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Snw.Hangfire.Poc.Scheduler
{
    public static class SchedulerExtensions
    {
        private const string DefaultSchedule = "5/10 * * * *";

        public static IServiceCollection AddScheduler(this IServiceCollection services)
        {
            return services;
        }

        public static IApplicationBuilder UseScheduler(this IApplicationBuilder app, Action<ISchedulerBuilder> builder = null)
        {
            

            return app;
        }
    }
}