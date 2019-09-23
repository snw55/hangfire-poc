using System;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Snw.Hangfire.Poc.Scheduler;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class SchedulerExtensions
    {
        public static IServiceCollection AddScheduler(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddTransient<ISchedulerJob, YamlSchedulerJob>();
            services.AddTransient<ISchedulerBuilder, SchedulerBuilder>();

            return services;
        }

        public static IApplicationBuilder UseScheduler(this IApplicationBuilder app, Action<ISchedulerBuilder> builderConfiguration = null)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            var builder = app.ApplicationServices.GetRequiredService<ISchedulerBuilder>();
            (builderConfiguration ?? SchedulerBuilder.DefaultConfiguration).Invoke(builder);

            var scheduleConfiguration = builder.BuildSchedule();

            RecurringJob.AddOrUpdate<ISchedulerJob>(nameof(ISchedulerJob), job => job.ScheduleJobs(), scheduleConfiguration.Cron);

            return app;
        }
    }
}