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
            services.AddTransient<ISchedulerConfigurationBuilder, SchedulerConfigurationBuilder>();

            return services;
        }

        public static IApplicationBuilder UseScheduler(this IApplicationBuilder app, Action<ISchedulerConfigurationBuilder> builderConfiguration = null)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            var builder = app.ApplicationServices.GetRequiredService<ISchedulerConfigurationBuilder>();
            builderConfiguration?.Invoke(builder);

            var schedulerConfiguration = builder.BuildConfiguration();

            RecurringJob.AddOrUpdate<ISchedulerJob>(job => job.ScheduleJobs(), schedulerConfiguration.Cron);

            return app;
        }
    }
}