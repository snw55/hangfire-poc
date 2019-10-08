using System;
using Microsoft.Extensions.Configuration;
using Snw.Hangfire.Poc.Scheduler;
using Snw.Hangfire.Poc.WebApp;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            return services.Configure<YamlSettings>(configuration.GetSection("SchedulerJob:Yaml"));
        }
    }
}