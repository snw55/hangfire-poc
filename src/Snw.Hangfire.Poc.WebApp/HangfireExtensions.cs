using System;
using Snw.Hangfire.Poc.WebApp;

// ReSharper disable once CheckNamespace
namespace Hangfire
{
    public static class HangfireExtensions
    {
        public static IGlobalConfiguration UseExtensionsJobActivator(this IGlobalConfiguration globalConfiguration, IServiceProvider serviceProvider)
        {
            var activator = new ExtensionsJobActivator(serviceProvider);
            return globalConfiguration.UseActivator(activator);
        }
    }
}